using System.Collections;
using UnityEngine;

public class DestroyableAfterLifetime : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] [Tooltip("Lifetime in seconds")] private float _lifetime;

    public IEnumerator DestroyTimer(float seconds, ParticleSystem particles, GameObject gameObject) {
        yield return new WaitForSeconds(seconds);

        if (particles != null) {
            ParticleSystem particleSystem = Instantiate(particles, transform.position, Quaternion.identity);
            particleSystem.Play();
        }

        Destroy(gameObject);
    }

    private void Start()
    {
        StartCoroutine(DestroyTimer(_lifetime, _particles, gameObject));
    }
}
