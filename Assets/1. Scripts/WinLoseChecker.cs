using UnityEngine;
using UnityEngine.Events;

//����� ����������� �������, ������� ������ ��� �������� �� ��������
public class WinLoseChecker : MonoBehaviour
{
    [SerializeField] private Timer _timer;

    public UnityEvent OnWin;
    public UnityEvent OnLose;

    private void Awake()
    {
        _timer.OnTimeIsOver.AddListener(OnLoseHandler);
    }

    public void Restart(WinZone newWinZone)
    {
        newWinZone.OnWin.AddListener(OnWinHandler);
    }

    public void OnWinHandler()
    {
        OnWin?.Invoke();
    }

    public void OnLoseHandler()
    {
        OnLose?.Invoke();
    }
}
