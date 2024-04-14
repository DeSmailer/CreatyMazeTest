using BrokenVector.LowPolyFencePack;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private DoorController _doorController;
    [SerializeField] private WinZone _winZone;

    public WinZone WinZone => _winZone;

    public void Initialize(KeyManager keyManager)
    {
        _doorController.CloseDoor();
        keyManager.OnAllKeysPicked.AddListener(Open);
    }

    public void Open()
    {
        _doorController.OpenDoor();
    }
}