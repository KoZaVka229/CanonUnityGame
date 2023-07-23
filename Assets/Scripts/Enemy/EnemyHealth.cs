using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Min(1)] [SerializeField] private int _health;
    [SerializeField] private int _maxHealth = 0;

    public delegate void HealthChangedHandler(int health);
    public event HealthChangedHandler HealthChanged;

    public delegate void DieHandler();
    public event DieHandler Die;

    public int Health {
        get {
            return _health;
        }
        
        set {
            _health = Mathf.Min(_maxHealth, Mathf.Max(value, 0));
            HealthChanged?.Invoke(_health);

            if (_health == 0) Dead();
        }
    }

    public int MaxHealth {
        get {
            if (_maxHealth == 0)
                return _health;
            return _maxHealth;
        }

        set {
            _maxHealth = Mathf.Max(value, 0);
        }
    }


    public void GiveDamage(int damage) {
        Health -= damage;
    }

    public void Kill() {
        Health = 0;
    }

    private void Dead() {
        Die?.Invoke();
        Destroy(gameObject);
    }
}
