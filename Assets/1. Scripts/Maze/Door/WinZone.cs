using UnityEngine;

public class WinZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            FindFirstObjectByType<WinLoseWindow>().ShowWinWindow();
            Debug.Log("+");
        }
    }
}
