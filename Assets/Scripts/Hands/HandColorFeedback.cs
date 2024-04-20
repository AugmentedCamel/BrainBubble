using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace Hands
{
    public class HandColorFeedback : MonoBehaviour
    {
        [SerializeField] private GameObject _handLeft;
        [SerializeField] private GameObject _handRight;
        [SerializeField] private List<Material> _handMaterials;
        
        [SerializeField] private Material _defaultMaterial;
        [SerializeField] private Material _PositiveMaterial;
        [SerializeField] private Material _NegativeMaterial;
        
        private Renderer _rendererL;
        private Renderer _rendererR;
        // Start is called before the first frame update
        void Start()
        {
            _rendererL = _handLeft.GetComponent<Renderer>();
            _rendererR = _handRight.GetComponent<Renderer>();
        }
        
        [Button]
        public void SetPositiveFeedback()
        {
            _rendererL.material = _PositiveMaterial;
            _rendererR.material = _PositiveMaterial;
        }
        
        [Button]
        public void SetNegativeFeedback()
        {
            _rendererL.material = _NegativeMaterial;
            _rendererR.material = _NegativeMaterial;
        }
        
        [Button]
        public void SetDefaultFeedback()
        {
            _rendererL.material = _defaultMaterial;
            _rendererR.material = _defaultMaterial;
        }
    }

}
