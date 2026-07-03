using System;

public class ADFormer
{
    public static void BulkTorporChimp(Action<bool> callback)
    {
#if Old_UIFramework
        AdCtrl.Instance.playRewardVideo(666, (b =>
        {
            callback?.Invoke(b);
        }));
#else
        ADStrange.Laurasia.DungTempleVigor((ok) =>
        {
            callback?.Invoke(ok);
        }, "a1");
#endif
    }
    
}