using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody _rBody;


    void Start()
    {
        _rBody = GetComponent<Rigidbody>();    
    }

    void Update()
    {
        ApplyThrust();

        ApplyRotation();
    }

    private static void ApplyRotation()
    {
        if (Input.GetKey(KeyCode.D))
        {
            
        }
        else if (Input.GetKey(KeyCode.A))
        {
        }
    }

    private void ApplyThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rBody.AddRelativeForce(Vector3.up);
        }
    }
} // class
