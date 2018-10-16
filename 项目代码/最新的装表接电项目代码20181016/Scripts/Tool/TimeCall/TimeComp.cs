using UnityEngine;
using System.Collections;

namespace GasPowerGeneration
{

     //namespace VRPT.Teaching
     //{
     public abstract class A_TimeComp : MonoBehaviour, I_pause
     {

          protected TimeCount1 timecount1 = new TimeCount1();
          protected bool startCount = false;

          protected virtual void FixedUpdate()
          {
          }

          abstract public void initial(float callSpace, TimeCount.callFunction call);

          abstract public void Kill();

          protected bool isPause = true;
          //暂停
          public void fni_pause()
          {
               isPause = true;
          }

          public void fni_restart()
          {
               isPause = false;
          }
     }

     /// <summary>
     /// 组件
     /// 间隔时间调用需要调用的函数
     /// </summary>
     public class TimeComponent : A_TimeComp
     {
          protected override void FixedUpdate()
          {
               if (!isPause)
               {
                    base.FixedUpdate();
                    if (startCount)
                         timecount1.CallTime(Time.deltaTime);
               }
          }

          public override void initial(float callSpace, TimeCount.callFunction call)
          {
               if (startCount)
                    return;
               isPause = false;
               timecount1.SetCallSpace(callSpace, call);
               startCount = true;
          }

          public override void Kill()
          {
               isPause = true;
               startCount = false;
               timecount1.Reset();
               timecount1 = null;
               Destroy(this);

          }

     }

     public interface I_pause
     {
          void fni_pause();

          void fni_restart();
     }
     //}


}