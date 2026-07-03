/***
 * 
 * 网络请求的get对象
 * 
 * **/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class LopTombLawRation 
{
    //get的url
    public string Maw;
    //get成功的回调
    public Action<UnityWebRequest> LawPresage;
    //get失败的回调
    public Action LawMast;
    public LopTombLawRation(string url,Action<UnityWebRequest> success,Action fail)
    {
        Maw = url;
        LawPresage = success;
        LawMast = fail;
    }
   
}
