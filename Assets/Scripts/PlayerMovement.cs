using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [Header("Input Actions")]
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotate;
    
    [Header("Movement Settings")]
    [SerializeField] float moveForce = 10.0f;
    [SerializeField] float rotationForce = 2.5f;
    
    [Header("Particle Systems")]
    [SerializeField] private ParticleSystem thrustParticles;
    [SerializeField] private ParticleSystem leftThrustParticles;
    [SerializeField] private ParticleSystem rightThrustParticles;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip thrustAudioClip;

    AudioSource audioSource;
    Rigidbody rb;

    bool isControllable = true;

    void OnEnable ()
    {
        thrust.Enable();
        rotate.Enable();
    }

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust ()
    {
        if(isControllable)
        {
            if (thrust.IsPressed())
            {
                StartThrusting();
            }
            else
            {
                StopThrusting();
            }
        }
        else
        {

        }
    }

    private void ProcessRotation ()
    {
        if (isControllable)
        {
            rb.freezeRotation = true; //Freezing rotation so we can rotate manually

            float rotationValue = rotate.ReadValue<float>();

            if (rotationValue < 0)
            {
                RotateRight();
            }
            else if (rotationValue > 0) 
            {
                RotateLeft();
            }
            else{
                StopRotation();
            }
        }
        else
        {
            return;
        }
    }

    private void StopThrusting ()
    {
        //TODO: Stop particles and sounds
        audioSource.Stop();
        thrustParticles.Stop();
    }

    private void StartThrusting ()
    {
        //TODO: Activate particles and sounds
        rb.AddRelativeForce(Vector3.up * moveForce);

        if (!thrustParticles.isPlaying) {
            thrustParticles.Play();
        }
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(thrustAudioClip);

    }

    private void RotateRight ()
    {
        transform.Rotate(Vector3.forward * rotationForce);
        if (!leftThrustParticles.isPlaying)
            leftThrustParticles.Play();

    }

    private void RotateLeft ()
    {
        transform.Rotate(Vector3.back * rotationForce);
        if(rightThrustParticles.isPlaying)
            rightThrustParticles.Play();

    }

    private void StopRotation ()
    {
        //TODO: Stop particles and sounds
        thrustParticles.Stop();
        leftThrustParticles.Stop();
        rightThrustParticles.Stop();
    }

    public void StopMovement()
    {
        isControllable = false;
        rb.freezeRotation = false;
        //rb.freezePosition = false; //TODO: This mess
    }
}
