using UnityEngine;

public class PlayerPositionSetter : MonoBehaviour
{
    [SerializeField] private Transform _player;

    public void SetPosition()
    {
        _player.position = transform.position;
        _player.rotation = transform.rotation;
    }
}
