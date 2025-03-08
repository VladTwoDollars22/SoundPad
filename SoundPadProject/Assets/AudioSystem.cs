using TMPro;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    public static AudioSystem Instance { get; private set; }

    [SerializeField] private MusicData[] _musicTracks;
    [SerializeField] private TextMeshProUGUI _soundName;
    [SerializeField] private TextMeshProUGUI _soundAuthor;

    [SerializeField] private AudioSource audioSource;
    private int currentTrackIndex = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetAudioSource();

        if (_musicTracks.Length > 0)
        {
            PlayMusic(currentTrackIndex);
            audioSource.Play();
        }
    }

    public void PlayMusic(int index)
    {
        if (index >= 0 && index < _musicTracks.Length)
        {
            currentTrackIndex = index;

            bool wasPaused = !audioSource.isPlaying;

            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }

            audioSource.clip = _musicTracks[index].clip;
            UpdateTrackInfo();

            if (wasPaused)
            {
                // Оставляем музыку на паузе
                audioSource.Pause();
            }
            else
            {
                // Запускаем новый трек
                audioSource.Play();
            }
        }
    }


    public void StopMusic()
    {
        audioSource.Stop();
    }
    public void SwitchPauseState()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }
        Debug.Log(audioSource.isPlaying);
    }
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void NextTrack()
    {
        if (_musicTracks.Length == 0) return;
        currentTrackIndex = (currentTrackIndex + 1) % _musicTracks.Length;
        PlayMusic(currentTrackIndex);
    }

    public void PreviousTrack()
    {
        if (_musicTracks.Length == 0) return;
        currentTrackIndex = (currentTrackIndex - 1 + _musicTracks.Length) % _musicTracks.Length;
        PlayMusic(currentTrackIndex);
    }

    private void SetAudioSource()
    {
        AudioSource source = GetComponent<AudioSource>();

        if (source != null)
        {
            audioSource = source;
        }
        else
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void UpdateTrackInfo()
    {
        if (_soundName != null && _soundAuthor != null)
        {
            _soundName.text = _musicTracks[currentTrackIndex].musicName;
            _soundAuthor.text = _musicTracks[currentTrackIndex].author;
        }
    }
}
