using UnityEngine;
using OpenAI;
using System.Collections.Generic;
using UnityEngine.Events;
using TMPro;
using System;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using UnityEditor.Overlays;

public class ChatGPTManager : MonoBehaviour
{
   
    public static ChatGPTManager instance { get; private set; }


    public EventHandler<onResponseEventArgs> OnResponseEvent;

    public class onResponseEventArgs : EventArgs {
        public string response;
    }


    private OpenAIApi openAI = new OpenAIApi();
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
            save();
        }

	}

	private void Awake() {
		instance = this;
	}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        Debug.Log(SaveManager.instance.getString(SaveManager.DataLabel.MESSAGES));
        if (SaveManager.instance.getString(SaveManager.DataLabel.MESSAGES) == "" || SaveManager.instance.getString(SaveManager.DataLabel.MESSAGES) == null) {

            string askString = "This is a high fantasy world, you will be the dm, if say a line please do Narrator:Image:Line please precede every line with who is speaking. Image is the name of the image of the character, we have ";
            foreach (var c in GameManager.charactersnames) {
                askString += "\"" + c + "\", ";
            }
            askString += "you have to use one of the given names for image.If the narrator is speaking say Image is \"Null\" and name as Narrator, two examples are \"Narrator:Null:This is the world eldoria.\" and \"Issac:MaleHumanChild:Hi There, I'm isaac. \". start off with describing the setting, then asking about my character. don't use quotation marks at all.";
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

    public void save() {
        string SavedString = "";
        foreach (ChatMessage chatMessage in chatMessages) {
            SavedString += chatMessage.Content + "/";
            SavedString += chatMessage.Role + "|";
        }
        SaveManager.instance.setString(SaveManager.DataLabel.MESSAGES, SavedString);
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
