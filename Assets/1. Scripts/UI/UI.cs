using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private KeysCountUI _keysCountUI;
    [SerializeField] private WinLoseWindow _winLoseWindow;

    public WinLoseWindow WinLoseWindow => _winLoseWindow;

    public void Restart()
    {
        _keysCountUI.Display();
        _winLoseWindow.Restart();
    }
}
