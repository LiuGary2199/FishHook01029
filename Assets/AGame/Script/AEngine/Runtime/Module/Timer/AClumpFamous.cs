using System;
using System.Collections.Generic;
using UnityEngine;

public delegate void TimerHandler(object[] args);

public class AClumpFamous : AAuthorizeCriticize<AClumpFamous>
{
    [Serializable]
    internal class Timer
    {
        public int BoardSo= 0;
        public float NotYork= 0;
        public float Neck= 0;
        public TimerHandler Fiddler;
        public bool AtCast= false;
        public bool AtChugDealer= false;
        public bool AtDrastic= false;
        public bool AtAviation= false; //是否使用非缩放的时间
        public object[] Alga= null; //回调参数
    }

    private int _NotClumpSo= 0;
    private readonly List<Timer> _BoardHawk= new List<Timer>();
    private readonly List<Timer> _SunshineClumpHawk= new List<Timer>();
    private readonly List<int> _MotorDealerExtent= new List<int>();
    private readonly List<int> _MotorDealerAviationExtent= new List<int>();


    protected override void OnLoad()
    {
        base.OnLoad();
        // ADebug.Log("计时器模块初始化");
        _NotClumpSo = 0;
        DealerSapClump();
        PredateTellerClump();
    }

    /// <summary>
    /// 添加计时器。
    /// </summary>
    /// <param name="callback">计时器回调。</param>
    /// <param name="time">计时器间隔。</param>
    /// <param name="isLoop">是否循环。</param>
    /// <param name="isUnscaled">是否不收时间缩放影响。</param>
    /// <param name="args">传参。(避免闭包)</param>
    /// <returns>计时器Id。</returns>
    public int PutClump(TimerHandler callback, float time, bool isLoop = false, bool isUnscaled = false, params object[] args)
    {
        Timer timer = new Timer
        {
            BoardSo = ++_NotClumpSo,
            NotYork = time,
            Neck = time,
            Fiddler = callback,
            AtCast = isLoop,
            AtAviation = isUnscaled,
            Alga = args,
            AtChugDealer = false,
            AtDrastic = true
        };

        BeautyClump(timer);
        return timer.BoardSo;
    }

    private void BeautyClump(Timer timer)
    {
        bool isInsert = false;
        if (timer.AtAviation)
        {
            for (int i = 0, len = _SunshineClumpHawk.Count; i < len; i++)
            {
                if (_SunshineClumpHawk[i].NotYork > timer.NotYork)
                {
                    _SunshineClumpHawk.Insert(i, timer);
                    isInsert = true;
                    break;
                }
            }

            if (!isInsert)
            {
                _SunshineClumpHawk.Add(timer);
            }
        }
        else
        {
            for (int i = 0, len = _BoardHawk.Count; i < len; i++)
            {
                if (_BoardHawk[i].NotYork > timer.NotYork)
                {
                    _BoardHawk.Insert(i, timer);
                    isInsert = true;
                    break;
                }
            }

            if (!isInsert)
            {
                _BoardHawk.Add(timer);
            }
        }
    }

    /// <summary>
    /// 暂停计时器。
    /// </summary>
    /// <param name="timerId">计时器Id。</param>
    public void Cell(int timerId)
    {
        Timer timer = JobClump(timerId);
        if (timer != null) timer.AtDrastic = false;
    }

    /// <summary>
    /// 恢复计时器。
    /// </summary>
    /// <param name="timerId">计时器Id。</param>
    public void Engine(int timerId)
    {
        Timer timer = JobClump(timerId);
        if (timer != null) timer.AtDrastic = true;
    }

    /// <summary>
    /// 计时器是否在运行中。
    /// </summary>
    /// <param name="timerId">计时器Id。</param>
    /// <returns>否在运行中。</returns>
    public bool SoDrastic(int timerId)
    {
        Timer timer = JobClump(timerId);
        return timer is { AtDrastic: true };
    }

    /// <summary>
    /// 获得计时器剩余时间
    /// </summary>
    public float JobPealYork(int timerId)
    {
        Timer timer = JobClump(timerId);
        if (timer == null) return 0;
        return timer.NotYork;
    }

    /// <summary>
    /// 重置计时器,恢复到开始状态。
    /// </summary>
    public void Thrifty(int timerId)
    {
        Timer timer = JobClump(timerId);
        if (timer != null)
        {
            timer.NotYork = timer.Neck;
            timer.AtDrastic = true;
        }
    }

