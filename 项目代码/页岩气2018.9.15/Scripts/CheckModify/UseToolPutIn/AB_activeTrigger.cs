using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 显示或者隐藏一个触发器
     /// </summary>
     public abstract class AB_activeTrigger : MonoBehaviour
     {
          /// <summary>
          /// 注册碰撞体信息
          /// </summary>
          /// <param name="_id"></param>
          public abstract void fn_setTriggerInfor(int _id);
          /// <summary>
          /// 设置触发器的显示和隐藏
          /// </summary>
          /// <param name="_show">true 为显示</param>
          public abstract void fn_setTrigger(bool _show = true);
     } 
}
