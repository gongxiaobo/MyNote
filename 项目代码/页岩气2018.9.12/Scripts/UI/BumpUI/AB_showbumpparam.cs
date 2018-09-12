using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 泵的表的参数显示类型
     /// </summary>
     public abstract class AB_showbumpparam : MonoBehaviour, I_bumpshowparam
     {

          //泵的参数id尾号
          public int index;
          /// <summary>
          /// item id 的最后两位
          /// </summary>
          public int param_index
          {
               get
               {
                    return index;
               }

          }


          public virtual void fn_set_value(string value)
          {

          }


     }

}