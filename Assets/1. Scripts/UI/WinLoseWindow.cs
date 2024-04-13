using UnityEngine;

public class WinLoseWindow : MonoBehaviour
{
    [SerializeField] private GameObject _winWindow;
    [SerializeField] private GameObject _loseWindow;

    public void Restart()
    {
        _winWindow.SetActive(false);
        _loseWindow.SetActive(false);
    }

    public void ShowWinWindow()
    {
        _winWindow.SetActive(true);
        Debug.Log("_winWindow");
    }

    public void ShowLoseWindow()
    {
        _loseWindow.SetActive(true);
        Debug.Log("_loseWindow");
    }
}
