using UnityEngine;

public class KeyCollector : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ICollectable>() is ICollectable collectable)
        {
            collectable.Collect();
            _audioSource.Play();
        }
    }
}
