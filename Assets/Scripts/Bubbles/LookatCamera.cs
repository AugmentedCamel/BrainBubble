using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;

	private void Start()
	{
		if (_camera == null)
        {
            _camera = FindObjectOfType<Camera>();
        }
	}	


    // Start is called before the first frame update
    private void FixedUpdate()
    {
        transform.LookAt(_camera.transform.position, Vector3.up);
    }

}
