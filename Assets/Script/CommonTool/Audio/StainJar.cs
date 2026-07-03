/***
 * 
 * 音乐管理器
 * 
 * **/
using LitJson;
using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Lofelt.NiceVibrations.HapticPatterns;


public class StainJar : MonoSnowstorm<StainJar>
{
    //音频组件管理队列的对象
    private AphidCanvasSteam AphidSteam;
    // 用于播放背景音乐的音乐源
    private AudioSource m_bgStain= null;
    //播放音效的音频组件管理列表
    private List<AudioSource> FoodAphidCanvasTall;
    //检查已经播放的音频组件列表中没有播放的组件的更新频率
    private float FenceUpcoming= 2f;
    //背景音乐开关
    private bool _OnStainGuinea;
    //音效开关
    private bool _AttainStainGuinea;
    //音乐音量
    private float _OnMarket= 1f;
    //音效音量
    private float _AttainMarket= 1f;
    string BGM_Coin= "";
    //震动开关
    private bool _KingdomGuinea;
    public Dictionary<string, AphidShake> AphidPrinterNear;
    private readonly Dictionary<string, AudioClip> _TellRanch= new Dictionary<string, AudioClip>();
    // 记录每个音效上次触发时间，用于短时间节流。
    private readonly Dictionary<string, float> _CandidSinkFoodLine= new Dictionary<string, float>();
    private const float AttainSituateInstance= 0.5f;

    // 控制背景音乐音量大小
    public float OnMarket    {
        get
        {
            return OnStainGuinea ? LawMarket(BGM_Coin) : 0f;
        }
        set
        {
            _OnMarket = value;
            //背景音乐开的状态下，声音随控制调节
        }
    }

    //控制音效音量的大小
    public float AttainToward    {
        get { return _AttainMarket; }
        set
        {
            _AttainMarket = value;
            DuePinAttainMarket();
        }
    }
    //控制背景音乐开关
    public bool OnStainGuinea    {
        get
        {

            _OnStainGuinea = AiryMintStrange.GetBool("_BgMusicSwitch");
            return _OnStainGuinea;
        }
        set
        {
            if (m_bgStain)
            {
                _OnStainGuinea = value;
                AiryMintStrange.SetBool("_BgMusicSwitch", _OnStainGuinea);
                m_bgStain.volume = OnMarket;
            }
        }
    }
    //控制震动开关
    public bool KingdomGuinea    {
        get
        {
            _KingdomGuinea = AiryMintStrange.GetBool("_VibrateSwitch");
            return _KingdomGuinea;
        }
        set
        {
            _KingdomGuinea = value;
            AiryMintStrange.SetBool("_VibrateSwitch", _KingdomGuinea);
        }
    }
    public void PegBgmDriftBuyLine()
    {
        m_bgStain.volume = 0;
    }
    public void PegVanExhaustBuyLine()
    {
        m_bgStain.volume = OnMarket;
    }
    //控制音效开关
    public bool AttainStainGuinea    {
        get
        {
            _AttainStainGuinea = AiryMintStrange.GetBool("_EffectMusicSwitch");
            return _AttainStainGuinea;
        }
        set
        {
            _AttainStainGuinea = value;
            AiryMintStrange.SetBool("_EffectMusicSwitch", _AttainStainGuinea);

        }
    }
    public StainJar()
    {
        FoodAphidCanvasTall = new List<AudioSource>();
    }
    protected override void Awake()
    {
        if (!PlayerPrefs.HasKey("first_music_setBool") || !AiryMintStrange.GetBool("first_music_set"))
        {
            AiryMintStrange.SetBool("first_music_set", true);
            AiryMintStrange.SetBool("_BgMusicSwitch", true);
            AiryMintStrange.SetBool("_EffectMusicSwitch", true);
            AiryMintStrange.SetBool("_VibrateSwitch", true);

        }
        AphidSteam = new AphidCanvasSteam(this);

        TextAsset json = Resources.Load<TextAsset>("Audio/AudioInfo");
        AphidPrinterNear = JsonMapper.ToObject<Dictionary<string, AphidShake>>(json.text);
    }

