using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private Rigidbody _rigidbody;
    
    public bool isFollowing = true;
    private bool _isKinematic;
    private void FixedUpdate()
    {
        if (_target != null)
        {
            if (isFollowing)
            {
                if (!_rigidbody.isKinematic)
                {
                    toggleRigidbody(true);
                }
                
                transform.position = Vector3.Lerp(transform.position, _target.position, _speed * Time.fixedDeltaTime);
                transform.rotation =
                    Quaternion.Lerp(transform.rotation, _target.rotation, _speed * Time.fixedDeltaTime);
            }
            else
            {
                if (_rigidbody.isKinematic)
                {
                    toggleRigidbody(false);
                }
            }
        }
    }
    
    private void toggleRigidbody(bool state)
    {
        _rigidbody.isKinematic = state;
    }
}
