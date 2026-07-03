/**
 * 
 * 网络请求的post对象
 * 
 * ***/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class LopTombBabyRation 
{
    //post请求地址
    public string URL;
    //post的数据表单
    public WWWForm Bard;
    //post成功回调
    public Action<UnityWebRequest> BabyPresage;
    //post失败回调
    public Action BabyMast;
    public LopTombBabyRation(string url,WWWForm  form,Action<UnityWebRequest> success,Action fail)
    {
        URL = url;
        Bard = form;
        BabyPresage = success;
        BabyMast = fail;
    }
}
