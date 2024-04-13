using UnityEngine;

public class PlayerKeyboardController : MonoBehaviour
{
    [SerializeField] private PlayerMove _playerMove;
    private void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _playerMove.Move(moveDirection.z);
        Debug.Log(moveDirection.z);
        _playerMove.Rotate(moveDirection.x);
    }
}
