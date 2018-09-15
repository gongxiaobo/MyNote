using UnityEngine;
using System.Collections;
namespace GasPowerGeneration
{
     ///<summary>
     ///@ version 1.0 /2017.0207/ :自动取消选择的物体
     ///@ author gong
     ///@ version 1.1 /2017./ :
     ///@ author gong
     ///@ version 1.2 /2017./ :
     ///@ author gong
     ///@ version 1.3 /2017./ :
     ///@ author gong
     ///</summary>
     public interface I_HandButton : I_HandRigid
     {
          /// <summary>
          /// 自动取消选择的物体
          /// </summary>
          void fni_autoRealse();
     }

     public interface I_HandRigid : I_Hand
     {
          /// <summary>
          /// 获取手柄的RigidBody
          /// </summary>
          /// <returns>The get hand rigid.</returns>
          Rigidbody fni_getHandRigid();
     }
     public interface I_Hand : I_HandButton01
     {
          /// <summary>
          /// 获取手的位置组件
          /// </summary>
          /// <returns>The get hand.</returns>
          Transform fni_getHand();
     }

     /// <summary>
     /// 被触发物体反馈手柄的事件
     /// </summary>
     public interface I_HandButton01
     {
          /// <summary>
          /// 反馈调用
          /// </summary>
          /// <param name="_bl"></param>
          void fni_callBack(bool _bl);
     } 
}