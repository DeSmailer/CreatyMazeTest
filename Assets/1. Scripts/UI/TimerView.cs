using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private Timer _timer;

    private void Update()
    {
        Display();
    }

    public void Display()
    {
        float t = _timer.TimeLeft;
        string minutes = ((int)t / 60).ToString("00");
        string seconds = (t % 60).ToString("00");
        //string milliseconds = ((int)(t * 1000) % 1000).ToString("00");
        _timerText.text = minutes + ":" + seconds/* + ":" + milliseconds*/;
    }
}
