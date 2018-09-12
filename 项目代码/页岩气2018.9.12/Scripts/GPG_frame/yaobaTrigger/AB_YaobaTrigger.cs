using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 摇把的触发器
     /// </summary>
     public abstract class AB_YaobaTrigger : MonoBehaviour
     {
          /// <summary>
          /// 重置
          /// </summary>
          public abstract void fnp_reset();
          /// <summary>
          /// 放入需要摇入的位置
          /// </summary>
          protected abstract void fnp_putIn();
     } 
}
