using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
public class BabyLatinDating : MonoSnowstorm<BabyLatinDating>
{
    public string version = "1.2";
    public string RopeKnow= LopColeJar.instance.RopeKnow;
    //channel
#if UNITY_IOS
    private string Surpass = "AppStore";
#elif UNITY_ANDROID
    private string Surpass= "GooglePlay";
#else
    private string Surpass = "GooglePlay";
#endif


    private void OnApplicationPause(bool pause)
    {
        BabyLatinDating.LawLaurasia().sendRopeCommerce();
    }

    public Text Fare;

    protected override void Awake()
    {
        base.Awake();

        version = Application.version;
        StartCoroutine(nameof(SashBurgeon));
    }
    IEnumerator SashBurgeon()
    {
        while (true)
        {
            yield return new WaitForSeconds(120f);
            BabyLatinDating.LawLaurasia().sendRopeCommerce();
        }
    }
    private void Start()
    {
        if (AiryMintStrange.GetInt("event_day") != DateTime.Now.Day && AiryMintStrange.GetString("user_servers_id").Length != 0)
        {
            AiryMintStrange.SetInt("event_day", DateTime.Now.Day);
        }
    }
    public void TangIfLampLatin(string event_id)
    {
        TangLatin(event_id);
    }
    public void sendRopeCommerce(List<string> valueList = null)
    {
        if (AiryMintStrange.GetDouble(CTedium.Dy_InnovativeSeatSate) == 0)
        {
            AiryMintStrange.SetDouble(CTedium.Dy_InnovativeSeatSate, AiryMintStrange.GetDouble(CTedium.Dy_ComaSate));
        }
        if (AiryMintStrange.GetDouble(CTedium.Dy_InnovativeParty) == 0)
        {
            AiryMintStrange.SetDouble(CTedium.Dy_InnovativeParty, AiryMintStrange.GetDouble(CTedium.Dy_Token));
        }
        if (valueList == null)
        {
            valueList = new List<string>() {
                AiryMintStrange.GetInt(CTedium.Dy_Tool_Spiky).ToString(),//船等级
                AiryMintStrange.GetInt(CTedium.Dy_InnovativeSeatSate).ToString(),//累计现金
                AiryMintStrange.GetInt(CTedium.Dy_Fleet_Partition).ToString(),
                AiryMintStrange.GetInt(CTedium.Dy_Fleet_Deterrent).ToString(),
                AiryMintStrange.GetInt(CTedium.Dy_Fleet_Freshwater).ToString(),
                AiryMintStrange.GetInt(CTedium.Dy_Opera_Sash_Paris_Cement).ToString(),
                //AiryMintStrange.GetInt(SlotConfig.sv_SlotSpinCount).ToString()
            };
        }

        if (AiryMintStrange.GetString(CTedium.Dy_UtterHamperWe) == null)
        {
            return;
        }
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("gameCode", RopeKnow);
        wwwForm.AddField("userId", AiryMintStrange.GetString(CTedium.Dy_UtterHamperWe));

        wwwForm.AddField("gameVersion", version);

        wwwForm.AddField("channel", Surpass);

        for (int i = 0; i < valueList.Count; i++)
        {
            wwwForm.AddField("resource" + (i + 1), valueList[i]);
        }



        StartCoroutine(TangBaby(LopColeJar.instance.SeedMaw + "/api/client/game_progress", wwwForm,
        (error) =>
        {
            Debug.Log(error);
        },
        (message) =>
        {
            Debug.Log(message);
        }));
    }
    public void TangLatin(string event_id, string p1 = null, string p2 = null, string p3 = null)
    {
        if (Fare != null)
        {
            if (int.Parse(event_id) < 9100 && int.Parse(event_id) >= 9000)
            {
                if (p1 == null)
                {
                    p1 = "";
                }
                Fare.text += "\n" + DateTime.Now.ToString() + "id:" + event_id + "  p1:" + p1;
            }
        }
        if (AiryMintStrange.GetString(CTedium.Dy_UtterHamperWe) == null)
        {
            LopColeJar.instance.Reuse();
            return;
        }
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("gameCode", RopeKnow);
        wwwForm.AddField("userId", AiryMintStrange.GetString(CTedium.Dy_UtterHamperWe));
        //Debug.Log("userId:" + AiryMintStrange.GetString(CTedium.sv_LocalServerId));
        wwwForm.AddField("version", version);
        //Debug.Log("version:" + version);
        wwwForm.AddField("channel", Surpass);
        //Debug.Log("channel:" + channal);
        wwwForm.AddField("operateId", event_id);
        Debug.Log("operateId:" + event_id);


        if (p1 != null)
        {
            wwwForm.AddField("params1", p1);
        }
        if (p2 != null)
        {
            wwwForm.AddField("params2", p2);
        }
        if (p3 != null)
        {
            wwwForm.AddField("params3", p3);
        }
        StartCoroutine(TangBaby(LopColeJar.instance.SeedMaw + "/api/client/log", wwwForm,
        (error) =>
        {
            Debug.Log(error);
        },
        (message) =>
        {
            Debug.Log(message);
        }));
    }
    IEnumerator TangBaby(string _url, WWWForm wwwForm, Action<string> fail, Action<string> success)
    {
        //Debug.Log(SerializeDictionaryToJsonString(dic));
        using UnityWebRequest request = UnityWebRequest.Post(_url, wwwForm);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isNetworkError)
        {
            fail(request.error);
            endCluster();
            request.Dispose();
        }
        else
        {
            success(request.downloadHandler.text);
            endCluster();
            request.Dispose();
        }
    }
    private void endCluster()
    {
        StopCoroutine(nameof(TangBaby));
    }


}