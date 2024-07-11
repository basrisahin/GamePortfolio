using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float forceMultiplier = 10f;
    [SerializeField] float rotateMultiplier = 10f;
    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessJump();
        ProcessRotation();
    }

    void ProcessJump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * forceMultiplier * Time.deltaTime , ForceMode.Impulse);
        }
        
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotateMultiplier);
        }
        
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotateMultiplier);
        }
        
    }

    void ApplyRotation(float rotationThisFrame)

    {   
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
        rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
    }
}
