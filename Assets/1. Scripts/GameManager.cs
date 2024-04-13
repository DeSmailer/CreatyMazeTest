using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MazeSpawner _mazeSpawner;
    [SerializeField] private KeySpawner _keySpawner;

    [SerializeField] private PlayerPositionSetter _playerPositionSetter ;



    private void Start()
    {
        StartLevel();
    }

    public void StartLevel()
    {
        _mazeSpawner.ClearMaze();
        _mazeSpawner.Spawn();

        _keySpawner.Clear();
        _keySpawner.Spawn(_mazeSpawner.maze, 4);

        _playerPositionSetter.SetPosition();
    }
}

