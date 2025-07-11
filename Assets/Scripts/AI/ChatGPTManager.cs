using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using TMPro;
using System;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using iamai_core_lib;
using System.Collections;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Unity.VisualScripting.Antlr3.Runtime;

public class ChatGPTManager : MonoBehaviour
{
   
    public static ChatGPTManager instance { get; private set; }


	public List<string> ModelList;
    bool failed = false;
    string failedStr = string.Empty;
	public iamai_core_lib.AI ai;
	public EventHandler<onResponseEventArgs> OnResponseEvent;
    string askString;
    public class onResponseEventArgs : EventArgs {
        public string response;
    }
    [SerializeField] bool inGame = true;

    private List<string> chatMessages = new List<string>();

    private string convertHistory() {
        string history = "";
        bool isHuman = true;
        foreach(var item in chatMessages) {
            if (isHuman) {
                history += "Human- ";
            } else {
                history += "Ai- ";
            }
            history += item + "\n";
            isHuman = !isHuman;
        }
        return history;
    }

    public async void askChatGpt(TextMeshProUGUI newText) {
        try{
            await askChatGpt(newText.text);
        } catch (Exception e) {
            Debug.Log(e);
            OnResponseEvent.Invoke(this, new onResponseEventArgs{response = "Chat Generation Failed, please try again."});
        }
    }

    public async Task askChatGpt(string newText, int maxLength = 2048) {
		chatMessages.Add(newText);
        Debug.Log(newText);
        try {
			ai.Dispose();
			string history = convertHistory();
			await ai.Activate();
			ai.setPromptFormat(askString);

			var chatResponse = await ai.GenerateAsync(history, maxLength);

			Debug.Log(chatResponse);
			OnResponseEvent.Invoke(this, new onResponseEventArgs { response = chatResponse });
			chatMessages.Add(chatResponse);
		} catch (Exception e) {
			Debug.Log(e);
			ai.Dispose();
			string history = convertHistory();
            chatMessages.Clear();
            activateAI(history);
		}
	}

	private void Awake() {
		instance = this;
		ai = new iamai_core_lib.AI(ModelList[0], 65536, 32768, 32768, 10);
        ai.Dispose();
		//string APIKey1 = "sk-proj-7nHydVzVbf4qnZ4PyLukzzG1xIHwDExRgOK7WV4mS54brG-mDOh0-";
		//string APIKey2 = "qc1mw1P4JeFrPuhkDcD4QT3BlbkFJfLQErALmd8r2HqO71x8Y9Paqyh7cnxvGCP73HSjO4u53K41R7fLhek6zCHC6pTwVo7CNBPsUsA";
		//string OrgKey1 = "org-2Iy83XZfi";
		//string OrgKey2 = "gtCwVWJsL1jnJ4i";
		//openAI = new OpenAIApi(APIKey1 + APIKey2, OrgKey1 + OrgKey2);
	}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        activateAI("Ask me to describe my character.");
    }

    public async void activateAI(string input) {

		try {
			await ai.Activate();
			//Debug.Log("Ai Activated");
			if (inGame) {
				Debug.Log(SaveManager.instance.getString(SaveManager.DataLabel.MESSAGES));
			     askString = "You are a Dungeon Master AI. All responses must strictly follow this format: Name:CharacterImage:BackgroundImage:Dialogue Use 'Narrator:Null:BackgroundImage:Dialogue' when narration or environmental description is needed. Every response must advance the story with multiple lines using several 4-field entries in sequence (not just one line). Keep dialogue immersive, in-character, and in-universe. Avoid modern or out-of-character phrases. Do not include explanations or break character formatting. Always use only the characters and backgrounds provided in the lists below. Character Images:";
				foreach (var c in GameManager.charactersnames) {
					askString += "'" + c + "', ";
				}
				askString += ". And here is the list of available BackgroundImages.";
				foreach (var c in GameManager.Backgrounds) {
					askString += "'" + c + "', ";
				}
				//if (SaveManager.instance.getString(SaveManager.DataLabel.MESSAGES) == "" || SaveManager.instance.getString(SaveManager.DataLabel.MESSAGES) == null) {
					//string askString = "Narrator:Null:BirchForest:The forest is quiet, save for the distant hoot of an owl. Who are you?";
					//string askString = "Write a story about a robot who learns to paint.";

					//string askString = "You are the Dungeon Master in a high fantasy world. Always speak using this format: Name:Character:Background:Line - 'Name' is the speaker's name (e.g., Narrator, Kael, Elira). - 'Character' is the image name of the character or creature. - 'Background' is the name of the setting. - 'Line' is what the character says or what is described. If no character is speaking, use: Name:Narrator:Background:Line Only use image names from this list:[MaleHumanPaladin, FemaleElfWizard, RedDragon, DireWolf, OwlBear](Use closest match for custom characters or monsters.)Only use background names from this list:[BirchForest, VillageTavernInside, CastleRuins, ForestPath]Do not use quotation marks.Begin by setting the scene, then ask the player who their character is.";

					askString += ". Example format: | Narrator:Null:ForestPath:You step quietly through the rustling underbrush of the ancient forest. | Alric:MaleHumanPaladin:CastleThroneRoom:We must rally the guards — the shadow returns tonight! | Zira:FemaleElfWizard:AncientLibrary:The wards have weakened. Something old is waking... \nnow respond to the player input: '{prompt}'";
					Debug.Log(askString);
					ai.setPromptFormat(askString);
					await askChatGpt(input);
				//} else {
				//	load();
				//	askString += "this is what you last said, please repeat it '" + chatMessages[chatMessages.Count] + "'";
				//	await askChatGpt(askString);
				//}
			}
		} catch (Exception e) {
			Debug.Log(e);
            failed = true;
            failedStr = e.ToString();
		}
	}

    // Update is called once per frame
    void Update() {
		if (failed) {
		    OnResponseEvent.Invoke(this, new onResponseEventArgs { response ="null:null:null: failed to initialize AI." });
			failed = false;
		}
	}

    public void save(int saveint) {
        switch (saveint) {
            case 1:
                save(SaveManager.DataLabel.MESSAGES1);
                break;
            case 2:
                save(SaveManager.DataLabel.MESSAGES2);
                break;
            case 3:
                save(SaveManager.DataLabel.MESSAGES3);
                break;
        }
    }

    public void save(SaveManager.DataLabel label) {
        string SavedString = "";
        SavedString = convertHistory();

		string path = Application.dataPath + "/Log.txt";
		if (!File.Exists(path)) {
			File.WriteAllText(path, "SavedString");
		}
		//SaveManager.instance.setString(label, SavedString);
	}

    public void load() {
        string[] messages = SaveManager.instance.getString(SaveManager.DataLabel.MESSAGES).Split("/");
        chatMessages = new List<string>();
        foreach (string message in messages) {
            if (message != "") {
                string chatMessage = message;
                chatMessages.Add(chatMessage);
            }
        }
    }

	private void OnDestroy() {
        ai.Dispose();
	}
}
