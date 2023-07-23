using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private Animator _animator;

    private void Awake() {
        _playerMovement = GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable() {
        _playerMovement.HorizontalMoving += HorizontalMovingHandler;
    }
    
    private void OnDisable() {
        _playerMovement.HorizontalMoving -= HorizontalMovingHandler;
    }

    private void HorizontalMovingHandler(float axisStep) {
        bool moveToRight = (axisStep > 0);
        bool moveToLeft = (axisStep < 0);
        
        _animator.SetBool("MoveToRight", moveToRight);
        _animator.SetBool("MoveToLeft", moveToLeft);
    }
}
