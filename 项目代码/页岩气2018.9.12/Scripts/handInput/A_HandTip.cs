using UnityEngine;
using System.Collections;
namespace GasPowerGeneration
{
     ///<summary>
     ///@ version 1.0 /2017.0220/ :手柄上的小提示UI基类
     ///@ author gong
     ///@ version 1.1 /2017./ :
     ///@ author gong
     ///@ version 1.2 /2017./ :
     ///@ author gong
     ///@ version 1.3 /2017./ :
     ///@ author gong
     ///</summary>
     public abstract class A_HandTip : MonoBehaviour
     {

          protected virtual void Start()
          {
               return;
          }

          /// <summary>
          /// 把handtipui加入手柄上,只初始化一次
          /// </summary>
          public abstract void fn_init();
          /// <summary>
          /// 显示handtip
          /// </summary>
          public abstract void fn_show();
          /// <summary>
          /// 隐藏handtip
          /// </summary>
          public abstract void fn_hide();
          /// <summary>
          /// 刷新handtip显示类容文字
          /// </summary>
          public abstract void fn_update(string _title, string _content);

          //
          /// <summary>
          /// 挂载音效
          /// </summary>
          /// <param name="_sound">Sound.</param>
          public abstract void fn_setVoice(AB_Sound _sound);

     }

}