using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;

public class UtahHalt : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("m_ShipSkeleton")]
    public SkeletonGraphic m_UtahPossible;
    private string UtahBergHaltCoin= "idle_blank";
    private string UtahHumpHaltCoin= "idle_fire";
[UnityEngine.Serialization.FormerlySerializedAs("m_GunGraphic")]    public SkeletonGraphic m_GunDiamond;
    private string StyHumpGaze= "idle_blank";
    private string StyLaSurgeon= "idle_cock";
    private string StyHump= "idle_fire";
    private string StyLSoGongGaze= "idle_fully";



    public void Rail()
    {
        m_UtahPossible.AnimationState.Complete += OnShipAnimComplete;
        m_GunDiamond.AnimationState.Complete += OnGunAnimComplete;
        m_UtahPossible.AnimationState.SetAnimation(0, UtahBergHaltCoin, true);
        m_GunDiamond.AnimationState.SetAnimation(0, StyLaSurgeon, false);

    }
    public void FoodUtahHump()
    {
        m_UtahPossible.AnimationState.SetAnimation(0, UtahHumpHaltCoin, false);
    }
    public void FoodStyHump()
    {
        m_GunDiamond.Skeleton.SetToSetupPose();
        m_GunDiamond.AnimationState.ClearTracks();
        var entry =  m_GunDiamond.AnimationState.SetAnimation(0, StyHump, false);
        if (entry != null) entry.TimeScale = 5;
    }
     public void FoodStySoSurgeon()
    {
         m_GunDiamond.Skeleton.SetToSetupPose();
        m_GunDiamond.AnimationState.ClearTracks();
        var entry = m_GunDiamond.AnimationState.SetAnimation(0, StyLaSurgeon, false);
        if (entry != null)
        {
            bool isFerverTime = RopeStrange.Instance != null && RopeStrange.Instance.RopeToll == GameType.FerverTime;
            entry.TimeScale = isFerverTime ? 8f : 0.4f;
        }
    }

    public void OnShipAnimComplete(TrackEntry trackEntry)
    {
        if (trackEntry == null || trackEntry.Animation == null) return;
        if (string.IsNullOrEmpty(UtahHumpHaltCoin)) return;

        if (trackEntry.Animation.Name == UtahHumpHaltCoin)
        {
            m_UtahPossible.AnimationState.SetAnimation(0, UtahBergHaltCoin, true);
        }
    }
    public void OnGunAnimComplete(TrackEntry trackEntry)
    {
        if (trackEntry == null || trackEntry.Animation == null) return;
        if (string.IsNullOrEmpty(StyHumpGaze)) return;

        if (trackEntry.Animation.Name == StyHumpGaze)
        {
            m_GunDiamond.AnimationState.SetAnimation(0, StyHump, true);
        }
    }
}
