using Ink.Parsed;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {get; private set; }
	private string[] sentences;
	private string[] names;
	int currentResponse = 0;
	bool responded = false;
	[SerializeField] GameObject inputfield;
	[SerializeField] GameObject Waiting;
	[SerializeField] TMP_InputField textInput;
	[SerializeField] TextMeshProUGUI text;
	[SerializeField] TextMeshProUGUI nametext;


	private void Awake() {
		instance = this;
	}

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
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
			if (s == null || s.Length == 0) {

			} else {
				finalsenteces.Add(s);
			}
		}
		sentences = finalsenteces.ToArray();

        //check if sentence uses name
		names = new string[sentences.Length];
		string lastname = "Narrator";
        for (int i = 0; i < sentences.Length; i++)
        {
			if (sentences[i].Contains(":")) {
				string[] output = sentences[i].Split(":");
				names[i] = output[0];
				lastname = output[0];
				sentences[i] = output[1];
			} else {
				names[i] = lastname;
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
			currentResponse++;
		} else {
			inputfield.SetActive(true);
			responded = true;
			text.textWrappingMode = TextWrappingModes.Normal;
		}
	}

	public void respond() {
		//Put check if empty
		ChatGPTManager.instance.askChatGpt(textInput.text);
		inputfield.SetActive(false);
		responded = true;
		textInput.text = "";
		Waiting.SetActive(true);
	}
}
