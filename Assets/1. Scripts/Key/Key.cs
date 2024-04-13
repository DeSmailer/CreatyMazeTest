using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour, ICollectable
{
    public UnityEvent OnCollect;

    public void Collect()
    {
        OnCollect?.Invoke();

        Debug.Log("Collected");

        Destroy(gameObject);
    }
}
