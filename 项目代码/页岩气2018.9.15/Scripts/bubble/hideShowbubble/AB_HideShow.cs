using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 显示隐藏
     /// </summary>
     public abstract class AB_HideShow : MonoBehaviour
     {
          //显示
          public abstract void fn_show();
          //隐藏
          public abstract void fn_hide();
     } 
}
