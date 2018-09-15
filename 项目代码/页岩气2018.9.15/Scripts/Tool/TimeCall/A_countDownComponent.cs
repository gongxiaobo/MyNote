using UnityEngine;
using System.Collections;
namespace GasPowerGeneration
{
     //using VRPT.Teaching;
     //namespace VRPT.Teaching
     //{
     ///<summary>
     ///@ version 1.0 /2017.0312/ :倒计时的组件抽象
     ///@ author gong
     ///@ version 1.1 /2017./ :
     ///@ author gong
     ///@ version 1.2 /2017./ :
     ///@ author gong
     ///@ version 1.3 /2017./ :
     ///@ author gong
     ///</summary>
     public abstract class A_countDownComponent : MonoBehaviour
     {

          protected N_countDown m_timecount1 = new N_countDown();

          protected virtual void FixedUpdate()
          {
          }

          abstract public void initial(float callSpace, TimeCount.callFunction call);

          abstract public void Kill();
     }
     //}

}