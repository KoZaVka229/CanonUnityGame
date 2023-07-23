using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyPrefab;

    [Header("Spawn settings")]
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _spawnZoneSize;
    [SerializeField] private float _spawnTimeout;
    [SerializeField] private float _enemyStartForce = 1;
    [Min(1)] [SerializeField] private int _minEnemyHealth;
    [SerializeField] private int _maxEnemyHealth;


    public EnemyHealth Spawn() {
        Vector3 position = _spawnPoint.position;
        position.x += Random.Range(-_spawnZoneSize, _spawnZoneSize);

        EnemyHealth newEnemy = Instantiate(_enemyPrefab, transform);
        newEnemy.MaxHealth = _maxEnemyHealth;
        newEnemy.Health = Random.Range(_minEnemyHealth, _maxEnemyHealth);
        newEnemy.transform.position = position;

        Vector2 direction = Random.onUnitSphere;
        Rigidbody2D rigidbody = newEnemy.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(direction * _enemyStartForce, ForceMode2D.Impulse);

        return newEnemy;
    }

    private IEnumerator EnemySpawn() {
        while (true) {
            Spawn();
            yield return new WaitForSeconds(_spawnTimeout);
        }
    }

    private void Start() {
        StartCoroutine(EnemySpawn());
    }

    private void OnDrawGizmos() {
        Vector3 spawnZone = Vector3.right * _spawnZoneSize;

        Gizmos.DrawLine(transform.position - spawnZone, transform.position + spawnZone);
    }
}
