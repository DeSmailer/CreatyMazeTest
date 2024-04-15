using UnityEngine;

public class WinLoseSoundPlayer : MonoBehaviour
{
    [SerializeField] private WinLoseChecker _winLoseChecker  ;
    [SerializeField] private AudioSource _winAudioSource   ;
    [SerializeField] private AudioSource _loseAudioSource   ;

    private void Awake()
    {
        _winLoseChecker.OnLose.AddListener(OnLoseHandler);
        _winLoseChecker.OnWin.AddListener(OnWinHandler);
    }

    public void OnWinHandler()
    {
        _winAudioSource.Play();
    }

    public void OnLoseHandler()
    {
        _loseAudioSource.Play();
    }
}
