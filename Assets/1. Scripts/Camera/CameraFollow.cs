using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothSpeed = 0.125f;

    private Vector3 _locationOffset;
    private Vector3 _rotationOffset;

    private void Start()
    {
        _locationOffset = transform.position;
        _rotationOffset = transform.rotation.eulerAngles;
    }

    void FixedUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 desiredPosition = _target.position + _target.rotation * _locationOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
        transform.position = smoothedPosition;

        Quaternion desiredrotation = _target.rotation * Quaternion.Euler(_rotationOffset);
        Quaternion smoothedrotation = Quaternion.Lerp(transform.rotation, desiredrotation, _smoothSpeed);
        transform.rotation = smoothedrotation;
    }
}