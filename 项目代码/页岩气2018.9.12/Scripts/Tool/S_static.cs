using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 静态扩展类
     /// </summary>
     public static class S_static
     {
          /// <summary>
          /// 对gameobject的扩展方法，显示和隐藏meshrender
          /// </summary>
          /// <param name="_thisObj"></param>
          /// <param name="_hide"></param>
          public static void fns_closeMeshRender(this GameObject _thisObj, bool _hide)
          {
               if (_thisObj == null)
               {
                    return;
               }
               MeshRenderer t_meshrender = _thisObj.GetComponent<MeshRenderer>();
               if (t_meshrender != null)
               {
                    t_meshrender.enabled = _hide;
               }
          }


          public static float fns_clamp01(float _min, float _max, float _value)
          {

               _value = (_value <= _min) ? _min : _value;
               _value = _value >= 1f ? _max : _value;
               return _value;
          }
          //public static float fns_mathf(this Mathf _math,)
     }

}