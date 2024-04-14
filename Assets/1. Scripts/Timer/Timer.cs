using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _initialTime;
    private float _timeLeft;

    private bool isRunning = false;

    public float TimeLeft => _timeLeft;

    public UnityEvent OnTimerStart;
    public UnityEvent OnTimerRestart;
    public UnityEvent OnTimeIsOver;

    private void Update()
    {
        if (isRunning)
        {
            _timeLeft -= Time.deltaTime;
            if (_timeLeft <= 0)
            {
                _timeLeft = 0;
                OnTimeIsOver?.Invoke();
                StopTimer();
            }
        }
    }

    public void RestartTimer()
    {
        _timeLeft = _initialTime;
        OnTimerRestart?.Invoke();
        StartTimer();
    }

    public void StartTimer()
    {
        isRunning = true;
        OnTimerStart?.Invoke();
    }

    public void StopTimer()
    {
        isRunning = false;
    }
}