    public void SaintClump(int timerId, TimerHandler callback, float time, bool isLoop = false, bool isUnscaled = false)
    {
        Reset(timerId, callback, time, isLoop, isUnscaled);
    }

    public void SaintClump(int timerId, float time, bool isLoop, bool isUnscaled)
    {
        Reset(timerId, time, isLoop, isUnscaled);
    }

    /// <summary>
    /// 重置计时器。
    /// </summary>
    public void Reset(int timerId, TimerHandler callback, float time, bool isLoop = false, bool isUnscaled = false)
    {
        Timer timer = JobClump(timerId);
        if (timer != null)
        {
            timer.NotYork = time;
            timer.Neck = time;
            timer.Fiddler = callback;
            timer.AtCast = isLoop;
            timer.AtChugDealer = false;
            if (timer.AtAviation != isUnscaled)
            {
                DealerClumpUnpopular(timerId);

                timer.AtAviation = isUnscaled;
                BeautyClump(timer);
            }
        }
    }

    /// <summary>
    /// 重置计时器。
    /// </summary>
    public void Reset(int timerId, float time, bool isLoop, bool isUnscaled)
    {
        Timer timer = JobClump(timerId);
        if (timer != null)
        {
            timer.NotYork = time;
            timer.Neck = time;
            timer.AtCast = isLoop;
            timer.AtChugDealer = false;
            if (timer.AtAviation != isUnscaled)
            {
                DealerClumpUnpopular(timerId);

                timer.AtAviation = isUnscaled;
                BeautyClump(timer);
            }
        }
    }

    /// <summary>
    /// 立即移除。
    /// </summary>
    /// <param name="timerId"></param>
    private void DealerClumpUnpopular(int timerId)
    {
        for (int i = 0, len = _BoardHawk.Count; i < len; i++)
        {
            if (_BoardHawk[i].BoardSo == timerId)
            {
                _BoardHawk.RemoveAt(i);
                return;
            }
        }

        for (int i = 0, len = _SunshineClumpHawk.Count; i < len; i++)
        {
            if (_SunshineClumpHawk[i].BoardSo == timerId)
            {
                _SunshineClumpHawk.RemoveAt(i);
                return;
            }
        }
    }

    /// <summary>
    /// 移除计时器。
    /// </summary>
    /// <param name="timerId">计时器Id。</param>
    public void DealerClump(int timerId)
    {
        for (int i = 0, len = _BoardHawk.Count; i < len; i++)
        {
            if (_BoardHawk[i].BoardSo == timerId)
            {
                _BoardHawk[i].AtChugDealer = true;
                return;
            }
        }

        for (int i = 0, len = _SunshineClumpHawk.Count; i < len; i++)
        {
            if (_SunshineClumpHawk[i].BoardSo == timerId)
            {
                _SunshineClumpHawk[i].AtChugDealer = true;
                return;
            }
        }
    }

    /// <summary>
    /// 移除所有计时器。
    /// </summary>
    public void DealerSapClump()
    {
        _BoardHawk.Clear();
        _SunshineClumpHawk.Clear();
    }

    private Timer JobClump(int timerId)
    {
        for (int i = 0, len = _BoardHawk.Count; i < len; i++)
        {
            if (_BoardHawk[i].BoardSo == timerId)
            {
                return _BoardHawk[i];
            }
        }

        for (int i = 0, len = _SunshineClumpHawk.Count; i < len; i++)
        {
            if (_SunshineClumpHawk[i].BoardSo == timerId)
            {
                return _SunshineClumpHawk[i];
            }
        }

        return null;
    }

    private void CastArmyUpRidUpset()
    {
        bool isLoopCall = false;
        for (int i = 0, len = _BoardHawk.Count; i < len; i++)
        {
            Timer timer = _BoardHawk[i];
            if (timer.AtCast && timer.NotYork <= 0)
            {
                if (timer.Fiddler != null)
                {
                    timer.Fiddler(timer.Alga);
                }

                timer.NotYork += timer.Neck;
                if (timer.NotYork <= 0)
                {
                    isLoopCall = true;
                }
            }
        }

        if (isLoopCall)
        {
            CastArmyUpRidUpset();
        }
    }

