using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyManager : MonoBehaviour
{
    public int keysPicked = 0;
    public int keysToSpawn = 4;

    [SerializeField] private KeySpawner _keySpawner;

    private List<Key> _keys;

    public UnityEvent OnChangeKeysPickedCount;
    public UnityEvent OnAllKeysPicked;

    public void Respawn(Maze maze)
    {
        _keySpawner.Clear();
        keysPicked = 0;

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
        keysPicked++;
        OnChangeKeysPickedCount?.Invoke();
        Debug.Log("OnChangeKeysPickedCount " + keysPicked);

        if (keysPicked == keysToSpawn)
        {
            OnAllKeysPicked?.Invoke();
            Debug.Log("OnAllKeysPicked " + keysPicked);
        }
    }
}
