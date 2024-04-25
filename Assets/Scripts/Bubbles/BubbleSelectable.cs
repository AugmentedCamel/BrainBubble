using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSelectable : MonoBehaviour
{
    [SerializeField] private Transform _handSelector;

    [SerializeField] private Transform _fingertip;
    //should highlight the bubble on selected
    [SerializeField] private Material _highlightMaterial;
    [SerializeField] private Material _activatedMaterial;
    [SerializeField] private Material _defaultMaterial;
    [SerializeField] Renderer _renderer;
    [SerializeField] private ParticleSystem _particleSystem;
    private Line line;
    private bool _isSelected = false;
    private Rigidbody _rigidbody;
    
    public bool _isSelectable = false;
    public bool _isActivated = false;
    
    private void Start()
    {
        //_renderer = GetComponent<Renderer>();
        _renderer.material = _defaultMaterial;
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    public void SetSelectable(bool state) //gets called after releaseing the bubble
    {
        _isSelectable = state;
    }
    
    public void SelectBubble()
    {
        if (_isSelectable)
        {
            _isSelected = true;
            _renderer.material = _highlightMaterial;
        }else
        {
            Debug.Log("Bubble not selectable");
            DeselectBubble();
        }
        
    }

    public void PlayParticle()
    {
        if (_particleSystem != null)
        {
            _particleSystem.Play();
        }
    }
    public void ActivateBubble()
    {
        _isActivated = true;
        _renderer.material = _activatedMaterial;
        
        //create a line between the bubble and the hand
        LineManager lineManager = FindObjectOfType<LineManager>();
        line = new Line();
        
        line = lineManager.CreateLine(transform, _fingertip);
    }
    
    public void DeActivateBubble()
    {
        _isActivated = false;
        _renderer.material = _defaultMaterial;
        
        //destroy the line
        if (line != null)
        {
            LineManager lineManager = FindObjectOfType<LineManager>();
            lineManager.RemoveLine(line);
            line.DestroyLine();
        }
        line = null;
        DeselectBubble();
    }
    
    public void SetLineEndPoint(Transform endPoint)
    {
        if (line != null)
        {
            line.SetEndPoint(endPoint);
            Debug.Log("set endpoint line");
            //set line to null so we cannot delete in here anymore
            line = null;
        }
    }
    
    
    public void DeselectBubble()
    {
        
        _isSelected = false;
        _renderer.material = _defaultMaterial;
    }
    
    // When the bubble is selected it should float towards the left hand

    private void FloatTowardsHand(Transform handTransform)
    {
        float distanceToHand = Vector3.Distance(handTransform.position, transform.position);
        //add a force to the rigidbody so it floats towards the hand
        if (handTransform != null && distanceToHand > 0.1f)
        {
            Vector3 direction = (handTransform.position - transform.position).normalized;
            _rigidbody.AddForce(direction * 0.8f, ForceMode.Force);
            Debug.Log("Floating towards hand");
        }
    }
    
    
    
    
    private void Update()
    {
        if (_isSelected)
        {
            FloatTowardsHand(_handSelector);
        }
    }

}
