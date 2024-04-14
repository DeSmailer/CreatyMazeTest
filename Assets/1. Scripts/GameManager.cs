using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MazeSpawner _mazeSpawner;
    [SerializeField] private KeyManager _keyManager;
    [SerializeField] private PlayerPositionSetter _playerPositionSetter;
    [SerializeField] private Timer _timer;
    [SerializeField] private UI _UI;

    [SerializeField] private WinLoseChecker _winLoseChecker;

    private void Awake()
    {
        _winLoseChecker.OnWin.AddListener(OnWinHandler);
        _winLoseChecker.OnLose.AddListener(OnLoseHandler);
    }

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

        _winLoseChecker.Restart(_mazeSpawner.Door.WinZone);

        _UI.Restart();
    }

    private void OnWinHandler()
    {
        _UI.WinLoseWindow.ShowWinWindow();
    }

    private void OnLoseHandler()
    {
        _UI.WinLoseWindow.ShowLoseWindow();
    }
}

