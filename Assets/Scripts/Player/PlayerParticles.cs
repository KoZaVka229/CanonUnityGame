using UnityEngine;

public class PlayerParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem _playerShootParticles;

    private PlayerShoot _playerShoot;

    private void Awake() {
        _playerShoot = GetComponent<PlayerShoot>();
    }

    private void OnEnable() {
        _playerShoot.Shooted += ShootedHandler;
    }

    private void OnDisable() {
        _playerShoot.Shooted -= ShootedHandler;
    }

    private void ShootedHandler(Vector3 shootPoint) {
        ParticleSystem playerShootParticles = Instantiate(_playerShootParticles, shootPoint, Quaternion.identity);
        playerShootParticles.Play();
    }
}
