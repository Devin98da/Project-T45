using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    private Rigidbody _rBody;
    [SerializeField] private float _thrustPower = 10f;
    [SerializeField] private float _rotationPower = 20f;
    [SerializeField] private AudioClip _thrustSound;

    private AudioSource _audioSource;

    void Start()
    {
        _rBody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ApplyThrust();

        ApplyRotation();

    }

    private void ApplyThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rBody.AddRelativeForce(Vector3.up * _thrustPower);
            if (!_audioSource.isPlaying)
            {
                _audioSource.PlayOneShot(_thrustSound);
            }
        }
        else
        {
            _audioSource.Stop();
        }
    } // Apply thrust

    private void ApplyRotation()
    {
        _rBody.freezeRotation = true;

        float rotation = _rotationPower * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotation);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotation);

        }
        _rBody.freezeRotation = false;

    } // Apply rotation

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Freindly":
                LoadNextLevel();
                break;
            case "Obstacle":
                SceneManager.LoadScene(0);
                break;
            default:
                break;
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }



} // class
