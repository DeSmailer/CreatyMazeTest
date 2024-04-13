using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private Vector3 _rotationSpeed = new Vector3(0, 170, 0);

    private Rigidbody _rgb;

    private void Start()
    {
        _rgb = GetComponent<Rigidbody>();
    }

    public void Move(float speedCoefficient)
    {
        Debug.Log("speedCoefficient " + speedCoefficient);
        _rgb.velocity = transform.forward * _speed * speedCoefficient;
    }

    public void Rotate(float rotationCoefficient)
    {
        Quaternion deltaRotation = Quaternion.Euler(_rotationSpeed * rotationCoefficient);
        _rgb.MoveRotation(_rgb.rotation * deltaRotation);
    }
}
