using UnityEngine;

public class ProjectileOnClick : MonoBehaviour
{
    [SerializeField] private Projectile _projectile;    

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            clickPosition.z = 0;
            Instantiate(_projectile, clickPosition, Quaternion.identity); 
        }
    }
}
