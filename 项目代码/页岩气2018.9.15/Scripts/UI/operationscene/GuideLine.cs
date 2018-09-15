using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace GasPowerGeneration
{
     /// <summary>
     /// 控制提示UI提示线
     /// </summary>
     public class GuideLine : MonoBehaviour
     {

          private Transform movepos;
          private Transform objpos;
          private Transform managerpos;
          LineRenderer render;

          void Start()
          {
               render = GetComponent<LineRenderer>();
               movepos = TransformHelper.FindChild(transform, "movepos");
               managerpos = TransformHelper.FindChild(transform, "managerpos");

          }

          //显示引导线
          public void fn_showline(Transform uipos, Transform objpos)
          {


               movepos.position = objpos.position;
               render.enabled = true;
               AB_LightOneObj t_light = objpos.GetComponentInChildren<N_LightOneObj>();
               Transform temp = (t_light != null) ? t_light.transform : null;
               if (temp != null)
                    this.objpos = temp;
               else
                    this.objpos = uipos;
          }

          public void fn_hideline()
          {
               render.enabled = false;
               this.objpos = null;
          }
          void Update()
          {
               if (objpos != null)
               {
                    render.SetPosition(0, objpos.position);
                    render.SetPosition(1, managerpos.position);
               }
          }

     }

}