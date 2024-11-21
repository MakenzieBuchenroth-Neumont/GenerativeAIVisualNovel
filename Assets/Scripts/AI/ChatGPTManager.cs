using UnityEngine;
using OpenAI;
using System.Collections.Generic;
using UnityEngine.Events;
using TMPro;

public class ChatGPTManager : MonoBehaviour
{
    public OnResponseEvent onResponse;
    public ChatGPTManager instance { get; private set; }

    [System.Serializable]
    public class OnResponseEvent : UnityEvent<string> { };

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
            onResponse.Invoke(chatReponse.Content);
        }

	}

	private void Awake() {
		instance = this;
	}

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        askChatGpt("This is a high fantasy world and I want you to tell me the story like a interactive visual novel, you will play as the narrator and the npc's, i will respond as either what my character will say or do, this response should stay open ended. start of giving me a short descriptions of where I am and then ask me what who I am playing as. say everything as if your a dm and keep your responses to a paragraph or so and seperate descriptions and conversation by :");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
