using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class BubbleSelector : MonoBehaviour
{
    //keeps track of selected bubbles using a list and trigger colliders
    [SerializeField] private List<BubbleSelectable> _selectedBubble = new List<BubbleSelectable>();
    [SerializeField] private List<BubbleSelectable> _activatedBubble = new List<BubbleSelectable>();
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BubbleSelectable bubble))
        {
            if (!_selectedBubble.Contains(bubble))
            {
                if (bubble._isSelectable)
                {
                    _selectedBubble.Add(bubble);
                    bubble.SelectBubble();
                }
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out BubbleSelectable bubble))
        {
            if (_selectedBubble.Contains(bubble))
            {
                _selectedBubble.Remove(bubble);
                bubble.DeselectBubble();
            }
        }
    }
    
    //with gesture close pinch
    [Button]
    public void ActivateBubble()
    {
        if (_selectedBubble.Count > 0 && _activatedBubble.Count == 0)
        {
            _selectedBubble[0].SetSelectable(false);
            _selectedBubble[0].DeselectBubble();
            _activatedBubble.Add(_selectedBubble[0]);
            _selectedBubble.RemoveAt(0);
            _activatedBubble[0].ActivateBubble();
            
            Debug.Log("Bubble activated");
        }
    }
    
    //with gesture open pinch
    [Button]
    public void DeactivateBubble()
    {

        if (_activatedBubble.Count > 0)
        {
            if (_selectedBubble.Count > 0) //check if should perform action ACTIVATE LINE RENDERER
            {
                _activatedBubble[0].SetLineEndPoint(_selectedBubble[0].transform);
     
            }
            
            //return to normal
            _activatedBubble[0].SetSelectable(true);
            _activatedBubble[0].DeActivateBubble();
            _activatedBubble.RemoveAt(0);
            
            Debug.Log("Bubble deactivated");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_selectedBubble.Count > 1) //only one bubble selectable
        {
            _selectedBubble[1].DeselectBubble();
            _selectedBubble.RemoveAt(1);
        }
    }
}
