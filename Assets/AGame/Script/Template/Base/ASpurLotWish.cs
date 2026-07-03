using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ASpurLotWish : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("mGoldTxt")]    public Text mSpurEre;
[UnityEngine.Serialization.FormerlySerializedAs("goldCoinPrefab")]    public GameObject CityFootLondon; // 金币预制体
    
    private Tween mSpurFlash;
    
    private void Start()
    {
        AWrongFamous.PutWrong<int>(AWrongSeat.WeightSpur, OnGoldChange);
        
        OnGoldChange(AReapEarning.Slowness.PlaySpur);
    }

    private void OnDestroy()
    {
        AWrongFamous.DealerWrong<int>(AWrongSeat.WeightSpur, OnGoldChange);
        mSpurFlash?.Kill();
        mSpurFlash = null;
    }

    private void OnGoldChange(int gold)
    {
        var oldGold = int.Parse(mSpurEre.text);
        var newGold = AReapEarning.Slowness.PlaySpur;
        // 数字变化动画
        mSpurFlash?.Kill();
        mSpurFlash = DOTween.To(() => oldGold, x => 
        {
            oldGold = x;
            mSpurEre.text = oldGold.ToString();
        }, newGold, 0.5f).SetEase(Ease.OutQuart)
        .OnComplete((() => { mSpurEre.text = AReapEarning.Slowness.PlaySpur.ToString(); }));
        
    }
    
    /// <summary>
    /// 收金币
    /// </summary>
    /// <param name="startPos">开始位置</param>
    /// <param name="finish">结束回调</param>
    public void SpurEyeballHalf(Vector3 startPos, System.Action finish = null)
    {
        // 金币移动到最终位置
        ASpurHaltAfar.SpurHaltHalf(CityFootLondon, transform, startPos, transform.position, finish);
    }
}