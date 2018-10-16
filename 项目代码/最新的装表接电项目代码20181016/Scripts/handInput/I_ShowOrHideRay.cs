using UnityEngine;
using System.Collections;
namespace GasPowerGeneration
{
     ///<summary>
     ///@ version 1.0 /2017.0206/ :射线的显示和隐藏接口
     ///@ author gong
     ///@ version 1.1 /2017./ :
     ///@ author gong
     ///@ version 1.2 /2017./ :
     ///@ author gong
     ///@ version 1.3 /2017./ :
     ///@ author gong
     ///</summary>
     public interface I_ShowOrHideRay
     {
          /// <summary>
          /// 显示射线
          /// </summary>
          void fni_showRay();
          /// <summary>
          /// 隐藏射线
          /// </summary>
          void fni_hidRay();


     }

     /// <summary>
     /// 获取当前射线选中的物体
     /// </summary>
     public interface I_GetTriggerObj
     {

          /// <summary>
          /// 获取当前射线选中的物体
          /// </summary>
          /// <returns>A_TriggerObj</returns>
          A_TriggerObj fni_getControl();
     }

}