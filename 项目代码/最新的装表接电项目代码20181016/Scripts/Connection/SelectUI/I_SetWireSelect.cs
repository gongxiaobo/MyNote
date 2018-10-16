using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Connection.SelectUI
{
     /// <summary>
     /// 实现线的选择UI的设置，通过代码配置好将要链接线的属性
     /// </summary>
     public interface I_SetWireSelect
     {
          /// <summary>
          /// 链接线的属性,包括线的半径，颜色，软硬
          /// </summary>
          /// <param name="_twoPortInfo"></param>
          void fni_setWireSelect(string _twoPortInfo);
     }
}
