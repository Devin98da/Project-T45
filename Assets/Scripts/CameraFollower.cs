using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = _playerTransform.position + new Vector3(0,2f,-16f);
    }
}
