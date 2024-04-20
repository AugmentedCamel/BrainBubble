using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FingerTrigger : MonoBehaviour
{
    public string fingerName;
    
    public bool isTriggered = false;
    public bool isThumb = false;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        if (isThumb) { return;}
        if (other.gameObject.TryGetComponent<FingerTrigger>(out FingerTrigger fingerTrigger))
        {
            Debug.Log(fingerTrigger.fingerName + " is triggered");
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
