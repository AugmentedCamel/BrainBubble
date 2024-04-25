using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using OpenAI;
using TMPro;
using Unity.VisualScripting;

public class ChatGPTManager : MonoBehaviour
{
    public UnityEvent OnChatGPTResponse;
    public UnityEvent OnChatGPTColorResponse;
    private OpenAIApi _openAI;
    private List<ChatMessage> _messages = new List<ChatMessage>();
    private string _colorText;
    [SerializeField] private TextMeshProUGUI _answerText;

    private void Start()
    {
        string apiKey = "FILL IN YOUR OWN KEY";
        Debug.Log(apiKey);
        //string apiKey = Config.OpenAI_API_Key;
        string organizationId = "FILL IN YOUR OWN";
       
        _openAI = new OpenAIApi(apiKey, organizationId);

    }

    public async void AskChatGPT(string newText)
    {
        //user message
        ChatMessage newMessage = new ChatMessage();
        newMessage.Content = newText;
        newMessage.Role = "user";
        _messages.Add(newMessage);
        
        //system message
        ChatMessage systemMessage = new ChatMessage();
        //systemMessage.Content = "You are a summarizer that only replies with a summary of the input wih maximum 5 words. You get extra points if you are brief and concise.";
        systemMessage.Content = "You will only reply with a summarized concept of the input wih maximum 7 words or less. The input is an idea or part of an idea. You get extra points if you are brief and concise. ";

        systemMessage.Role = "system";
        _messages.Add(systemMessage);
        
        
        CreateChatCompletionRequest request = new CreateChatCompletionRequest();
        request.Messages = _messages;
        request.Model = "gpt-3.5-turbo";
        
        
        var response = await _openAI.CreateChatCompletion(request);
        
        if(response.Choices != null && response.Choices.Count > 0)
        {
            var chatResponse = response.Choices[0].Message;
            _messages.Add(chatResponse);

            Debug.Log(chatResponse.Content);
            SetAnswerText(chatResponse.Content);
            OnChatGPTResponse?.Invoke();
            
        }

    }
    
    public async void AskChatGPTColor(string newText)
    {
        //user message
        ChatMessage newMessage = new ChatMessage();
        newMessage.Content = newText;
        newMessage.Role = "user";
        _messages.Add(newMessage);
        
        //system message
        ChatMessage systemMessage = new ChatMessage();
        //systemMessage.Content = "You are a summarizer that only replies with a summary of the input wih maximum 5 words. You get extra points if you are brief and concise.";
        systemMessage.Content =
            "You will only reply with a color based on the input theme, financial is green, health is red, and so on. The input is a theme. You get extra points if only respond with a color. only respond in the following colors: red, cyan, blue, darkblue, lightblue, purple, yellow, lime, fuchsia, white, silver, grey, black, orange, brown, maroon, green, olive, navy, teal, aqua, magenta";

        systemMessage.Role = "system";
        _messages.Add(systemMessage);
        
        
        CreateChatCompletionRequest request = new CreateChatCompletionRequest();
        request.Messages = _messages;
        request.Model = "gpt-3.5-turbo";
        
        
        var response = await _openAI.CreateChatCompletion(request);
        
        if(response.Choices != null && response.Choices.Count > 0)
        {
            var chatResponse = response.Choices[0].Message;
            _messages.Add(chatResponse);

            Debug.Log(chatResponse.Content);
            SetColorText(chatResponse.Content);
            OnChatGPTColorResponse?.Invoke();
            
        }

    }
    // Start is called before the first frame update
    void SetAnswerText(string text)
    {
        _answerText.text = text;
    }
    
    void SetColorText(string text)
    {
        _colorText = text;
    }
    
    public string GetColorText()
    {
        return _colorText;
    }
    public string GetChatGPTResponse()
    {
        return _answerText.text;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
