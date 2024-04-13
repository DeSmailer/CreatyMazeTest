using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private KeysCountUI _keysCountUI;

    public void Restart()
    {
        _keysCountUI.Display();
    }
}
