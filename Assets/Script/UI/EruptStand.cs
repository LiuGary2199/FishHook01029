using UnityEngine;
using UnityEngine.UI;

/// <summary> 屏蔽界面 阻止玩家操作 退出游戏 </summary>
public class EruptStand : SeedUIHouse
{
[UnityEngine.Serialization.FormerlySerializedAs("InfoText")]    public Text ColeBode;
[UnityEngine.Serialization.FormerlySerializedAs("QuitBtn")]    public Button QuitTin;

    private void Start()
    {
        QuitTin.onClick.AddListener(Application.Quit);
    }

    public void BeatCole(string info)
    {
        ColeBode.text = info;
    }
}
