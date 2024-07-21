using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private Scrollbar _backgroundVolumeScroll;

    private void Awake() =>
        _backgroundVolumeScroll.onValueChanged.AddListener(SetVolume);

    private void SetVolume(float value) =>
        _backgroundMusic.volume = value;

    public void PlayMusic() =>
        _backgroundMusic.Play();

    public void StopMusic() =>
        _backgroundMusic.Stop();
}
