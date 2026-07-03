using System.Collections;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 提示面板。
/// </summary>
/// <param name="tips">提示内容。</param>
public class AFuelInner : AUIDrench
{
[UnityEngine.Serialization.FormerlySerializedAs("m_TipsText")]    public Text m_FuelJuly;
    
    public override void OnRefresh()
    {
        base.OnRefresh();
        m_FuelJuly.text = (string)LimeLade;
        
        StartCoroutine(MidstInner(1.5f));
    }
    
    private IEnumerator MidstInner(float time)
    {
        yield return new WaitForSeconds(time);
        MidstUI<AFuelInner>();
    }
}