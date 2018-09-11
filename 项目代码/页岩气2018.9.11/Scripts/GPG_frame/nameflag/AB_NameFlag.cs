using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 物体编号的配置
     /// </summary>
     public abstract class AB_NameFlag : MonoBehaviour
     {
          /// <summary>
          /// 获取当前物体的名称ID
          /// </summary>
          public abstract int M_nameID { get; set; }
          /// <summary>
          /// 类型名称
          /// </summary>
          public abstract E_YaobaType Me_Type { get; set; }

     } 
}
