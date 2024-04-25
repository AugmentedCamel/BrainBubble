using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Bubble : MonoBehaviour
{
    public string bubbleText;
    
    private PhysicsFollower _physicsFollower;
    
    [SerializeField] private TextMeshPro _bubbleText;
    [SerializeField] private bool _isGenerating = false;
    [SerializeField] private DictationManager _dictationManager;
    [SerializeField] private ChatGPTManager _chatGPTManager;
    [SerializeField] private BubbleSelectable _bubbleSelectable;
    // Start is called before the first frame update
    void Start()
    {
        _physicsFollower = GetComponent<PhysicsFollower>();
        
        
    }
    
    private void HandleChatGPTResponse()
    {
        bubbleText = _chatGPTManager.GetChatGPTResponse();
        _chatGPTManager.OnChatGPTResponse.RemoveListener(HandleChatGPTResponse);
        Debug.Log("ChatGPT response received: " + bubbleText);
        _bubbleText.text = bubbleText;
        AskBubbleColor(bubbleText);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isGenerating)
        {
            _bubbleText.text = string.Copy(_dictationManager.latestTranscription);
            //_bubbleText.text = "Generating...";
            
        }
    }
    
    
    
    public string GetText()
    {
        return bubbleText;
    }
    
    public void ReleaseBubble()
    {
        Debug.Log("Bubble released");
        _physicsFollower.isFollowing = false;
        OnBubbleGenerated();
    }
    
    public void GenerateBubble()
    {
        Debug.Log("Bubble generated");
        _chatGPTManager.OnChatGPTResponse.AddListener(HandleChatGPTResponse);
        _chatGPTManager.OnChatGPTColorResponse.AddListener(ColorResponseHandler);
        _isGenerating = true;
        //_bubbleText.text = bubbleText;
        _dictationManager.StartRecording();
    }
    
    private void OnBubbleGenerated()
    {
        Debug.Log("Bubble generated, summarizing text...");
        _isGenerating = false;
        _dictationManager.StopRecording();
        SummarizeText();
        
        //bubble should be selectable after releasing
        _bubbleSelectable.SetSelectable(true);
        
    }
    
    private void SummarizeText()
    {
        if (_bubbleText.text.Length > 20)
        {
            _chatGPTManager.AskChatGPT(_bubbleText.text);
        }
        else
        {
            bubbleText = _bubbleText.text;
            _chatGPTManager.OnChatGPTResponse.RemoveListener(HandleChatGPTResponse); // the bubble is already summarized and we should remove listener
            AskBubbleColor(bubbleText);
            
        }
    }

    private void AskBubbleColor(string text)
    {
        _chatGPTManager.AskChatGPTColor(text);
        
    }

    private void ColorResponseHandler()
    {
        string color = _chatGPTManager.GetColorText();
        if (color != null)
        {
            if (ColorUtility.TryParseHtmlString(color, out var newColor))
            {
                SetBubbleColor(newColor);
                Debug.Log("Color received: " + color);
            }
            else
            {
                Debug.Log("Color could not be parsed" + color);
                _chatGPTManager.OnChatGPTColorResponse.RemoveListener(ColorResponseHandler);
            }
        }
    }
    
    private void SetBubbleColor(Color color)
    {
        _bubbleText.color = color;
        _chatGPTManager.OnChatGPTColorResponse.RemoveListener(ColorResponseHandler);
    }
    
}
