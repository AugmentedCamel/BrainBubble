using System.Collections;
using System.Collections.Generic;
using Meta.WitAi.Dictation;
using NaughtyAttributes;
using UnityEngine;


public class DictationActivationCustom : MonoBehaviour
{
    [SerializeField] private DictationService _dictation;

    private bool _isActive = false;
    
    // Start is called before the first frame update
    
    
    public void ToggleActivation()
    {
        if (_isActive)
        {
            _dictation.Deactivate();
            _isActive = false;
        }
        else
        {
            _dictation.Activate();
            _isActive = true;
        }
    }
}
