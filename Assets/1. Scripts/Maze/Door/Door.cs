using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private const string OPEN_ANIMATION = "open";
    //[SerializeField] private DoorController _doorController;
    [SerializeField] private WinZone _winZone;

    public WinZone WinZone => _winZone;

    public void Initialize(KeyManager keyManager)
    {
        //_doorController.CloseDoor();
        keyManager.OnAllKeysPicked.AddListener(Open);
    }

    public void Open()
    {
        //_doorController.OpenDoor();
        _animator.Play(OPEN_ANIMATION);
    }

}