using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 时间管理器 </summary>
public class LineStrange : MonoSnowstorm<LineStrange>
{
    public bool HeEnsue{ get; set; } // 是否暂停

    /// <summary> 延迟调用 </summary>    
    public Coroutine Track(float delay, Action action)
    {
        return StartCoroutine(TrackIE(delay, action));
    }
    IEnumerator TrackIE(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }

     /// <summary> 延迟调用 真实时间 </summary>    
    public Coroutine Track_LateLine(float delay, Action action)
    {
        return StartCoroutine(TrackIE_LateLine(delay, action));
    }
    IEnumerator TrackIE_LateLine(float delay, Action action)
    {
        yield return new WaitForSecondsRealtime(delay);
        action?.Invoke();
    }

    /// <summary> 延迟调用，带暂停功能 </summary>
    public Coroutine Track_MoreEnsue(float delay, Action action)
    {
        return StartCoroutine(TrackIE_MoreEnsue(delay, action));
    }
    IEnumerator TrackIE_MoreEnsue(float delay, Action action)
    {
        float elapsed = 0;
        while (elapsed < delay)
        {
            if (!HeEnsue)
                elapsed += Time.deltaTime;
            yield return null;
        }
        action?.Invoke();
    }

    /// <summary> 循环调用，带暂停功能 </summary>
    public void Reject_MoreEnsue(float initialDelay, float interval, Action action)
    {
        StartCoroutine(RejectPhysician(initialDelay, interval, action));
    }
    private IEnumerator RejectPhysician(float initialDelay, float interval, Action action)
    {
        // 初始延迟
        yield return TrackIE_MoreEnsue(initialDelay, () => { });
        // 循环调用
        while (true)
        {
            if (!HeEnsue)
                action?.Invoke();
            yield return TrackIE_MoreEnsue(interval, () => { });
        }
    }

    public void PlumTrack(Coroutine coroutine)
    {
        StopCoroutine(coroutine);
    }


    //获取离线时间（以秒为单位）
    public int LawErectusLine()
    {
        if (PlayerPrefs.HasKey("LastOnline"))
        {
            long lastOnline = long.Parse(PlayerPrefs.GetString("LastOnline"));
            return (int)(LawEdgeLineReset() - lastOnline);
        }
        else
            return 0;
    }
    //获取Unix时间戳（以秒为单位）
    public long LawEdgeLineReset()
    {
        return DateTimeOffset.Now.ToUnixTimeSeconds();
    }
    //更新最后在线时间
    private void AthensSinkKettleLine()
    {
        PlayerPrefs.SetString("LastOnline", LawEdgeLineReset().ToString());
    }

    void OnApplicationQuit()
    {
        AthensSinkKettleLine();
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
            AthensSinkKettleLine();
    }

    public string LawLineBabble(int TotalTime)
    {
        int Hours = TotalTime / 3600;
        int Minutes = (TotalTime % 3600) / 60;
        int Seconds = TotalTime % 60;
        if (Hours > 0)
            return string.Format("{0:00}:{1:00}:{2:00}", Hours, Minutes, Seconds);
        else
            return string.Format("{0:00}:{1:00}", Minutes, Seconds);
    }
}
