using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

using UnityEngine;
using UnityEngine.UI;

/// <summary>  </summary>
public class WaryStand : SeedUIHouse
{
[UnityEngine.Serialization.FormerlySerializedAs("SlotMachine")]    public GameObject WaryPlummet;
[UnityEngine.Serialization.FormerlySerializedAs("winparticle1")]    public GameObject Corporation1;
[UnityEngine.Serialization.FormerlySerializedAs("winparticle2")]    public GameObject Corporation2;
[UnityEngine.Serialization.FormerlySerializedAs("SlotSprites")]    public Sprite[] WaryCaribou;
[UnityEngine.Serialization.FormerlySerializedAs("RealItemParent")]    public Transform RealKeepSolely;
    private List<List<Transform>> LateAgent;
    int[] LateLoopRelic= new int[3];
[UnityEngine.Serialization.FormerlySerializedAs("FakeItemsParent")]    public Transform GushAgentSolely;
    List<List<Transform>> GushAgent;
    int[] GushLineRelic= new int[3];
    int GushLineThe= 15;
    float IceY; //假slotitem之间的间距
    float Ant; //假slot最上面一行高度
    float Hunter; //假slot最底下一行高度
    bool HeImitate;
    bool HeWaryRow;
    int RowSlope;
    RewardData Temple;

    void Start()
    {
        Rail();
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        AiryMintStrange.SetInt(CTedium.Dy_Fleet_Deterrent, AiryMintStrange.GetInt(CTedium.Dy_Fleet_Deterrent) + 1);
        BabyLatinDating.LawLaurasia().TangLatin("1006");
        LineStrange.LawLaurasia().Track(1, () => { Wary(); });
    }

    void Rail()
    {
        LateAgent = new List<List<Transform>>();
        for (int i = 0; i < 3; i++)
        {
            LateAgent.Add(new List<Transform>());
            for (int j = 0; j < 1; j++)
            {
                Transform Item = RealKeepSolely.GetChild(i * 1 + j);
                Item.gameObject.SetActive(false);
                Item.name = $"第{i + 1}列  第{j + 1}行";
                LateAgent[i].Add(Item);
            }
        }
        GushAgent = new List<List<Transform>>();
        for (int i = 0; i < 3; i++)
        {
            GushAgent.Add(new List<Transform>());
            for (int j = 0; j < 5; j++)
            {
                Transform Item = GushAgentSolely.GetChild(i * 5 + j);
                int Index = UnityEngine.Random.Range(0, WaryCaribou.Length);
                DueWaryNeat(Item, Index);
                Item.name = $"第{i + 1}列  第{j + 1}行";
                GushAgent[i].Add(Item);
            }
        }

        IceY = GushAgent[0][0].GetChild(0).GetComponent<RectTransform>().sizeDelta.y + GushAgentSolely.GetComponent<GridLayoutGroup>().spacing.y;
        Ant = GushAgent[0][0].transform.localPosition.y;
        Hunter = GushAgent[0][^1].transform.localPosition.y;
    }

    public void Wary()
    {
        if (LateAgent == null || LateAgent.Count == 0)
            Rail();

        HeImitate = true;
        HeWaryRow = true;//Random.value < .7f;
        int[] RealItemIndex = new int[3];
        if (HeWaryRow)
        {
            // WinIndex = GetWinIndexByWeight();
            Temple = MoodLack.LawTempleMintBeGeyserSowDegas(LopColeJar.instance.RopeMint.slots_data_list);
            if (Temple.rewardNum > 999f)
                Temple.rewardNum = 999;
            print("老虎机中奖：" + Temple.type + "  数值： " + Temple.rewardNum);
            // 将小数转换为整数（乘以100）
            int totalValue = (int)Temple.rewardNum;
            if (Temple.rewardNum < 10)
                totalValue = (int)(Temple.rewardNum * 100);
            else
                totalValue = (int)Temple.rewardNum;
            Temple.rewardNum = totalValue;
            // 拆分三个数字
            int[] Indexs = new int[3];
            Indexs[0] = totalValue / 100;         // 十位
            Indexs[1] = (totalValue / 10) % 10;   // 个位
            Indexs[2] = totalValue % 10;          // 十分位
            for (int i = 0; i < 3; i++)
                RealItemIndex[i] = Indexs[i];
        }
        else
        {
            int[] temp = new int[WaryCaribou.Length];
            for (int i = 0; i < WaryCaribou.Length; i++)
                temp[i] = i;
            for (int i = 0; i < 3; i++)
            {
                int tempIndex = UnityEngine.Random.Range(0, WaryCaribou.Length - i);
                int tempValue = temp[tempIndex];
                temp[tempIndex] = temp[WaryCaribou.Length - i];
                temp[WaryCaribou.Length - i] = tempValue;
            }
            for (int i = 0; i < 3; i++)
                RealItemIndex[i] = temp[i];
        }
        for (int i = 0; i < 3; i++)
        {
            Transform Item = LateAgent[i][0];
            DueWaryNeat(Item, RealItemIndex[i]);
            Item.gameObject.SetActive(false);
            Item.transform.localPosition = new Vector2(Item.transform.localPosition.x, Item.transform.localPosition.y + IceY);
        }
        for (int i = 0; i < 3; i++)
        {
            LateLoopRelic[i] = 0;
            GushLineRelic[i] = 0;
            for (int j = 0; j < 5; j++)
                GushAgent[i][j].Find("Icon").gameObject.SetActive(true);
            int Index = i;
            LineStrange.LawLaurasia().Track(Index * .4f, () =>
            {
                GushGemLayoutHalt(Index, "开始");
            });
        }
         StainJar.LawLaurasia().FoodAttain(StainToll.UIMusic.slotsrot);
        // StainJar.GetInstance().PlayEffect(StainToll.UIMusic.SFX_SlotsRotate);
    }
    int LawRowSlopeBeGeyser()
    {
        // // 0:钱 1钻石
        // int[] WinIndex = new int[] { 0, 1 };
        // int[] Weights = new int[] { 10, 10 };
        // int Sum = 0;
        // for (int i = 0; i < WinIndex.Length; i++)
        //     Sum += Weights[i];
        // int RandomrewardNum = UnityEngine.Random.Range(0, Sum);
        // for (int i = 0; i < WinIndex.Length; i++)
        // {
        //     RandomrewardNum -= Weights[i];
        //     if (RandomrewardNum < 0)
        //         return WinIndex[i];
        // }
        return 0;
    }

