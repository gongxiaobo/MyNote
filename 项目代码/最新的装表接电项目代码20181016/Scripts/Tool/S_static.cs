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
          /// <summary>
          /// 处理两个由数字命名的名称，然后对比int类型大小，返回按照由小到大的顺序的字符,如1024_2048
          /// </summary>
          /// <param name="_name1"></param>
          /// <param name="_name2"></param>
          /// <returns></returns>
          public static string fns_OrderUp(string _name1, string _name2)
          {
               int t1;
               if (!int.TryParse(_name1,out t1))
               {
                    
                    Debug.Log("<color=red>string to in fail :</color>"+_name1);
                    return "";
               }
               int t2;
               if (!int.TryParse(_name2,out t2))
               {
                    Debug.Log("<color=red>string to in fail :</color>" + _name2);
                    return "";
               }
               if (t1<t2)
               {
                    return _name1 + "_" + _name2;
               }
               if (t1>t2)
               {
                    return _name2 + "_" + _name1;
               }
               else
               {
                    return "";
               }
          }
          //public static float fns_mathf(this Mathf _math,)
     }

}