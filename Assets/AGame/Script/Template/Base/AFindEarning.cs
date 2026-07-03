using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFindEarning : AAuthorizeCriticize<AFindEarning>
{
[UnityEngine.Serialization.FormerlySerializedAs("DailySignIn_Id")]    public const int HaitiCoaxUp_Id= 0;
[UnityEngine.Serialization.FormerlySerializedAs("DailyAD_Id")]    public const int HaitiAD_So= 1;
[UnityEngine.Serialization.FormerlySerializedAs("DailyBreak_Id")]    public const int HaitiSteer_So= 2;
[UnityEngine.Serialization.FormerlySerializedAs("DailyGame_Id")]    public const int HaitiReap_So= 3;
[UnityEngine.Serialization.FormerlySerializedAs("DailyBox1_Id")]
    public const int HaitiBog1_So= 0;
[UnityEngine.Serialization.FormerlySerializedAs("DailyBox2_Id")]    public const int HaitiBog2_So= 1;
[UnityEngine.Serialization.FormerlySerializedAs("DailyBox3_Id")]    public const int HaitiBog3_So= 2;
[UnityEngine.Serialization.FormerlySerializedAs("WeeklySignIn_Id")]
    public const int RarityCoaxUp_So= 0;
[UnityEngine.Serialization.FormerlySerializedAs("WeeklyAD_Id")]    public const int RarityAD_So= 1;
[UnityEngine.Serialization.FormerlySerializedAs("WeeklyBreak_Id")]    public const int RaritySteer_So= 2;
[UnityEngine.Serialization.FormerlySerializedAs("WeeklyGame_Id")]    public const int RarityReap_So= 3;
[UnityEngine.Serialization.FormerlySerializedAs("WeeklyBox1_Id")]
    public const int RarityBog1_So= 0;
[UnityEngine.Serialization.FormerlySerializedAs("WeeklyBox2_Id")]    public const int RarityBog2_So= 1;
[UnityEngine.Serialization.FormerlySerializedAs("WeeklyBox3_Id")]    public const int RarityBog3_So= 2;

    public int JobHaitiBundle(int id)
    {
        switch (id)
        {
            case HaitiCoaxUp_Id:
                return 1;
            case HaitiAD_So:
                return 2;
            case HaitiSteer_So:
                return 5;
            case HaitiReap_So:
                return 3;
        }
        return 0;
    }

    public int JobRarityBundle(int id)
    {
        switch (id)
        {
            case RarityCoaxUp_So:
                return 5;
            case RarityAD_So:
                return 10;
            case RaritySteer_So:
                return 30;
            case RarityReap_So:
                return 20;
        }
        return 0;
    }

    public int JobRarityBogSpur(int id)
    {
        switch (id)
        {
            case RarityBog1_So:
                return 150;
            case RarityBog2_So:
                return 300;
            case RarityBog3_So:
                return 600;
            default:
                return 0;
        }
    }

    public int JobHaitiBogSpur(int id)
    {
        switch (id)
        {
            case HaitiBog1_So:
                return 50;
            case HaitiBog2_So:
                return 100;
            case HaitiBog3_So:
                return 200;
            default:
                return 0;
        }
    }

    public int JobHaitiBundleHaste(int id)
    {
        var day = DateTime.Now.ToString("yyyy-MM-dd");
        return id switch
        {
            HaitiCoaxUp_Id => //ǩ��
                PlayerPrefs.GetInt(AConserve.ArchiveKey.HaitiCoaxUpHaste + day, 0),
            HaitiAD_So => //������
                PlayerPrefs.GetInt(AConserve.ArchiveKey.HaitiADHaste + day, 0),
            HaitiSteer_So => //����
                PlayerPrefs.GetInt(AConserve.ArchiveKey.HaitiFogMyHaste + day, 0),
            HaitiReap_So => //�Ծ�
                PlayerPrefs.GetInt(AConserve.ArchiveKey.HaitiReapHaste + day, 0),
            _ => 0
        };
    }

    public void PutHaitiBundleHaste(int id, int value)
    {
        var day = DateTime.Now.ToString("yyyy-MM-dd");
        switch (id)
        {
            case HaitiCoaxUp_Id:
                PlayerPrefs.SetInt(AConserve.ArchiveKey.HaitiCoaxUpHaste + day, JobHaitiBundleHaste(id) + value);
                break;
            case HaitiAD_So:
                PlayerPrefs.SetInt(AConserve.ArchiveKey.HaitiADHaste + day, JobHaitiBundleHaste(id) + value);
                break;
            case HaitiSteer_So:
                PlayerPrefs.SetInt(AConserve.ArchiveKey.HaitiFogMyHaste + day, JobHaitiBundleHaste(id) + value);
                break;
            case HaitiReap_So:
                PlayerPrefs.SetInt(AConserve.ArchiveKey.HaitiReapHaste + day, JobHaitiBundleHaste(id) + value);
                break;
        }
    }

    public int JobRarityBundleHaste(int id)
    {
        var date = DateTime.Now;
        return id switch
        {
            RarityCoaxUp_So => JobRarityFindHaste(AConserve.ArchiveKey.HaitiCoaxUpHaste, date),
            RarityAD_So => JobRarityFindHaste(AConserve.ArchiveKey.HaitiADHaste, date),
            RaritySteer_So => JobRarityFindHaste(AConserve.ArchiveKey.HaitiFogMyHaste, date),
            RarityReap_So => JobRarityFindHaste(AConserve.ArchiveKey.HaitiReapHaste, date),
            _ => 0
        };
    }

    private int JobRarityFindHaste(string key, DateTime date)
    {
        var count = 0;
        for (int i = 0; i < 7; i++)
        {
            var day = date.AddDays(-i).ToString("yyyy-MM-dd");
            count += PlayerPrefs.GetInt(key + day, 0);
        }
        return count;
    }

    public float HaitiAnteater    {
        get
        {
            var progress = 0f;
            if (JobFindIsraelHaiti(HaitiCoaxUp_Id) == TaskStatus_A.Completed)
            {
                progress += 0.15f;
            }
            if (JobFindIsraelHaiti(HaitiAD_So) == TaskStatus_A.Completed)
            {
                progress += 0.40f;
            }
            if (JobFindIsraelHaiti(HaitiSteer_So) == TaskStatus_A.Completed)
            {
                progress += 0.2f;
            }
            if (JobFindIsraelHaiti(HaitiReap_So) == TaskStatus_A.Completed)
            {
                progress += 0.25f;
            }

            return progress;
        }

    }

    public int HaitiFindTranscendHaste    {
        get
        {
            var count = 0;
            if (JobFindIsraelHaiti(HaitiCoaxUp_Id) == TaskStatus_A.Completed)
            {
                count++;
            }

            if (JobFindIsraelHaiti(HaitiAD_So) == TaskStatus_A.Completed)
            {
                count++;
            }

            if (JobFindIsraelHaiti(HaitiSteer_So) == TaskStatus_A.Completed)
            {
                count++;
            }

            if (JobFindIsraelHaiti(HaitiReap_So) == TaskStatus_A.Completed)
            {
                count++;
            }

            return count;
        }
    }

    public float RarityAnteater    {
        get
        {
            var progress = 0f;
            if (JobFindIsraelRarity(RarityCoaxUp_So) == TaskStatus_A.Completed)
            {
                progress += 0.15f;
            }

            if (JobFindIsraelRarity(RarityAD_So) == TaskStatus_A.Completed)
            {
                progress += 0.40f;
            }

            if (JobFindIsraelRarity(RaritySteer_So) == TaskStatus_A.Completed)
            {
                progress += 0.2f;
            }

            if (JobFindIsraelRarity(RarityReap_So) == TaskStatus_A.Completed)
            {
                progress += 0.25f;
            }

            return progress;
        }
    }

    public int RarityFindTranscendHaste    {
        get
        {
            var count = 0;
            if (JobFindIsraelRarity(RarityCoaxUp_So) == TaskStatus_A.Completed)
            {
                count++;
            }
            if (JobFindIsraelRarity(RarityAD_So) == TaskStatus_A.Completed)
            {
                count++;
            }
            if (JobFindIsraelRarity(RaritySteer_So) == TaskStatus_A.Completed)
            {
                count++;
            }
            if (JobFindIsraelRarity(RarityReap_So) == TaskStatus_A.Completed)
            {
                count++;
            }

            return count;
        }
    }

    public void DieFindTranscendHaiti(int id)
    {
        var key = $"Task_Daily_A_{id}" + DateTime.Now.ToString("yyyy-MM-dd");
        DieFindTranscend(key);
    }

    public TaskStatus_A JobFindIsraelHaiti(int id)
    {
        var key = $"Task_Daily_A_{id}" + DateTime.Now.ToString("yyyy-MM-dd");
        if (SoFindTranscend(key))
        {
            return TaskStatus_A.Completed;
        }
        return JobHaitiBundleHaste(id) >= JobHaitiBundle(id) ? TaskStatus_A.Ready : TaskStatus_A.Incomplete;
    }

    public void DieFindBogTranscendHaiti(int id)
    {
        var key = $"TaskBox_Daily_A_{id}" + DateTime.Now.ToString("yyyy-MM-dd");
        DieFindBogTranscend(key);
    }

    public TaskBoxStatus_A JobFindBogIsraelHaiti(int id)
    {
        var key = $"TaskBox_Daily_A_{id}" + DateTime.Now.ToString("yyyy-MM-dd");
        if (SoFindBogTranscend(key))
        {
            return TaskBoxStatus_A.Completed;
        }
        var progress = HaitiAnteater;
        switch (id)
        {
            case HaitiBog1_So:
                return progress >= 0.3f ? TaskBoxStatus_A.Ready : TaskBoxStatus_A.Incomplete;
            case HaitiBog2_So:
                return progress >= 0.6f ? TaskBoxStatus_A.Ready : TaskBoxStatus_A.Incomplete;
            case HaitiBog3_So:
                return progress >= 1f ? TaskBoxStatus_A.Ready : TaskBoxStatus_A.Incomplete;
            default:
                return 0f;
        }
    }

    public void DieFindTranscendRarity(int id)
    {
        var key = $"Task_Weekly_A_{id}";
        DieFindTranscend(key);
    }

    public TaskStatus_A JobFindIsraelRarity(int id)
    {
        var key = $"Task_Weekly_A_{id}";
        if (SoFindTranscend(key))
        {
            return TaskStatus_A.Completed;
        }
        return JobRarityBundleHaste(id) >= JobRarityBundle(id) ? TaskStatus_A.Ready : TaskStatus_A.Incomplete;
    }

    public void DieFindBogTranscendRarity(int id)
    {
        var key = $"TaskBox_Weekly_A_{id}";
        DieFindBogTranscend(key);
    }

    public TaskBoxStatus_A JobFindBogIsraelRarity(int id)
    {
        var key = $"TaskBox_Weekly_A_{id}";
        if (SoFindBogTranscend(key))
        {
            return TaskBoxStatus_A.Completed;
        }

        var progress = RarityAnteater;
        switch (id)
        {
            case RarityBog1_So:
                return progress >= 0.3f ? TaskBoxStatus_A.Ready : TaskBoxStatus_A.Incomplete;
            case RarityBog2_So:
                return progress >= 0.6f ? TaskBoxStatus_A.Ready : TaskBoxStatus_A.Incomplete;
            case RarityBog3_So:
                return progress >= 1f ? TaskBoxStatus_A.Ready : TaskBoxStatus_A.Incomplete;
            default:
                return 0f;
        }
    }

    #region ����

    private bool SoFindTranscend(string id)
    {
        return PlayerPrefs.GetInt(id, 0) == 1;
    }

    private void DieFindTranscend(string id)
    {
        PlayerPrefs.SetInt(id, 1);
    }

    private bool SoFindBogTranscend(string id)
    {
        return PlayerPrefs.GetInt(id, 0) == 1;
    }

    private void DieFindBogTranscend(string id)
    {
        PlayerPrefs.SetInt(id, 1);
    }

    #endregion
}
