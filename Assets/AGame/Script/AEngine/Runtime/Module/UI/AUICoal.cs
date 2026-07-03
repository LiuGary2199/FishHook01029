using System;
using UnityEngine;

/// <summary>
/// UI基类。
/// </summary>
public class AUICoal : MonoBehaviour
{
      /// <summary>
      /// UI类型。
      /// </summary>
      public enum UIType
      {
            /// <summary>
            /// 类型无。
            /// </summary>
            None,

            /// <summary>
            /// 类型Windows。
            /// </summary>
            Window,

            /// <summary>
            /// 类型Widget。
            /// </summary>
            Widget,
      }
      
      /// <summary>
      /// 自定义数据集。
      /// </summary>
      protected System.Object[] _SwimErupt;
        
      /// <summary>
      /// 自定义数据。
      /// </summary>
      public System.Object LimeLade      {
            get
            {
                  if (_SwimErupt != null && _SwimErupt.Length >= 1)
                  {
                        return _SwimErupt[0];
                  }
                  else
                  {
                        return null;
                  }
            }
      }

      /// <summary>
      /// 自定义数据集。
      /// </summary>
      public System.Object[] LimeErupt=> _SwimErupt;
      
      /// <summary>
      /// UI类型。
      /// </summary>
      public virtual UIType Seat=> UIType.None;
      
      /// <summary>
      /// 窗口创建。
      /// </summary>
      public virtual void OnCreate()
      {
            
      }
      
      public virtual void OnClose()
      {
            DealerSapUIWrong();
            DealerSapUIClump();
      }
      
      /// <summary>
      /// 窗口刷新。
      /// </summary>
      public virtual void OnRefresh()
      {
      }
      
      private AWrongAsk _GloryAsk;

      protected AWrongAsk WrongAsk      {
            get
            {
                  if (_GloryAsk == null)
                  {
                        _GloryAsk = new AWrongAsk();
                  }

                  return _GloryAsk;
            }
      }
      
      #region Add Event
      protected void PutUIWrong(string eventType, Action handler)
      {
            WrongAsk.PutWrong(eventType, handler);
      }

      protected void PutUIWrong<T>(string eventType, Action<T> handler)
      {
            WrongAsk.PutWrong(eventType, handler);
      }

      protected void PutUIWrong<T1, T2>(string eventType, Action<T1, T2> handler)
      {
            WrongAsk.PutWrong(eventType, handler);
      }

      protected void PutUIWrong<T1, T2, T3>(string eventType, Action<T1, T2, T3> handler)
      {
            WrongAsk.PutWrong(eventType, handler);
      }

      protected void PutUIWrong<T1, T2, T3, T4>(string eventType, Action<T1, T2, T3, T4> handler)
      {
            WrongAsk.PutWrong(eventType, handler);
      }
      
      protected void PutUIWrong<T1, T2, T3, T4, T5>(string eventType, Action<T1, T2, T3, T4, T5> handler)
      {
            WrongAsk.PutWrong(eventType, handler);
      }
      
      protected void PutUIWrong<T1, T2, T3, T4, T5, T6>(string eventType, Action<T1, T2, T3, T4, T5, T6> handler)
      {
            WrongAsk.PutWrong(eventType, handler);
      }
      #endregion
      
      #region Remove Event
      protected void DealerUIWrong(string eventType, Action handler)
      {
            WrongAsk.DealerWrong(eventType, handler);
      }
      
      protected void DealerSapUIWrong()
      {
            if (_GloryAsk != null)
            {
                  _GloryAsk.Clear();
            }
      }
      #endregion
      
      #region Send Event
      public void PortUIWrong(string eventType)
      {
            AWrongFamous.Port(eventType);
      }
    
      public void PortUIWrong<T>(string eventType, T arg)
      {
            AWrongFamous.Port(eventType, arg);
      }

      public void PortUIWrong<T1, T2>(string eventType, T1 arg1, T2 arg2)
      {
            AWrongFamous.Port(eventType, arg1, arg2);
      }
    
      public void PortUIWrong<T1, T2, T3>(string eventType, T1 arg1, T2 arg2, T3 arg3)
      {
            AWrongFamous.Port(eventType, arg1, arg2, arg3);
      }
    
      public void PortUIWrong<T1, T2, T3, T4>(string eventType, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
      {
            AWrongFamous.Port(eventType, arg1, arg2, arg3, arg4);
      }
    
      public void PortUIWrong<T1, T2, T3, T4, T5>(string eventType, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
      {
            AWrongFamous.Port(eventType, arg1, arg2, arg3, arg4, arg5);
      }
      
      public void PortUIWrong<T1, T2, T3, T4, T5, T6>(string eventType, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
      {
            AWrongFamous.Port(eventType, arg1, arg2, arg3, arg4, arg5, arg6);
      }
      
      #endregion

      #region UITimer
      private AClumpAsk _BoardAsk;

      protected AClumpAsk ClumpAsk      {
            get
            {
                  if (_BoardAsk == null)
                  {
                        _BoardAsk = new AClumpAsk();
                  }
                  
                  return _BoardAsk;
            }
      }

      protected int PutClump(TimerHandler callback, float time, bool isLoop = false, bool isUnscaled = false,
            params object[] args)
      {
            return ClumpAsk.PutClump(callback, time, isLoop, isUnscaled, args);
      }
      
      protected void DealerClump(int id)
      {
            ClumpAsk.DealerClump(id);
      }
      
      protected void DealerSapUIClump()
      {
            if (_BoardAsk != null)
            {
                  _BoardAsk.Clear();
            }
      }
      #endregion
}