using UnityEngine;
using OpenAI;
using System.Collections.Generic;
using UnityEngine.Events;
using TMPro;
using System;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class ChatGPTManager : MonoBehaviour
{
   
    public static ChatGPTManager instance { get; private set; }


    public EventHandler<onResponseEventArgs> OnResponseEvent;

    public class onResponseEventArgs : EventArgs {
        public string response;
    }


    private OpenAIApi openAI;
    private List<ChatMessage> chatMessages = new List<ChatMessage>();

    public void askChatGpt(TextMeshProUGUI newText) {
        askChatGpt(newText.text);
    }

    public async void askChatGpt(string newText) {
        ChatMessage chatMessage = new ChatMessage();
        chatMessage.Content = newText;
        chatMessage.Role = "user";

        chatMessages.Add(chatMessage);

        CreateChatCompletionRequest request = new CreateChatCompletionRequest();
        request.Messages = chatMessages;
        request.Model = "gpt-4o-mini";

        var response = await openAI.CreateChatCompletion(request);

        if (response.Choices != null && response.Choices.Count > 0) {
            var chatReponse = response.Choices[0].Message;
            chatMessages.Add(chatReponse);

            Debug.Log(chatReponse.Content.ToString()); 
            OnResponseEvent.Invoke(this, new onResponseEventArgs { response = chatReponse.Content });
        }

	}

	private void Awake() {
		instance = this; 
        string APIKey1 = "sk-proj-7nHydVzVbf4qnZ4PyLukzzG1xIHwDExRgOK7WV4mS54brG-mDOh0-";
		string APIKey2 = "qc1mw1P4JeFrPuhkDcD4QT3BlbkFJfLQErALmd8r2HqO71x8Y9Paqyh7cnxvGCP73HSjO4u53K41R7fLhek6zCHC6pTwVo7CNBPsUsA";
		string OrgKey1 = "org-2Iy83XZfi";
		string OrgKey2 = "gtCwVWJsL1jnJ4i";
		openAI = new OpenAIApi(APIKey1 + APIKey2, OrgKey1 + OrgKey2);
	}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        Debug.Log(SaveManager.instance.getString(SaveManager.DataLabel.MESSAGES));
        if (SaveManager.instance.getString(SaveManager.DataLabel.MESSAGES) == "" || SaveManager.instance.getString(SaveManager.DataLabel.MESSAGES) == null) {

            string askString = "This is a high fantasy world, you will be the dm, if say a line please do Name:Character:Background:Line please precede every line with who is speaking. Image is the name of the image of the character, we have ";
            foreach (var c in GameManager.charactersnames) {
                askString += "\"" + c + "\", ";
            }
            askString += "you have to use one of the given names for Character.If there is no character needed say Image is \"Null\" and Name is Narrator, and you can use the narrator speaking and a monster Image if it makes sense.when making characters give each of them their own unique name just use a Character name for the image used for that character that is closest to what was intended. The names for the backgrounds are ";
			foreach (var c in GameManager.Backgrounds) {
				askString += "\"" + c + "\", ";
			}
			askString += "You have to use one of these given names for the Background. three examples are \"Narrator:Null:BirchForest:This is the forest called whispering woods.\" and \"Issac:MaleHumanChild:Village:Hi There, I'm isaac. \" and \"Narrator:DireWolf:ForestPath:You slash towards the beast, laying a fatal blow. \". start off with describing the setting, then asking about my character. don't use quotation marks at all.";
            Debug.Log(askString);
            askChatGpt(askString);
        } else {
            load();
            OnResponseEvent.Invoke(this, new onResponseEventArgs { response = chatMessages[chatMessages.Count - 1].Content });
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void save(int saveint) {
        switch (saveint) {
            case 1:
                save(SaveManager.DataLabel.MESSAGES1);
                break;
            case 2:
                save(SaveManager.DataLabel.MESSAGES1);
                break;
            case 3:
                save(SaveManager.DataLabel.MESSAGES1);
                break;
        }
    }

    public void save(SaveManager.DataLabel label) {
        string SavedString = "";
        foreach (ChatMessage chatMessage in chatMessages) {
            SavedString += chatMessage.Content + "/";
            SavedString += chatMessage.Role + "|";
        }
        SaveManager.instance.setString(label, SavedString);
    }

	public void load() {
        string[] messages = SaveManager.instance.getString(SaveManager.DataLabel.MESSAGES).Split("|");
        chatMessages = new List<ChatMessage>();
        foreach (string message in messages) {
            if (message != "") {
                string[] messagecontent = message.Split("/");
                ChatMessage chatMessage = new ChatMessage();
                chatMessage.Content = messagecontent[0];
                chatMessage.Role = messagecontent[1];
                chatMessages.Add(chatMessage);
            }
        }
    }
}
