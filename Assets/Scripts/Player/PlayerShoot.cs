using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{   
    [SerializeField] private Rigidbody2D _projectile;
    [SerializeField] private float _projectileForce;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootDelay;

    public delegate void ShootHandler(Vector3 shootPoint);
    public event ShootHandler Shooted;

    private GameInput _input;

    public void Shoot() {
        Rigidbody2D newProjectile = Instantiate(_projectile);
        newProjectile.transform.position = _shootPoint.position;

        newProjectile.AddForce(_projectileForce * transform.up, ForceMode2D.Impulse);

        Shooted?.Invoke(_shootPoint.position);
    }

    private IEnumerator ShootCoroutine() {
        while (true) {
            Shoot();
            yield return new WaitForSeconds(_shootDelay);
        }
    }

    private void Awake()
    {
        _input = new GameInput();
        
        StartCoroutine(ShootCoroutine());
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }
}