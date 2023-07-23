using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class EnemyParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem _dieParticles;

    private EnemyHealth _enemyHealth;

    private void Awake() {
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    private void OnEnable() {
        _enemyHealth.Die += EnemyDieHandler;
    }

    private void OnDisable() {
        _enemyHealth.Die -= EnemyDieHandler;
    }

    private void EnemyDieHandler() {
        ParticleSystem dieParticles = Instantiate(_dieParticles, transform.position, Quaternion.identity);
        dieParticles.Play();
    }
}
