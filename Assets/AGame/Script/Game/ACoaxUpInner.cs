using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ACoaxUpInner : AUIDrench
{
[UnityEngine.Serialization.FormerlySerializedAs("BtnClose")]    public Button AnyMidst;
[UnityEngine.Serialization.FormerlySerializedAs("BtnCollect")]    public Button AnyEyeball;
[UnityEngine.Serialization.FormerlySerializedAs("mDailyItems")]    public List<AHaitiWish> mHaitiChick;

    private int mEyeballWary;

    private int[] Helpful= new int[7] { 50, 100, 100, 100, 200, 200, 500 };

    public override void OnCreate()
    {
        base.OnCreate();

        AnyMidst.onClick.AddListener(MidstUI);

        AnyEyeball.onClick.AddListener(() =>
        {
            var lastSignInDateStr = PlayerPrefs.GetString(AConserve.ArchiveKey.RiftCoaxUpReal_A);
            if (DateTime.Now.ToString("yyyy-MM-dd").Equals(lastSignInDateStr))
            {
                return;
            }
            AReapEarning.Slowness.PlaySpur += Helpful[mEyeballWary];

            mHaitiChick[mEyeballWary].mTranscend.SetActive(false);
            mHaitiChick[mEyeballWary].mTranscendFare.SetActive(true);
            mHaitiChick[mEyeballWary].mYield.SetActive(false);
            mHaitiChick[mEyeballWary].mNutritious.SetActive(false);
            mEyeballWary = (mEyeballWary + 1) % mHaitiChick.Count;
            AnyEyeball.interactable = false;
            AnyEyeball.GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f);
            PlayerPrefs.SetInt(AConserve.ArchiveKey.EyeballWary_A, mEyeballWary);
            PlayerPrefs.SetString(AConserve.ArchiveKey.RiftCoaxUpReal_A, DateTime.Now.ToString("yyyy-MM-dd"));
        });
    }

    public override void OnRefresh()
    {
        base.OnRefresh();

        mEyeballWary = PlayerPrefs.GetInt(AConserve.ArchiveKey.EyeballWary_A, 0);
        mEyeballWary %= mHaitiChick.Count;
        AHaitiWish item;
        for (int i = 0; i < mHaitiChick.Count; i++)
        {
            item = mHaitiChick[i];
            item.CityEre.text = Helpful[i].ToString();
            if (i < mEyeballWary)
            {
                item.mTranscend.SetActive(false);
                item.mTranscendFare.SetActive(true);
                item.mNutritious.SetActive(false);
                item.mYield.SetActive(false);
            }
            else
            {
                if (!DateTime.Now.ToString("yyyy-MM-dd").Equals(PlayerPrefs.GetString(AConserve.ArchiveKey.RiftCoaxUpReal_A)) && i == mEyeballWary)
                {
                    Debug.Log("111111111111");
                    item.mNutritious.SetActive(true);
                    item.mTranscendFare.SetActive(false);
                    //item.mReady.SetActive(true);
                }
                else
                {
                    item.mTranscend.SetActive(false);
                    item.mTranscendFare.SetActive(false);
                    item.mYield.SetActive(false);
                    item.mNutritious.SetActive(true);
                }
            }
        }

        var lastSignInDateStr = PlayerPrefs.GetString(AConserve.ArchiveKey.RiftCoaxUpReal_A);
        if (!DateTime.Now.ToString("yyyy-MM-dd").Equals(lastSignInDateStr))
        {
            AnyEyeball.interactable = true;
            AnyEyeball.GetComponent<Image>().color = new Color(1, 1, 1);
            mHaitiChick[mEyeballWary].mTranscend.SetActive(false);
            mHaitiChick[mEyeballWary].mTranscendFare.SetActive(false);
            mHaitiChick[mEyeballWary].mNutritious.SetActive(true);
        }
        else
        {
            AnyEyeball.interactable = false;
            AnyEyeball.GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f);
        }
    }
}
