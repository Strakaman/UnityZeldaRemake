using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public enum AudioChannel { Master, Sfx, Music };

    public float masterVolumePercent { get; private set; }
    public float sfxVolumePercent { get; private set; }
    public float musicVolumePercent { get; private set; }

    AudioSource _sfx2DSource;
    AudioSource[] _musicSources;
    int _activeMusicSourceIndex;

    public static AudioManager instance;

    Transform _audioListener;
    Transform _playerT;

    SoundLibrary _library;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {

            instance = this;
            DontDestroyOnLoad(gameObject);

            _library = GetComponentInChildren<SoundLibrary>();

            _musicSources = new AudioSource[2];
            for (int i = 0; i < 2; i++)
            {
                GameObject newMusicSource = new GameObject("Music source " + (i + 1));
                _musicSources[i] = newMusicSource.AddComponent<AudioSource>();
                _musicSources[i].loop = true;
                newMusicSource.transform.parent = transform;
            }
            GameObject newSfx2Dsource = new GameObject("2D sfx source");
            _sfx2DSource = newSfx2Dsource.AddComponent<AudioSource>();
            newSfx2Dsource.transform.parent = transform;

            _audioListener = GetComponentInChildren<AudioListener>().transform;
            if (FindObjectOfType<Player>() != null)
            {
                _playerT = FindObjectOfType<Player>().transform;
            }

            masterVolumePercent = PlayerPrefs.GetFloat("master vol", 1);
            sfxVolumePercent = PlayerPrefs.GetFloat("sfx vol", 1);
            musicVolumePercent = PlayerPrefs.GetFloat("music vol", 1);
        }
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (_playerT == null)
        {
            if (FindObjectOfType<Player>() != null)
            {
                _playerT = FindObjectOfType<Player>().transform;
            }
        }
    }

    void Update()
    {
        if (_playerT != null)
        {
            _audioListener.position = _playerT.position;
        }
    }

    public void SetVolume(float volumePercent, AudioChannel channel)
    {
        switch (channel)
        {
            case AudioChannel.Master:
                masterVolumePercent = volumePercent;
                break;
            case AudioChannel.Sfx:
                sfxVolumePercent = volumePercent;
                break;
            case AudioChannel.Music:
                musicVolumePercent = volumePercent;
                break;
        }

        _musicSources[0].volume = musicVolumePercent * masterVolumePercent;
        _musicSources[1].volume = musicVolumePercent * masterVolumePercent;

        PlayerPrefs.SetFloat("master vol", masterVolumePercent);
        PlayerPrefs.SetFloat("sfx vol", sfxVolumePercent);
        PlayerPrefs.SetFloat("music vol", musicVolumePercent);
        PlayerPrefs.Save();
    }

    public void PlayMusic(AudioClip clip, float fadeDuration = 1)
    {
        _activeMusicSourceIndex = 1 - _activeMusicSourceIndex;
        _musicSources[_activeMusicSourceIndex].clip = clip;
        _musicSources[_activeMusicSourceIndex].Play();

        StartCoroutine(AnimateMusicCrossfade(fadeDuration));
    }

    public void PlaySound(AudioClip clip, Vector3 pos)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, pos, sfxVolumePercent * masterVolumePercent);
        }
    }

    public void PlaySound(SoundClipType soundtype, Vector3 pos)
    {
        PlaySound(_library.GetClipFromName(soundtype), pos);
    }

    public void PlaySound2D(SoundClipType soundtype)
    {
        _sfx2DSource.PlayOneShot(_library.GetClipFromName(soundtype), sfxVolumePercent * masterVolumePercent);
    }

    IEnumerator AnimateMusicCrossfade(float duration)
    {
        float percent = 0;

        while (percent < 1)
        {
            percent += Time.deltaTime * 1 / duration;
            _musicSources[_activeMusicSourceIndex].volume = Mathf.Lerp(0, musicVolumePercent * masterVolumePercent, percent);
            _musicSources[1 - _activeMusicSourceIndex].volume = Mathf.Lerp(musicVolumePercent * masterVolumePercent, 0, percent);
            yield return null;
        }
    }
}
