using TMPro;
using UnityEngine;

public class KeysCountUI : MonoBehaviour
{
    [SerializeField] private KeyManager _keyManager;
    [SerializeField] private TMP_Text keysCountText;

    private void Awake()
    {
        _keyManager.OnChangeKeysPickedCount.AddListener(Display);
    }

    public void Display()
    {
        keysCountText.text = $"{_keyManager.keysPicked} / {_keyManager.keysToSpawn} ";
    }
}
