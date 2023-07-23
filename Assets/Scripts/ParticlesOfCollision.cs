using UnityEngine;

public class ParticlesOfCollision : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles; 

    private void OnCollisionEnter2D(Collision2D other) 
    {
        ParticleSystem particles = Instantiate(_particles, other.contacts[0].point, Quaternion.identity);
        particles.Play();
    }
}