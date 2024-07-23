using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenuMusic : MonoBehaviour
{
    [SerializeField] private Button _onOffMusic;
    [SerializeField] private BackgroundMusicManager _backgroundMusicManager;
    [SerializeField] private ButtonMusicManager _buttonMusicManager;
    [SerializeField] private Scrollbar _totalVolumeScroll;
    [SerializeField] private AudioMixerGroup _audioMixerGroup;

    private bool _isPlaying = true;
    private string _audioMixerName = "MasterVolume";
    private int _maxVolume = 0;
    private int _minVolume = -80;

    private void Awake()
    {
        _onOffMusic.onClick.AddListener(OnOffAllMusic);
        _totalVolumeScroll.onValueChanged.AddListener(SetTotalVolume);
    }

    private void OnOffAllMusic()
    {
        if (_isPlaying)
        {
            _audioMixerGroup.audioMixer.SetFloat(_audioMixerName, _minVolume);
            _isPlaying = false;
        }
        else
        {
            _audioMixerGroup.audioMixer.SetFloat(_audioMixerName, _maxVolume);
            _isPlaying = true;
        }
            
    }

    private void SetTotalVolume(float value)
        => _audioMixerGroup.audioMixer.SetFloat(_audioMixerName, Mathf.Log10(value) * 20);
}
