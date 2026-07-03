using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangStrange : MonoBehaviour
{
    public static HangStrange instance;

    private bool Plank= false;

    private void Awake()
    {
        instance = this;
    }

    public void DimeRail()
    {
        bool isNewPlayer = !PlayerPrefs.HasKey(CTedium.Dy_HeBedWindow + "Bool") || AiryMintStrange.GetBool(CTedium.Dy_HeBedWindow);

        SqueakRailStrange.Instance.RailSqueakMint(isNewPlayer);

        if (isNewPlayer)
        {
            // 新用户
            AiryMintStrange.SetBool(CTedium.Dy_HeBedWindow, false);
        }

        StainJar.LawLaurasia().FoodOn(StainToll.SceneMusic.Sound_BGM);

#if UNITY_IOS && !UNITY_EDITOR
  if (PlayerPrefs.GetInt("da2prx") > 0)
        {
            AIRopeGiftStrange.GetInstance().SendEvent("da2prx");
        }
        if (PlayerPrefs.GetInt("2cgw82") > 0)
        {
            AIRopeGiftStrange.GetInstance().SendEvent("2cgw82");
        }
        if (PlayerPrefs.GetInt("7sfuth") > 0)
        {
            AIRopeGiftStrange.GetInstance().SendEvent("7sfuth");
        }
#endif


        UIStrange.LawLaurasia().BeatUIHouse(nameof(TendStand));
        BabyLatinDating.LawLaurasia().TangLatin("1001");
        Plank = true;
    }

    //切前后台也需要检测屏蔽 防止游戏中途更改手机状态
    private void OnApplicationFocus(bool focusStatus)
    {
        if (focusStatus)
            HappenLack.BoredomEruptFence();
    }
}
