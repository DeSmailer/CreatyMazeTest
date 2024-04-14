using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private const string OPEN_ANIMATION = "open";

    public void Initialize(KeyManager keyManager)
    {
        keyManager.OnAllKeysPicked.AddListener(Open);
    }

    public void Open()
    {
        _animator.Play(OPEN_ANIMATION);
    }
}
