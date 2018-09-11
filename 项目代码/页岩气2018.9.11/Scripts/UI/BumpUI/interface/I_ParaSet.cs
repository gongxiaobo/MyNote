using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     /// <summary>
     /// 一个变化值的传递
     /// </summary>
     public interface I_ParaSet 
     {
         /// <summary>
         /// 传递一个string 类型的值
         /// </summary>
         /// <param name="_value"></param>
          void fni_newParaSet(float _value);
          
     }

}