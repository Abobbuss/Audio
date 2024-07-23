using UnityEngine;
using UnityEngine.UI;

public class ButtonMusicManager : MonoBehaviour
{
    [SerializeField] private Button[] _musicButtons;
    [SerializeField] private Scrollbar _buttonsVolumeScroll;

    private void Awake()
    {
        foreach (var button in _musicButtons)
            button.onClick.AddListener(() => StartMusic(button));

        _buttonsVolumeScroll.onValueChanged.AddListener(SetVolume);
    }

    public void StopAllMusic()
    {
        foreach (var button in _musicButtons)
        {
            if (button.TryGetComponent<AudioSource>(out var audioMixer))
                audioMixer.Stop();
        }
    }

    private void StartMusic(Button button)
    {
        StopAllMusic();
        
        if (button.TryGetComponent<AudioSource>(out var audioMixer))
            audioMixer.Play();
    }

    public void SetVolume(float value)
    {
        foreach (var button in _musicButtons)
        {
            if (button.TryGetComponent<AudioSource>(out var audioMixer))
                audioMixer.volume = value;
        }
    }
}
