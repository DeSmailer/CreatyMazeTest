using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyManager : MonoBehaviour
{
    private int _keysPicked = 0;
    public int keysToSpawn = 4;

    [SerializeField] private KeySpawner _keySpawner;

    private List<Key> _keys;

    public int KeysPicked => _keysPicked;

    public UnityEvent OnChangeKeysPickedCount;
    public UnityEvent OnAllKeysPicked;

    public void Respawn(Maze maze)
    {
        _keySpawner.Clear();
        _keysPicked = 0;

        _keys = _keySpawner.Spawn(maze, keysToSpawn);

        SubscribeToEvents();
    }

    public void SubscribeToEvents()
    {
        foreach (var key in _keys)
        {
            key.OnCollect.AddListener(ChangeKeysPickedCount);
        }
    }

    public void ChangeKeysPickedCount()
    {
        _keysPicked++;
        OnChangeKeysPickedCount?.Invoke();
        Debug.Log("OnChangeKeysPickedCount " + _keysPicked);

        if (_keysPicked == keysToSpawn)
        {
            OnAllKeysPicked?.Invoke();
            Debug.Log("OnAllKeysPicked " + _keysPicked);
        }
    }
}
