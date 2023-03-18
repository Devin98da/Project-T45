using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Rocket : MonoBehaviour
{
    private Rigidbody _rBody;
    [SerializeField] private float _thrustPower = 10f;
    [SerializeField] private float _rotationPower = 20f;
    [SerializeField] private AudioClip _thrustSound;
    [SerializeField] private AudioClip _hitSound;
    [SerializeField] private AudioClip _winSound;
    [SerializeField] private float _levelLoadDelay = 2f;

    [SerializeField] private ParticleSystem _thrustParticle;
    [SerializeField] private ParticleSystem _winParticle;
    [SerializeField] private ParticleSystem _damageParticle;
    [SerializeField] private int _fuelCount = 100;

    [SerializeField] private TextMeshProUGUI _fuelText;

    private AudioSource _audioSource;

    enum State { ALIVE, DIYING, TRASENDING};
    State currentState = State.ALIVE;

    void Start()
    {
        _rBody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(currentState == State.ALIVE)
        {
            ApplyThrust();

            ApplyRotation();
        }

    }

    private void ApplyThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rBody.AddRelativeForce(Vector3.up * _thrustPower * Time.deltaTime);
            if (!_audioSource.isPlaying)
            {
                _audioSource.PlayOneShot(_thrustSound);
            }
            _thrustParticle.Play();
            FuelControl();
        }
        else
        {
            _audioSource.Stop();
            _thrustParticle.Stop();
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
                NextLevelSequence();
                break;
            case "Obstacle":
                PreviousLevelSequence();
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Fuel")
        {
            AddFuel();
            Destroy(other.gameObject);
            // play fule collect sound - to do
        }
    }

    private void PreviousLevelSequence()
    {
        currentState = State.DIYING;
        _audioSource.Stop();
        _audioSource.PlayOneShot(_hitSound);
        _damageParticle.Play();
        Invoke("LoadPreviousLevel", _levelLoadDelay);
    }

    private void NextLevelSequence()
    {
        currentState = State.TRASENDING;
        _audioSource.Stop();
        _audioSource.PlayOneShot(_winSound);
        _winParticle.Play();
        Invoke("LoadNextLevel", _levelLoadDelay);
    }

    private void LoadPreviousLevel()
    {
        SceneManager.LoadScene(0);
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void FuelControl()
    {
        _fuelCount--;
        if(_fuelCount < 0)
        {
            _fuelCount = 0;
        }
        _fuelText.text = "Fuel - " + _fuelCount.ToString();

    }

    private void AddFuel()
    {
        _fuelCount += 100;
        _fuelText.text = "Fuel - " + _fuelCount.ToString();
        // add fuel to rocket
    }

} // class
