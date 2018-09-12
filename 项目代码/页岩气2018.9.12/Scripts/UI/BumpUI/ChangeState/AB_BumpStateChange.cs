using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 泵的一个参数改变后，向管理类发送是那个参数改变，然后通知所有的其他参数
     /// </summary>
     public abstract class AB_BumpStateChange : MonoBehaviour
     {

          public abstract void fn_itemChange(int _itemID);
     } 
}
