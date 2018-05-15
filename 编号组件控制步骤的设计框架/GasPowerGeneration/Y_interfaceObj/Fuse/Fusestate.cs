using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 熔断器显示控制类
     /// </summary>
     public class Fusestate : MonoBehaviour
     {

          public void Link()
          {

               TransformHelper.FindChild(transform, "Fuse").gameObject.SetActive(true);
          }
          public void LinkOff()
          {


               TransformHelper.FindChild(transform, "Fuse").gameObject.SetActive(false);
          }
     }

}