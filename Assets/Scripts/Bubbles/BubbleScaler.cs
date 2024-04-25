using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BubbleScaler : MonoBehaviour
{
    [SerializeField] private TextMeshPro _bubbleText;
    [SerializeField] private float _scaleFactor = .005f;
    
    private Vector3 _initialScale;
    // Start is called before the first frame update
    void Start()
    {
        _initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //scale should at least stay 0.15 on start
        if (_bubbleText.text.Length > 40)
        {
            //scale the bubble slightly based on the length of the text
            float exceeded = (_bubbleText.text.Length - 40) / 30;
            transform.localScale = _initialScale + new Vector3(exceeded, exceeded, exceeded);
            
            return;
        }
        else
        {
            transform.localScale = _initialScale;
        }
        
    }
}
