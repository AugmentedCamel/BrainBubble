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
    

    
    // Start is called before the first frame update
    void Start()
    {
        _physicsFollower = GetComponent<PhysicsFollower>();
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if (_isGenerating)
        {
            _bubbleText.text = "Generating...";
            
        }
    }
    
    public void SetText(string text)
    {
        bubbleText = text;
    }
    
    public string GetText()
    {
        return bubbleText;
    }
    
    public void ReleaseBubble()
    {
        _physicsFollower.isFollowing = false;
        OnBubbleGenerated();
    }
    
    public void GenerateBubble()
    {
        _isGenerating = true;
        _bubbleText.text = bubbleText;
    }
    
    private void OnBubbleGenerated()
    {
        _isGenerating = false;
        _bubbleText.text = SummarizeText();
        
    }
    
    private string SummarizeText()
    {
        string summarizedText = "summarized text";
        
        return summarizedText;
    }
    
}