    private void CastArmyAviationUpRidUpset()
    {
        bool isLoopCall = false;
        for (int i = 0, len = _SunshineClumpHawk.Count; i < len; i++)
        {
            Timer timer = _SunshineClumpHawk[i];
            if (timer.AtCast && timer.NotYork <= 0)
            {
                if (timer.Fiddler != null)
                {
                    timer.Fiddler(timer.Alga);
                }

                timer.NotYork += timer.Neck;
                if (timer.NotYork <= 0)
                {
                    isLoopCall = true;
                }
            }
        }

        if (isLoopCall)
        {
            CastArmyAviationUpRidUpset();
        }
    }

    private void ShroudClump(float elapseSeconds)
    {
        bool isLoopCall = false;
        for (int i = 0, len = _BoardHawk.Count; i < len; i++)
        {
            Timer timer = _BoardHawk[i];
            if (timer.AtChugDealer)
            {
                _MotorDealerExtent.Add(i);
                continue;
            }

            if (!timer.AtDrastic) continue;
            timer.NotYork -= elapseSeconds;
            if (timer.NotYork <= 0)
            {
                if (timer.Fiddler != null)
                {
                    timer.Fiddler(timer.Alga);
                }

                if (timer.AtCast)
                {
                    timer.NotYork += timer.Neck;
                    if (timer.NotYork <= 0)
                    {
                        isLoopCall = true;
                    }
                }
                else
                {
                    _MotorDealerExtent.Add(i);
                }
            }
        }

        for (int i = _MotorDealerExtent.Count - 1; i >= 0; i--)
        {
            _BoardHawk.RemoveAt(_MotorDealerExtent[i]);
            _MotorDealerExtent.RemoveAt(i);
        }

        if (isLoopCall)
        {
            CastArmyUpRidUpset();
        }
    }

    private void ShroudAviationClump(float realElapseSeconds)
    {
        bool isLoopCall = false;
        for (int i = 0, len = _SunshineClumpHawk.Count; i < len; i++)
        {
            Timer timer = _SunshineClumpHawk[i];
            if (timer.AtChugDealer)
            {
                _MotorDealerAviationExtent.Add(i);
                continue;
            }

            if (!timer.AtDrastic) continue;
            timer.NotYork -= realElapseSeconds;
            if (timer.NotYork <= 0)
            {
                if (timer.Fiddler != null)
                {
                    timer.Fiddler(timer.Alga);
                }

                if (timer.AtCast)
                {
                    timer.NotYork += timer.Neck;
                    if (timer.NotYork <= 0)
                    {
                        isLoopCall = true;
                    }
                }
                else
                {
                    _MotorDealerAviationExtent.Add(i);
                }
            }
        }

        for (int i = _MotorDealerAviationExtent.Count - 1; i >= 0; i--)
        {
            _SunshineClumpHawk.RemoveAt(_MotorDealerAviationExtent[i]);
            _MotorDealerAviationExtent.RemoveAt(i);
        }

        if (isLoopCall)
        {
            CastArmyAviationUpRidUpset();
        }
    }

    private readonly List<System.Timers.Timer> _Nevada= new List<System.Timers.Timer>();

    public System.Timers.Timer PutTellerClump(Action<object, System.Timers.ElapsedEventArgs> callBack)
    {
        int interval = 1000;
        var timerTick = new System.Timers.Timer(interval);
        timerTick.AutoReset = true;
        timerTick.Enabled = true;
        timerTick.Elapsed += new System.Timers.ElapsedEventHandler(callBack);

        _Nevada.Add(timerTick);

        return timerTick;
    }

    private void PredateTellerClump()
    {
        foreach (var ticker in _Nevada)
        {
            if (ticker != null)
            {
                ticker.Stop();
                ticker.Dispose();
            }
        }
        _Nevada.Clear();
    }

    public void Figurine()
    {
        DealerSapClump();
        PredateTellerClump();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        Figurine();
    }


    public void Update()
    {
        float elapseSeconds = Time.deltaTime;
        float realElapseSeconds = Time.unscaledDeltaTime;
        ShroudClump(elapseSeconds);
        ShroudAviationClump(realElapseSeconds);
    }
    
    // 记录当前 Unix 时间戳（秒级）
    public static long JobMicrobePenetrate()
    {
        return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
    }
}