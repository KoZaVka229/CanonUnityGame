using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]
public class EnemyText : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;

    private TextMeshPro _text;

    private void Awake() {
        _text = GetComponent<TextMeshPro>();   
        _text.text = _enemyHealth.Health.ToString(); 
    }

    private void OnEnable() {
        _enemyHealth.HealthChanged += HealthChangedHandler;
    }

    private void OnDisable() {
        _enemyHealth.HealthChanged -= HealthChangedHandler;
    }

    private void HealthChangedHandler(int health) {
        _text.text = health.ToString();
    }
}
