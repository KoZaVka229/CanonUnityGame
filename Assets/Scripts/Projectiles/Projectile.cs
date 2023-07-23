using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D other) {
        /* OPTIMIZE IT PLS !!!!! */
        if (other.attachedRigidbody && other.attachedRigidbody.gameObject.TryGetComponent(out EnemyHealth enemy)) {
            enemy.GiveDamage(_damage);
            Destroy(gameObject);
        }
    }
}