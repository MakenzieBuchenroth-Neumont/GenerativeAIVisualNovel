using Ink.Parsed;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {get; private set; }
	private string[] sentences;
	private string[] names;
	private Texture[] characterImages;
	int currentResponse = 0;
	bool responded = false;
	[SerializeField] GameObject inputfield;
	[SerializeField] GameObject Waiting;
	[SerializeField] TMP_InputField textInput;
	[SerializeField] TextMeshProUGUI text;
	[SerializeField] TextMeshProUGUI nametext;
	[SerializeField] RawImage characterImage;
	[SerializeField] CharacterListSO characters;

	public static List<CharacterListSO.Characters> charactersnames = new List<CharacterListSO.Characters>();

	private void Awake() {
		instance = this;
	}

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		for (int i = 1; (CharacterListSO.Characters)i != CharacterListSO.Characters.FemaleHumanChild; i++) {
			charactersnames.Add((CharacterListSO.Characters)i);
		}
		ChatGPTManager.instance.OnResponseEvent += newText;
        DontDestroyOnLoad(gameObject);
		inputfield.SetActive(false);
		Waiting.SetActive(true);
    }

    private void newText(object sender, ChatGPTManager.onResponseEventArgs e) {
		string[] seperators = { ". ", ".", "\n", "!", "?","*", '"'.ToString()};
		responded = false;
		Waiting.SetActive(false);
        sentences = e.response.Split(seperators, System.StringSplitOptions.None);
		currentResponse = 0;

		//check for empty sentences
		List<string> finalsenteces = new List<string>();
		foreach (string s in sentences) {
			if (s == null || s.Length == 0 || s == " ") {

			} else {
				finalsenteces.Add(s);
			}
		}
		sentences = finalsenteces.ToArray();

        //check if sentence uses name
		names = new string[sentences.Length];
		characterImages = new Texture[sentences.Length];
		string lastname = "Narrator";
		Texture lastCharacter = null;
        for (int i = 0; i < sentences.Length; i++)
        {
			if (sentences[i].Contains(":")) {
				string[] output = sentences[i].Split(":");
				names[i] = output[0];
				lastname = output[0];
				characterImages[i] = characters.getCharacter((CharacterListSO.valueOf(output[1])));
				lastCharacter = characterImages[i];
				sentences[i] = output[2];
			} else {
				names[i] = lastname;
				characterImages[i] = lastCharacter;
			}
        }

        //add periods to the end.
        for (int i = 0; i < sentences.Length; i++)
        {
			sentences[i] = sentences[i].Insert(sentences[i].Length, ".");
        }

		ContinueStory();
    }

    // Update is called once per frame
    void Update()
    {
		if (!responded && DialogueManager.instance.canContinueToNextLine && (Input.GetKeyDown(KeyCode.Space) )) {
			inputfield.SetActive(false);
			ContinueStory();
		}
	}

	private void ContinueStory() {
		if (currentResponse < sentences.Length) {
			// set text for current dialogue line
			if (DialogueManager.instance.displayLineCoroutine != null) {
				StopCoroutine(DialogueManager.instance.displayLineCoroutine);
			}
			// handle tags

			DialogueManager.instance.displayLineCoroutine = StartCoroutine(DialogueManager.instance.DisplayLine(sentences[currentResponse]));
			nametext.text = names[currentResponse];
			characterImage.texture = characterImages[currentResponse];
			currentResponse++;
		} else {
			inputfield.SetActive(true);
			responded = true;
			text.textWrappingMode = TextWrappingModes.Normal;
		}
	}

	public void respond() {
		//Put check if empty
		inputfield.SetActive(false);
		ChatGPTManager.instance.askChatGpt(textInput.text);
		responded = true;
		textInput.text = "";
		Waiting.SetActive(true);
	}
}
