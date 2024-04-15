using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private const string OPEN_ANIMATION = "open";

    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private WinZone _winZone;

    public WinZone WinZone => _winZone;

    public void Initialize(KeyManager keyManager)
    {
        keyManager.OnAllKeysPicked.AddListener(Open);
    }

    public void Open()
    {
        _animator.Play(OPEN_ANIMATION);
        _audioSource.Play();
    }
}