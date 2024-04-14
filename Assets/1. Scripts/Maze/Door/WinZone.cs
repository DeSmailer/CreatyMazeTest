using UnityEngine;
using UnityEngine.Events;

public class WinZone : MonoBehaviour
{
    public UnityEvent OnWin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            OnWin?.Invoke();
            //FindFirstObjectByType<WinLoseWindow>().ShowWinWindow();
            //Debug.Log("+");
        }
    }
}
