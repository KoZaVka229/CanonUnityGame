using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{   
    [SerializeField] private float _moveTrajectorySize;
    [SerializeField] private float _speed;

    public delegate void AxisMoveHandler(float axisStep);
    public event AxisMoveHandler HorizontalMoving;

    private Rigidbody2D _rb;
    private GameInput _input;
    private float _startX;

    public void HorizontalMove(float step) {
        HorizontalMoving?.Invoke(step);

        Vector3 stepVector = Vector3.right * step * _speed * Time.deltaTime;

        Vector3 newPosition = ClampPosition(transform.position + stepVector);
        _rb.MovePosition(newPosition);
    }

    private Vector3 ClampPosition(Vector3 position) {
        position.x = Mathf.Clamp(position.x,
                                _startX - _moveTrajectorySize,
                                _startX + _moveTrajectorySize);
        return position;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        _input = new GameInput();
    }

    private void Start() {
        _startX = transform.position.x;
    }

    private void FixedUpdate() {
        float axisValue = _input.Player.Move.ReadValue<float>();
        HorizontalMove(axisValue);
    }   

    private void OnEnable() {
        _input.Enable();
    }

    private void OnDisable() {
        _input.Disable();
    }

    private void OnDrawGizmos() {
        Vector2 trajectory = Vector2.right * _moveTrajectorySize;

        float x = transform.position.x;
        if (Application.IsPlaying(gameObject)) {
            x = _startX;
        }
        
        Vector2 point = new Vector2(x, transform.position.y);

        Gizmos.DrawLine(point - trajectory, point + trajectory);
    }
}
