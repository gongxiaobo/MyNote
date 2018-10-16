using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 隐藏，显示
     /// </summary>
     public abstract class AB_HideModel : MonoBehaviour
     {
          /// <summary>
          /// 显示或者隐藏此节点下的模型
          /// false 不显示
          /// </summary>
          /// <param name="_isShow"></param>
          public abstract void fn_hide(bool _isShow);
     }

}