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
            AudioSource audioMixer = button.GetComponent<AudioSource>();

            if (audioMixer != null)
                audioMixer.Stop();
        }
    }

    private void StartMusic(Button btn)
    {
        StopAllMusic();
        AudioSource audioMixer = btn.GetComponent<AudioSource>();

        if (audioMixer != null)
            audioMixer.Play();
    }

    private void SetVolume(float value)
    {
        foreach (var button in _musicButtons)
        {
            AudioSource audioMixer = button.GetComponent<AudioSource>();

            if (audioMixer != null)
                audioMixer.volume = value;
        }
    }
}
