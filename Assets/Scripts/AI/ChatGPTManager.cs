using UnityEngine;
using OpenAI;
using System.Collections.Generic;
using UnityEngine.Events;
using TMPro;
using System;

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
        }

	}

	private void Awake() {
		instance = this;
	}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        askChatGpt("This is a high fantasy world, you will be the dm, if say a line please do Narrator:Line please precede every line with who is speaking. start off with describing the setting, then asking about my character. dont use quotation marks at all.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
