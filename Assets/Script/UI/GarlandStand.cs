using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GarlandStand : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("sliderImage")]    public Image AssignTwain;
[UnityEngine.Serialization.FormerlySerializedAs("progressText")]    public Text BirdlikeBode;
    private bool BePriorRope= false;
    private bool isLoadingAGame = false;

    void Start()
    {
        AssignTwain.fillAmount = 0;
        BirdlikeBode.text = "0%";
        BePriorRope = false;
        StainJar.LawLaurasia().ClusterPriorRopeAphid();
        ZJT_Manager.LawLaurasia().RecordStartTime();
        LuxuryHop.OrPriorRope += OnEnterGame;
    }
    public void OnEnterGame()
    {
        Destroy(transform.parent.gameObject);
        HangStrange.instance.DimeRail();
    }
    private void LoadAGameScene()
    {
        if (isLoadingAGame)
        {
            return;
        }
        isLoadingAGame = true;
        var sceneAsync = SceneManager.LoadSceneAsync("AGame");
        sceneAsync.completed += (operation) =>
        {
            // 加载完成后，激活AGame场景
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("AGame"));
        };

    }
    // Update is called once per frame
    void Update()
    {
        if (AssignTwain.fillAmount <= 0.8f || (LopColeJar.instance.Plank && CashOutManager.LawLaurasia().Ready))
        //if (sliderImage.fillAmount <= 0.8f || (LopColeJar.instance.ready))
        {
            AssignTwain.fillAmount += Time.deltaTime * 0.2f;
            BirdlikeBode.text = (int)(AssignTwain.fillAmount * 100) + "%";
            if (AssignTwain.fillAmount >= 1 && !BePriorRope && !isLoadingAGame)
            {
                HappenLack.HeDaunt();
                BePriorRope = true;
                // 安卓平台特殊屏蔽规则 被屏蔽玩家显示提示 阻止进入
                if (HappenLack.BoredomEruptFence())
                    return;
                //主动调用一次IsApple 判断是否符合屏蔽规则
                if (HappenLack.HeDaunt())
                {
                 LoadAGameScene();
                    return;
                }

                UIStrange.LawLaurasia().BeatUIHouse(nameof(GarlandMask));

                //Destroy(transform.parent.gameObject);
                //  HangStrange.instance.gameInit();
                ZJT_Manager.LawLaurasia().ReportEvent_LoadingTime();
            }
        }
    }
    void OnDestroy()
    {
        LuxuryHop.OrPriorRope -= OnEnterGame;
    }
}
