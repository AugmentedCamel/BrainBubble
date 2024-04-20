using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 3f;
    public bool isFollowing = true;

    private void FixedUpdate()
    {
        if (_target != null)
        {
            if (isFollowing)
            {
                transform.position = Vector3.Lerp(transform.position, _target.position, _speed * Time.fixedDeltaTime);
                transform.rotation =
                    Quaternion.Lerp(transform.rotation, _target.rotation, _speed * Time.fixedDeltaTime);
            }
        }
    }
}
