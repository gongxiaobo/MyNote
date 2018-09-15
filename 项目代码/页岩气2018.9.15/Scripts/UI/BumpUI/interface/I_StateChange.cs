using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 实现这个接口的类在泵的一个参数被改变时会被通知
     /// </summary>
     public interface I_StateChange
     {
          void fni_itemChange(int _itemID);

     } 
}
