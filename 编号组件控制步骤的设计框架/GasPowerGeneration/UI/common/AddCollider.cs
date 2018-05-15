using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace GasPowerGeneration
{
     /// <summary>
     /// 添加碰撞体类
     /// </summary>
     public class AddCollider : MonoBehaviour
     {

          private RectTransform rectTrans;
          public bool enable = true;
          // Use this for initialization
          void Awake()
          {
               if (enable == false) return;
               rectTrans = this.GetComponent<RectTransform>();
               //给按钮添加碰撞体组件
               BoxCollider collider = this.gameObject.AddComponent<BoxCollider>();

               GridLayoutGroup group = this.GetComponentInParent<GridLayoutGroup>();
               //如果父物体有grip组件就获取组件的每个元素尺寸值 
               //if (group.enabled==true)
               //{
               //    float x = group.cellSize.x;
               //    float y = group.cellSize.y;
               //    collider.size = new Vector3(x, y, 1);
               //}
               //    如果父物体没有grip组件把自身rect组件尺寸赋值给碰撞体尺寸
               //else
               collider.size = new Vector3(rectTrans.sizeDelta.x, rectTrans.sizeDelta.y, 1);

          }


     } 
}
