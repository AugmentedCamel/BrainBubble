using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BubbleSucker : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 3f;
    
    public List<BubbleSelectable> _nearBubbles = new List<BubbleSelectable>();
    
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out BubbleSelectable bubble))
        {
            if (!_nearBubbles.Contains(bubble))
            {
                _nearBubbles.Add(bubble);
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out BubbleSelectable bubble))
        {
            if (_nearBubbles.Contains(bubble))
            {
                _nearBubbles.Remove(bubble);
            }
        }
    }

    public void Update()
    {
        foreach (var variaBubbleBLE in _nearBubbles)
        {
            if (variaBubbleBLE.GameObject().TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.AddForce(_target.transform.position - variaBubbleBLE.transform.position, ForceMode.Force);
            }
            
        }
    }
}
