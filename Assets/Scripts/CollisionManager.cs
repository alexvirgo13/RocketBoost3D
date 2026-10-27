using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] private AudioClip explosionAudioClip;
    [SerializeField] private AudioClip landingAudioClip;

    [Header("Particle Systems")]
    [SerializeField] private ParticleSystem explosionParticles;
    [SerializeField] private ParticleSystem landingParticles;

    AudioSource audioSource;
    PlayerMovement movement;

    bool isControllable = true;

    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        movement = GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isControllable) switch (collision.gameObject.tag)
        {
            case "LaunchPad":

                break;
            case "LandingPad":
                ManageCollision(landingAudioClip, landingParticles);
                break;
            case "Explosion":
                ManageCollision(explosionAudioClip, explosionParticles);
                break;
            default:
                break;
        }
        else
        {
            return;
        }
    }

    private void ManageCollision (AudioClip audioClip, ParticleSystem particles)
    {
        isControllable = false;
        movement.StopMovement();
        audioSource.Stop();

        audioSource.PlayOneShot(audioClip);
        particles.Play();
    }
}