    void DueWaryNeat(Transform Item, int Index)
    {
        Item.Find("Icon").GetComponent<Image>().sprite = WaryCaribou[Index];
        Item.Find("Icon").gameObject.SetActive(true);
    }

    void LateGemLayoutHalt(int Index)
    {
        float AnimTime = 0.2f;
        Ease AnimEase = Ease.OutBack;
        for (int i = 0; i < 1; i++)
        {
            Transform Item = LateAgent[Index][i];
            Item.gameObject.SetActive(true);
            Item.transform.DOLocalMoveY(Item.transform.localPosition.y - IceY, AnimTime).SetEase(AnimEase).OnUpdate(() =>
            {
                for (int j = 0; j < 5; j++)
                {
                    Transform FakeItem = GushAgent[Index][j];
                    if (Mathf.Abs(Item.transform.position.y - FakeItem.transform.position.y) < .5f)
                        FakeItem.Find("Icon").gameObject.SetActive(false);
                }
            });
        }
        LineStrange.LawLaurasia().Track(AnimTime, () =>
  {
      // if (Index == 0)
      //     StainJar.GetInstance().PlayEffect(StainToll.UIMusic.Sound_High_Rate_3Slot);
      // else if (Index == 1)
      //     StainJar.GetInstance().PlayEffect(StainToll.UIMusic.Sound_High_Rate_4Slot);
      // else if (Index == 2)
      // StainJar.GetInstance().PlayEffect(StainToll.UIMusic.SFX_ScratchGetReward);
      if (Index == 2)
      {
          Corporation1.SetActive(true);
          Corporation2.SetActive(true);
          WaryTrader();
      }
  });
    }
    void GushGemLayoutHalt(int Index, string AnimType)
    {
       
        float AnimTime = 0;
        Ease AnimEase = Ease.Linear;
        if (AnimType == "开始")
        {
            AnimTime = 0.2f;
            AnimEase = Ease.InSine;
        }
        else if (AnimType == "持续")
        {
            AnimTime = 0.05f;
            AnimEase = Ease.Linear;
        }
        else if (AnimType == "结束")
        {
            AnimTime = 0.2f;
            AnimEase = Ease.OutBack;
        }
        for (int i = 0; i < 5; i++)
        {
            Transform Item = GushAgent[Index][i];
            Item.transform.DOLocalMoveY(Item.transform.localPosition.y - IceY, AnimTime).SetEase(AnimEase);
        }
        LineStrange.LawLaurasia().Track(AnimTime, () =>
 {
     for (int i = 0; i < 5; i++)
     {
         Transform Item = GushAgent[Index][i];
         if (Item.transform.localPosition.y < Hunter)
         {
             Item.transform.localPosition = new Vector2(Item.transform.localPosition.x, Ant);
             DueWaryNeat(Item, UnityEngine.Random.Range(0, WaryCaribou.Length));
             break;
         }
     }

     if (AnimType == "开始")
         GushGemLayoutHalt(Index, "持续");
     else if (AnimType == "持续")
     {
         GushLineRelic[Index]++;
         if (GushLineRelic[Index] < GushLineThe)
             GushGemLayoutHalt(Index, "持续");
         else
             GushGemLayoutHalt(Index, "结束");

         if (GushLineRelic[Index] == GushLineThe)
             LateGemLayoutHalt(Index);
     }
 });
    }

    void WaryTrader()
    {
        HeImitate = false;
        //AllGetBtn.gameObject.SetActive(true);
        //AllGetBtn.transform.localPosition = new Vector2(0, -422);
        LineStrange.LawLaurasia().Track(1.5f, () =>
        {
            //GetBtn.gameObject.SetActive(true);
            // GetBtn.transform.localPosition = new Vector2(185, -422);
            // AllGetBtn.transform.localPosition = new Vector2(-185, -422);
            Corporation1.SetActive(false);
            Corporation2.SetActive(false);
            DriftUIBard(nameof(WaryStand));
            UIStrange.LawLaurasia().BeatUIHouse(nameof(TempleStand)).GetComponent<TempleStand>().Rail(null, Temple, 
            ()=>{
                        LuxuryHop.OrSlightRopeLuminous?.Invoke();
            }, "1006");
        });
    }

}