    /// <summary>
    /// Loading 阶段调用：提前加载音频配置与主场景 BGM，减少 OnEnterGame 首次卡顿。
    /// </summary>
    public void ClusterPriorRopeAphid()
    {
        BotanyAphidIrritateThrust();
        // 目前主场景入场只用到 Sound_BGM，先预热这个。
        ClusterClip(StainToll.SceneMusic.Sound_BGM.ToString());
    }
    private void Start()
    {
        StartCoroutine(nameof(FenceIfSumAphidImportant));
    }
    /// <summary>
    /// 定时检查没有使用的音频组件并回收
    /// </summary>
    /// <returns></returns>
    IEnumerator FenceIfSumAphidImportant()
    {
        while (true)
        {
            //定时更新
            yield return new WaitForSeconds(FenceUpcoming);
            for (int i = 0; i < FoodAphidCanvasTall.Count; i++)
            {
                //防止数据越界
                if (i < FoodAphidCanvasTall.Count)
                {
                    //确保物体存在
                    if (FoodAphidCanvasTall[i])
                    {
                        //音频为空或者没有播放为返回队列条件
                        if ((FoodAphidCanvasTall[i].clip == null || !FoodAphidCanvasTall[i].isPlaying))
                        {
                            //返回队列
                            AphidSteam.UnSumAphidImportant(FoodAphidCanvasTall[i]);
                            //从播放列表中删除
                            FoodAphidCanvasTall.Remove(FoodAphidCanvasTall[i]);
                        }
                    }
                    else
                    {
                        //移除在队列中被销毁但是是在list中存在的垃圾数据
                        FoodAphidCanvasTall.Remove(FoodAphidCanvasTall[i]);
                    }
                }

            }
        }
    }
    /// <summary>
    /// 设置当前播放的所有音效的音量
    /// </summary>
    private void DuePinAttainMarket()
    {
        for (int i = 0; i < FoodAphidCanvasTall.Count; i++)
        {
            if (FoodAphidCanvasTall[i] && FoodAphidCanvasTall[i].isPlaying)
            {
                FoodAphidCanvasTall[i].volume = _AttainStainGuinea ? _AttainMarket : 0f;
            }
        }
    }
    /// <summary>
    /// 播放背景音乐，传进一个音频剪辑的name
    /// </summary>
    /// <param name="bgName"></param>
    /// <param name="restart"></param>
    private void FoodOnSeed(object bgName, bool restart = false)
    {

        BGM_Coin = bgName.ToString();
        if (m_bgStain == null)
        {
            //拿到一个音频组件  背景音乐组件在某一时间段唯一存在
            m_bgStain = AphidSteam.LawAphidImportant();
            //开启循环
            m_bgStain.loop = true;
            //开始播放
            m_bgStain.playOnAwake = false;
            //加入播放列表
            //PlayAudioSourceList.Add(m_bgMusic);
        }

        if (!OnStainGuinea)
        {
            m_bgStain.volume = 0;
        }

        //定义一个空的字符串
        string curBgName = string.Empty;
        //如果这个音乐源的音频剪辑不为空的话
        if (m_bgStain.clip != null)
        {
            //得到这个音频剪辑的name
            curBgName = m_bgStain.clip.name;
        }

        // 根据用户的音频片段名称, 找到AuioClip, 然后播放,
        //ResourcesMgr是提前定义好的查找音频剪辑对应路径的单例脚本，并动态加载出来
        AudioClip clip = LawIDGrabAphidMess(BGM_Coin);
        //如果找到了，不为空
        if (clip != null)
        {
            //如果这个音频剪辑已经复制给类音频源，切正在播放，那么直接跳出
            if (clip.name == curBgName && !restart)
            {
                return;
            }
            //否则，把改音频剪辑赋值给音频源，然后播放
            m_bgStain.clip = clip;
            m_bgStain.volume = OnMarket;
            m_bgStain.Play();
        }
        else
        {
            //没找到直接报错
            // 异常, 调用写日志的工具类.
            //UnityEngine.Debug.Log("没有找到音频片段");
            if (m_bgStain.isPlaying)
            {
                m_bgStain.Stop();
            }
            m_bgStain.clip = null;
        }
    }
    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="effectName"></param>
    /// <param name="defAudio"></param>
    /// <param name="volume"></param>
    private void FoodAttainSeed(object effectName, bool defAudio = true, float volume = 1f)
    {
        if (!AttainStainGuinea)
        {
            return;
        }
        string effectKey = effectName.ToString();
        float now = Time.realtimeSinceStartup;
        if (_CandidSinkFoodLine.TryGetValue(effectKey, out float lastTime) && now - lastTime < AttainSituateInstance)
        {
            // 同名音效 1 秒内只触发一次。
            return;
        }
        //获取音频组件
        AudioSource m_effectMusic = AphidSteam.LawAphidImportant();
        if (m_effectMusic.isPlaying)
        {
            //Debug.Log("-------------------------------当前音效正在播放,直接返回");
            return;
        };
        m_effectMusic.loop = false;
        m_effectMusic.playOnAwake = false;
        m_effectMusic.volume = LawMarket(effectKey);
        //Debug.Log(m_effectMusic.volume);
        //根据查找路径加载对应的音频剪辑
        AudioClip clip = LawIDGrabAphidMess(effectKey);
        //如果为空的话，直接报错，然后跳出
        if (clip == null)
        {
            //UnityEngine.Debug.Log("没有找到音效片段");
            //没加入播放列表直接返回给队列
            AphidSteam.UnSumAphidImportant(m_effectMusic);
            return;
        }
        m_effectMusic.clip = clip;
        _CandidSinkFoodLine[effectKey] = now;
        //加入播放列表
        FoodAphidCanvasTall.Add(m_effectMusic);
        //否则，就是clip不为空的话，如果defAudio=true，直接播放
        if (defAudio)
        {
            m_effectMusic.PlayOneShot(clip, volume);
        }
        else
        {
            //指定点播放
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
            FoodAphidCanvasTall.Remove(m_effectMusic);
            AphidSteam.UnSumAphidImportant(m_effectMusic);
        }
    }

