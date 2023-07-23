using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class EnemyScaleModifer : MonoBehaviour
{
    [SerializeField] private float _minScale;
    [SerializeField] private float _maxScale;

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
        float step = (_maxScale - _minScale) / _health.MaxHealth;
        transform.localScale = Vector3.one * (step * health + _minScale);
    }
}