/***
 * 
 * AudioSource组件管理(音效，背景音乐除外)
 * 
 * **/
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AphidCanvasSteam 
{
    //音乐的管理者
    private GameObject AphidJar;
    //音乐组件管理队列
    private List<AudioSource> AphidImportantSteam;
    //音乐组件默认容器最大值  
    private int TheRelic= 25;
    public AphidCanvasSteam(StainJar audioMgr)
    {
        AphidJar = audioMgr.gameObject;
        RailAphidCanvasSteam();
    }
  
    /// <summary>
    /// 初始化队列
    /// </summary>
    private void RailAphidCanvasSteam()
    {
        AphidImportantSteam = new List<AudioSource>();
        for(int i = 0; i < TheRelic; i++)
        {
            TieAphidCanvasEyePoreJar();
        }
    }
    /// <summary>
    /// 给音乐的管理者添加音频组件，同时组件加入队列
    /// </summary>
    private AudioSource TieAphidCanvasEyePoreJar()
    {
        AudioSource audio = AphidJar.AddComponent<AudioSource>();
        AphidImportantSteam.Add(audio);
        return audio;
    }
    /// <summary>
    /// 获取一个音频组件
    /// </summary>
    /// <param name="audioMgr"></param>
    /// <returns></returns>
    public AudioSource LawAphidImportant()
    {
        if (AphidImportantSteam.Count > 0)
        {
            AudioSource audio = AphidImportantSteam.Find(t => !t.isPlaying);
            if (audio)
            {
                AphidImportantSteam.Remove(audio);
                return audio;
            }
            //队列中没有了，需额外添加
            return TieAphidCanvasEyePoreJar();
            //直接返回队列中存在的组件
            //return AudioComponentQueue.Dequeue();
        }
        else
        {
            //队列中没有了，需额外添加
            return  TieAphidCanvasEyePoreJar();
        }
    }
    /// <summary>
    /// 没有被使用的音频组件返回给队列
    /// </summary>
    /// <param name="audio"></param>
    public void UnSumAphidImportant(AudioSource audio)
    {
        if (AphidImportantSteam.Contains(audio)) return;
        if (AphidImportantSteam.Count >= TheRelic)
        {
            GameObject.Destroy(audio);
            //Debug.Log("删除组件");
        }
        else
        {
            audio.clip = null;
            AphidImportantSteam.Add(audio);
        }

        //Debug.Log("队列长度是" + AudioComponentQueue.Count);
    }
    
}
