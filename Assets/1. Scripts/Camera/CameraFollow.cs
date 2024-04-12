using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Vector3 initalOffset;
    private Vector3 cameraPosition;

    private void Start()
    {
        initalOffset = transform.position - _target.position;
    }

    private void LateUpdate()
    {
        cameraPosition = _target.position + initalOffset;
        transform.position = cameraPosition;
    }
}
