using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
 
    public AudioMixer mixer; // 用于控制音量的音频混合器
 
    public AudioClip backgroundMusic; // 背景音乐
    public AudioClip[] soundEffects; // 游戏音效
 
    private AudioSource backgroundMusicSource;
    private AudioSource soundEffectSource;
 
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
 
    void Start()
    {
        // 创建两个音频源，一个用于播放背景音乐，一个用于播放游戏音效
        backgroundMusicSource = gameObject.AddComponent<AudioSource>();
        soundEffectSource = gameObject.AddComponent<AudioSource>();
 
        // 设置音频源的混合器和默认音量
        backgroundMusicSource.outputAudioMixerGroup = mixer.FindMatchingGroups("Music")[0];
        soundEffectSource.outputAudioMixerGroup = mixer.FindMatchingGroups("SoundEffects")[0];
        backgroundMusicSource.volume = 0.5f;
        soundEffectSource.volume = 1f;
 
        // 播放背景音乐
        PlayBackgroundMusic();
    }
 
    public void PlayBackgroundMusic()
    {
        // 播放背景音乐，并设置为循环播放
        backgroundMusicSource.clip = backgroundMusic;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
    }
 
    public void PauseBackgroundMusic()
    {
        // 暂停背景音乐
        backgroundMusicSource.Pause();
    }
 
    public void ResumeBackgroundMusic()
    {
        // 恢复背景音乐播放
        backgroundMusicSource.UnPause();
    }
 
    public void StopBackgroundMusic()
    {
        // 停止背景音乐
        backgroundMusicSource.Stop();
    }
 
    public void PlaySoundEffect(int index)
    {
        // 播放指定索引的游戏音效
        soundEffectSource.clip = soundEffects[index];
        soundEffectSource.Play();
    }
 
    public void SetVolume(string mixerGroup, float volume)
    {
        // 设置音量大小，mixerGroup指定要控制的混合器组名
        mixer.SetFloat(mixerGroup, Mathf.Log10(volume) * 20);
    }
}
