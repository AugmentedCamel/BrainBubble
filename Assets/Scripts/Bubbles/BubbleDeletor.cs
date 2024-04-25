using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BubbleDeletor : MonoBehaviour
{
    [SerializeField] private float _deletionTime = 3f;
    [SerializeField] private BubbleSucker _bubbleSucker;
    private List<BubbleSelectable> bubbleSelectables;
    private void Start()
    {
        bubbleSelectables = new List<BubbleSelectable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BubbleSelectable bubble))
        {
            bubbleSelectables.Add(bubble);
            StartCoroutine(DeleteBubble(bubble));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out BubbleSelectable bubble))
        {
            bubbleSelectables.Remove(bubble);
            StopAllCoroutines();
        }
    }

    private IEnumerator DeleteBubble(BubbleSelectable bubble)
    {
        
        
        yield return new WaitForSeconds(_deletionTime);
        bubbleSelectables.Remove(bubble);
        if (_bubbleSucker._nearBubbles.Contains(bubble))
        {
            _bubbleSucker._nearBubbles.Remove(bubble);
        }
        bubble.PlayParticle();
        
        Destroy(bubble.gameObject);
        
    }
}
