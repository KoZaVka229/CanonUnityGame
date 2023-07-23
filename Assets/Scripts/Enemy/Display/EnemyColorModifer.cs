using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class EnemyColorModifer : MonoBehaviour
{
    [SerializeField] private Gradient _gradient;
    [SerializeField] private SpriteRenderer _sprite;

    private EnemyHealth _health;

    private void Awake()
    {
        _health = GetComponent<EnemyHealth>();
    }

    private void OnEnable() {
        _health.HealthChanged += HealthChangedHandler;
    }

    private void OnDisable() {
        _health.HealthChanged -= HealthChangedHandler;
    }

    private void HealthChangedHandler(int health) {
        _sprite.color = _gradient.Evaluate((float)health / (float)_health.MaxHealth);
    }
}
