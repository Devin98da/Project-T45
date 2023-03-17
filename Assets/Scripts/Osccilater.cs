using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Osccilater : MonoBehaviour
{
    [SerializeField] private Vector3 _movementVector = new Vector3(10f,10f,10f);
    [SerializeField] private float _period = 2f;
    [Range(0, 1)] [SerializeField] private float _movementFactor; // 0 for not move, 1 for full move
    private Vector3 _startPosition;

    void Start()
    {
        _startPosition = transform.position;
    }

    void Update()
    {
        float cycles = Time.time / _period;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(tau * cycles);

        _movementFactor = rawSinWave / 2f + 0.5f;

        Vector3 offset = _movementVector * _movementFactor;
        transform.position = _startPosition + offset;
    }
}
