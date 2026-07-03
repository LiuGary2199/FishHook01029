using UnityEngine;
using System.Collections.Generic;
using Lofelt.NiceVibrations;

public class A_HavenEarning : MonoBehaviour
{
    public static A_HavenEarning Slowness{ get; private set; }
[UnityEngine.Serialization.FormerlySerializedAs("DefaultButtonSound")]    
    public AudioClip AscribeAlpineEnjoy;
[UnityEngine.Serialization.FormerlySerializedAs("DefaultBGM")]    public AudioClip AscribeBGM;
[UnityEngine.Serialization.FormerlySerializedAs("Audios")]    public List<AudioClip> Tongue= new List<AudioClip>();
    // 音乐音频源
    private AudioSource AngloHavenEstate;
    // 音效音频源池
    private List<AudioSource> EnjoyHavenAdviser= new List<AudioSource>();
[UnityEngine.Serialization.FormerlySerializedAs("SoundPoolSize")]    // 音效音频源数量
    public int EnjoyErieAbut= 5;
[UnityEngine.Serialization.FormerlySerializedAs("isMusicOn")]
    // 音乐开关
    public bool AtExtolAn= true;
[UnityEngine.Serialization.FormerlySerializedAs("isSoundOn")]    // 音效开关
    public bool AtEnjoyAn= true;

    private void Awake()
    {
        Slowness = this;

        AtExtolAn = PlayerPrefs.GetInt(AConserve.ArchiveKey.BGMWarfare, 1) == 1;
        AtEnjoyAn = PlayerPrefs.GetInt(AConserve.ArchiveKey.EnjoyWarfare, 1) == 1;

        // 初始化音乐音频源
        AngloHavenEstate = gameObject.AddComponent<AudioSource>();
        AngloHavenEstate.playOnAwake = false;
        AngloHavenEstate.loop = true;

        // 初始化音效音频源池
        for (int i = 0; i < EnjoyErieAbut; i++)
        {
            AudioSource SoundSource = gameObject.AddComponent<AudioSource>();
            SoundSource.playOnAwake = false;
            EnjoyHavenAdviser.Add(SoundSource);
        }

        BulkBGM();
        
        var isShake = PlayerPrefs.GetInt(AConserve.ArchiveKey.LocomotorWarfare, 1) == 1;
        // 切换震动状态
        HapticController.hapticsEnabled = isShake;
    }

    // 切换音乐开关状态
    public void HeliumExtol()
    {
        AtExtolAn = !AtExtolAn;
        if (AtExtolAn)
        {
            if (AngloHavenEstate.clip == null && AscribeBGM != null)
                AngloHavenEstate.clip = AscribeBGM;
            if (AngloHavenEstate.clip != null && !AngloHavenEstate.isPlaying)
            {
                AngloHavenEstate.Play();
            }
        }
        else
        {
            AngloHavenEstate.Pause();
        }
    }

    // 切换音效开关状态
    public void HeliumEnjoy()
    {
        AtEnjoyAn = !AtEnjoyAn;
    }

    // 播放音乐
    public void BulkExtol(string name, float volume = 1f)
    {
        if (!AtExtolAn) return;

        AudioClip musicClip = JobHavenBook(name);
        if (musicClip != null)
        {
            AngloHavenEstate.clip = musicClip;
            AngloHavenEstate.volume = volume;
            AngloHavenEstate.Play();
        }
    }
    
    public void BulkBGM()
    {
        if (!AtExtolAn) return;

        if (AscribeBGM != null)
        {
            AngloHavenEstate.clip = AscribeBGM;
            AngloHavenEstate.volume = 1f;
            AngloHavenEstate.Play();
        }
    }

    public void BulkAscribeAlpineEnjoy()
    {
        if (!AtEnjoyAn) return;

        AudioClip SoundClip = AscribeAlpineEnjoy;
        if (SoundClip != null)
        {
            foreach (AudioSource SoundSource in EnjoyHavenAdviser)
            {
                if (!SoundSource.isPlaying)
                {
                    SoundSource.clip = SoundClip;
                    SoundSource.volume = 1f;
                    SoundSource.Play();
                    return;
                }
            }
            // 如果所有音效源都在使用，可以动态创建新的音频源（这只是简单示例，实际可能需要更好的管理策略）
            AudioSource newSoundSource = gameObject.AddComponent<AudioSource>();
            newSoundSource.playOnAwake = false;
            EnjoyHavenAdviser.Add(newSoundSource);
            newSoundSource.clip = SoundClip;
            newSoundSource.Play();
        }
    }

    // 播放音效
    public void BulkEnjoy(string name, float volume = 1f)
    {
        if (!AtEnjoyAn) return;

        AudioClip SoundClip = JobHavenBook(name);
        if (SoundClip != null)
        {
            foreach (AudioSource SoundSource in EnjoyHavenAdviser)
            {
                if (!SoundSource.isPlaying)
                {
                    SoundSource.clip = SoundClip;
                    SoundSource.volume = volume;
                    SoundSource.Play();
                    return;
                }
            }
            // 如果所有音效源都在使用，可以动态创建新的音频源（这只是简单示例，实际可能需要更好的管理策略）
            AudioSource newSoundSource = gameObject.AddComponent<AudioSource>();
            newSoundSource.playOnAwake = false;
            EnjoyHavenAdviser.Add(newSoundSource);
            newSoundSource.clip = SoundClip;
            newSoundSource.Play();
        }
    }

    private AudioClip JobHavenBook(string name)
    {
        foreach (var clip in Tongue)
        {
            if (clip.name == name)
            {
                return clip;
            }
        }
        return null;
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt(AConserve.ArchiveKey.BGMWarfare, AtExtolAn ? 1 : 0);
        PlayerPrefs.SetInt(AConserve.ArchiveKey.EnjoyWarfare, AtEnjoyAn ? 1 : 0);
    }
}