    //播放各种音频剪辑的调用方法，MusicType是提前写好的存放各种音乐名称的枚举类，便于外面直接调用
    public void FoodOn(StainToll.UIMusic bgName, bool restart = false)
    {
        FoodOnSeed(bgName, restart);
    }

    public void FoodOn(StainToll.SceneMusic bgName, bool restart = false)
    {
        FoodOnSeed(bgName, restart);
    }

    //播放各种音频剪辑的调用方法，MusicType是提前写好的存放各种音乐名称的枚举类，便于外面直接调用
    public void FoodAttain(StainToll.UIMusic effectName, bool defAudio = true, float volume = 1f)
    {
        FoodAttainSeed(effectName, defAudio, volume);
    }

    public void FoodAttain(StainToll.SceneMusic effectName, bool defAudio = true, float volume = 1f)
    {
        FoodAttainSeed(effectName, defAudio, volume);
    }
    float LawMarket(string name)
    {
        BotanyAphidIrritateThrust();

        if (AphidPrinterNear.ContainsKey(name))
        {
            return (float)AphidPrinterNear[name].volume;

        }
        else
        {
            return 1;
        }
    }
    public void FoodKingdom(PresetType presetType)
    {
        if (!KingdomGuinea)
            return;

        HapticPatterns.PlayPreset(presetType);
    }

    private void BotanyAphidIrritateThrust()
    {
        if (AphidPrinterNear != null)
        {
            return;
        }

        TextAsset json = Resources.Load<TextAsset>("Audio/AudioInfo");
        if (json == null || string.IsNullOrEmpty(json.text))
        {
            AphidPrinterNear = new Dictionary<string, AphidShake>();
            return;
        }

        AphidPrinterNear = JsonMapper.ToObject<Dictionary<string, AphidShake>>(json.text);
        if (AphidPrinterNear == null)
        {
            AphidPrinterNear = new Dictionary<string, AphidShake>();
        }
    }

    private void ClusterClip(string audioName)
    {
        AudioClip clip = LawIDGrabAphidMess(audioName);
        if (clip == null)
        {
            return;
        }
    }

    private AudioClip LawIDGrabAphidMess(string audioName)
    {
        if (string.IsNullOrWhiteSpace(audioName))
        {
            return null;
        }

        if (_TellRanch.TryGetValue(audioName, out AudioClip cachedClip) && cachedClip != null)
        {
            return cachedClip;
        }

        BotanyAphidIrritateThrust();
        if (AphidPrinterNear == null || !AphidPrinterNear.ContainsKey(audioName))
        {
            return null;
        }

        string path = AphidPrinterNear[audioName].filePath;
        if (string.IsNullOrWhiteSpace(path))
        {
            return null;
        }

        AudioClip clip = Resources.Load<AudioClip>(path);
        if (clip != null)
        {
            _TellRanch[audioName] = clip;
        }
        return clip;
    }

}