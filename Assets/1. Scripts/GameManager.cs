using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MazeSpawner _mazeSpawner;
    [SerializeField] private KeyManager _keyManager;
    [SerializeField] private PlayerPositionSetter _playerPositionSetter;
    [SerializeField] private Timer _timer;
    [SerializeField] private UI _UI;

    private void Start()
    {
        StartLevel();
    }

    public void StartLevel()
    {
        _mazeSpawner.Respawn();

        _keyManager.Respawn(_mazeSpawner.Maze);
        _mazeSpawner.Door.Initialize(_keyManager);

        _playerPositionSetter.SetPosition();

        _timer.RestartTimer();

        _UI.Restart();
    }
}

