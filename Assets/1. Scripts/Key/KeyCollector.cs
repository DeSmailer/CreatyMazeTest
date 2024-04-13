using UnityEngine;

public class KeyCollector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ICollectable>() is ICollectable collectable)
        {
            collectable.Collect();
        }
    }
}
