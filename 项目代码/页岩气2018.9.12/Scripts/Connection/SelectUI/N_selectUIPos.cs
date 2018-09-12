using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 选择UI的位置注册
     /// </summary>
     public class N_selectUIPos : MonoBehaviour
     {

          // Use this for initialization
          void Start()
          {
               if (this.gameObject.name == "RopeSelect")
               {
                    S_selectUI.Instance.m_RopeSelect = this.gameObject.transform;
               }
               else if (this.gameObject.name == "StepDetail")
               {
                    S_selectUI.Instance.m_StepDetail = this.gameObject.transform;
               }
               this.gameObject.transform.position = new Vector3(0f, -1000f, 0f);
               Destroy(this);
          }


     } 
}
