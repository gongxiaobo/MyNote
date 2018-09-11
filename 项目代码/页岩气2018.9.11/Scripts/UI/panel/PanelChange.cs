using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace GasPowerGeneration
{
     public class PanelChange : MonoBehaviour
     {

          private List<I_paramshow> paramlist = new List<I_paramshow>();
          private int param_index;
          // Use this for initialization
          void Start()
          {
               var group = transform.Find("Loop");
               for (int i = 0; i < group.childCount; i++)
               {
                    paramlist.Add(group.GetChild(i).GetComponent<I_paramshow>());
               }
          }
          /// <summary>
          /// 改变显示参数
          /// </summary>
          public void Param_change()
          {
               int temp = 0;
               foreach (var item in paramlist)
               {
                    RectTransform rect = item.fn_getrect();
                    if (temp == param_index)
                    {
                         rect.DOScale(1, 0);

                    }
                    else
                         rect.DOScale(0, 0);
                    temp++;

               }
               param_index++;
               if (param_index >= paramlist.Count)
                    param_index = 0;
          }
     }

}