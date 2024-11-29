using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private const string PLAYER_PREFS_MUSIC_VOLUME = "MusicVolume";

    public static MusicManager Instance { get; private set; }

    private AudioSource _audioSource;
    private float _volume = .5f;

    private void Awake()
    {
        Instance = this;

        _audioSource = GetComponent<AudioSource>();

        _volume = PlayerPrefs.GetFloat(PLAYER_PREFS_MUSIC_VOLUME, .5f);
        _audioSource.volume = _volume;
    }

    public float GetVolume()
    {
        return _volume;
    }

    public void ChangeVolume()
    {
        _volume += .1f;

        if (_volume > 1.1f)
        {
            _volume = 0f;
        }

        _audioSource.volume = _volume;

        PlayerPrefs.SetFloat(PLAYER_PREFS_MUSIC_VOLUME, _volume);
        PlayerPrefs.Save();
    }
}
