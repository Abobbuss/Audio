using UnityEngine;
using UnityEngine.UI;

public class MainMenuMusic : MonoBehaviour
{
    [SerializeField] private Button _onOffMusic;
    [SerializeField] private BackgroundMusicManager _backgroundMusicManager;
    [SerializeField] private ButtonMusicManager _buttonMusicManager;
    [SerializeField] private Scrollbar _totalVolumeScroll;

    private bool _isPlaying = true;

    private void Awake()
    {
        _onOffMusic.onClick.AddListener(OnOffAllMusic);
        _totalVolumeScroll.onValueChanged.AddListener(SetTotalVolume);
    }

    private void OnOffAllMusic()
    {
        if (_isPlaying)
        {
            _buttonMusicManager.StopAllMusic();
            _backgroundMusicManager.StopMusic();
            _isPlaying = false;
        }
        else
        {
            _backgroundMusicManager.PlayMusic();
            _isPlaying = true;
        }
    }

    private void SetTotalVolume(float value) =>
        AudioListener.volume = value;
}
