using UnityEngine;

public class PlayerJoystickController : MonoBehaviour
{
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private Joystick _joystick ;

    private void Update()
    {
        Vector3 moveDirection = new Vector3(_joystick.Direction.x, 0, _joystick.Direction.y);
        _playerMove.Move(moveDirection.z);
        _playerMove.Rotate(moveDirection.x);
    }
}
