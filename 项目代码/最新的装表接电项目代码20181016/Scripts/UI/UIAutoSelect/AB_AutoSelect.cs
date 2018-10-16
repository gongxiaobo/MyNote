using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 在选择场景，指定章节的选择
     /// </summary>
     public abstract class AB_AutoSelect : MonoBehaviour
     {

          // Use this for initialization
          protected virtual void Start()
          {

          }
          /// <summary>
          /// 开始选择指定的章节
          /// </summary>
          public abstract void fn_selectChapter();

     } 
}
