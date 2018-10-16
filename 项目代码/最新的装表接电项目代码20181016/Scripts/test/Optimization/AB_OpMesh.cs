using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Assets.Scripts.test.Optimization
{
     /// <summary>
     /// 对优化物体添加的隐藏显示配置组件
     /// </summary>
     public abstract class AB_OpMesh : MonoBehaviour
     {

          protected virtual void Start(){}
          //public abstract void fn_kill();
          /// <summary>
          /// 注册
          /// </summary>
          protected abstract void fnp_log();
          public abstract string M_Name { get; set; }
          /// <summary>
          /// 显示和隐藏
          /// </summary>
          /// <param name="_hide"></param>
          public abstract void fn_hide(bool _hide = true);
          /// <summary>
          /// 是否显示或者隐藏
          /// </summary>
          /// <returns></returns>
          public abstract bool fn_hideState();
         
     }
}
