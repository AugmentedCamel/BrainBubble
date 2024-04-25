using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DictationManager : MonoBehaviour
{
    [SerializeField] private DictationActivationCustom _dictation;
    [SerializeField] private MultiTransriptionManager _transcriptionManager;
    [SerializeField] private TextMeshPro _textHolder;
    private bool _isRecording;
    
    public string latestTranscription;
    
    // Start is called before the first frame update
    //public string GetSummary()
    //{
        //string summarizedText = latestTranscription;
        //return summarizedText;
    //}
    
    private void UpdateTranscription()
    {
        latestTranscription = string.Copy(_textHolder.text);
    }
    
    public void StartRecording() //when new bubble is being generated
    {
        if (!_isRecording) //so it only starts recording once
        {
            _transcriptionManager.Clear();
            _dictation.ToggleActivation();
            _isRecording = true;
        }
        
    }
    
    public void StopRecording() //when the bubble is released
    {
        if (_isRecording)
        {
            _dictation.ToggleActivation();
            _isRecording = false;
            UpdateTranscription();
            //_transcriptionManager.Clear();
        }
    }
    
    
    // Update is called once per frame
    void Update()
    {
        if (_isRecording)
        {
            UpdateTranscription();
        }
    }
}
