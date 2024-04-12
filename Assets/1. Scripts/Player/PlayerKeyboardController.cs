using UnityEngine;

public class PlayerKeyboardController : MonoBehaviour
{
    public float _speed = 15;

    private Rigidbody _rgb;

    private void Start()
    {
        _rgb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rgb.velocity = Vector2.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
            _rgb.velocity += Vector3.left * _speed;
        if (Input.GetKey(KeyCode.RightArrow))
            _rgb.velocity += Vector3.right * _speed;
        if (Input.GetKey(KeyCode.UpArrow))
            _rgb.velocity += Vector3.forward * _speed;
        if (Input.GetKey(KeyCode.DownArrow))
            _rgb.velocity += Vector3.back * _speed;
    }
}
