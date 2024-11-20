using UnityEngine;
using OpenAI;
using System.Collections.Generic;
using UnityEngine.Events;
using TMPro;

public class ChatGPTManager : MonoBehaviour
{
    public OnResponseEvent onResponse;

    [System.Serializable]
    public class OnResponseEvent : UnityEvent<string> { };

    private OpenAIApi openAI = new OpenAIApi("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", "org-2Iy83XZfigtCwVWJsL1jnJ4i");
    private List<ChatMessage> chatMessages = new List<ChatMessage>();

    public async void askChatGpt(TextMeshProUGUI newText) {
        ChatMessage chatMessage = new ChatMessage();
        chatMessage.Content = newText.text;
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
