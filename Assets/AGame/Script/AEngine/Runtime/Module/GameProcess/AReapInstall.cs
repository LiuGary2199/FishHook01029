using System;
using UnityEngine;

public class AReapInstall : AAuthorizeCriticize<AReapInstall>
{
    private bool _AtCook= false;
    public DateTime UpliftYork    {
        get
        {
            var loginTimeStr = PlayerPrefs.GetString(AConserve.ArchiveKey.AUplift, "");
            return DateTime.TryParse(loginTimeStr, out var loginTime) ? loginTime : DateTime.Now;
        }
        private set
        {
            PlayerPrefs.SetString(AConserve.ArchiveKey.AUplift, value.ToString("yyyy/MM/dd HH:mm:ss"));
            Debug.Log($"上线时间：{value:yyyy/MM/dd HH:mm:ss}");
        }
    }

    public DateTime SpatialYork    {
        get
        {
            var outlineTimeStr = PlayerPrefs.GetString(AConserve.ArchiveKey.ASpatial, "");
            return DateTime.TryParse(outlineTimeStr, out var outlineTime) ? outlineTime : UpliftYork;
        }
        private set
        {
            PlayerPrefs.SetString(AConserve.ArchiveKey.ASpatial, value.ToString("yyyy/MM/dd HH:mm:ss"));
            Debug.Log($"离线时间：{value:yyyy/MM/dd HH:mm:ss}");
        }
    } 
    
    public void Cook()
    {
        _AtCook = true;
        UpliftYork = DateTime.Now;
        AWrongFamous.Port(AWrongSeat.AnReapUplift);
    }
    
    private void OnApplicationPause(bool pauseStatus)
    {
        if (Application.platform == RuntimePlatform.Android 
            || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            OnlineChange(!pauseStatus);
        }
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            OnlineChange(hasFocus);
        }
    }

    private void OnlineChange(bool isOnline)
    {
        if (!_AtCook) return;
        if (isOnline)
        {
            UpliftYork = DateTime.Now;
            AWrongFamous.Port(AWrongSeat.AnReapUplift);
            
        }
        else
        {
            SpatialYork = DateTime.Now;
            AWrongFamous.Port(AWrongSeat.AnReapSpatial);
        }
        PlayerPrefs.Save();
    }
}