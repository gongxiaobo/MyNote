using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public enum handfusestate
     {
          /// <summary>
          /// 把手与断路器分离
          /// </summary>
          disconnect,
          /// <summary>
          /// 把手与断路器链接
          /// </summary>
          connect,
          /// <summary>
          /// 隐藏把手断路器
          /// </summary>
          hide,
          /// <summary>
          /// 显示把手断路器
          /// </summary>
          show,
     }

     public class Hand_handler_fuse : MonoBehaviour, I_holdhandfuse
     {

          public float judgedistance;
          public float judgeangle;
          /// <summary>
          /// 是否拾取中
          /// </summary>
          bool holding;
          /// <summary>
          /// 是否与定位点锁定
          /// </summary>
          bool lock_to_pos;


          private handfusestate h_f_state;
          /// <summary>
          /// 断路器
          /// </summary>
          private GameObject fuse;
          /// <summary>
          /// 把手
          /// </summary>
          private GameObject handler;

          private Transform jointpos;

          /// <summary>
          /// 握住物体的手柄
          /// </summary>
          private Transform holdhand;

          /// <summary>
          /// 定位点
          /// </summary>
          public Fusestate fuse_pos;


          private void Start()
          {
               fuse = TransformHelper.FindChild(transform, "Fuse").gameObject;
               handler = TransformHelper.FindChild(transform, "Handler").gameObject;
               jointpos = TransformHelper.FindChild(transform, "Jointpos");

          }

          private void fn_update()
          {
               transform.position = holdhand.position;
               transform.rotation = holdhand.rotation;
               CalculateAngelDistance();
          }
          /// <summary>
          /// 开始拾取
          /// </summary>
          public void StartHold(Transform hand)
          {
               if (holding)
                    EndHold();
               else
               {
                    holding = true;

                    S_update.Instance.M_update = fn_update;
                    holdhand = hand;
                    transform.GetComponent<Rigidbody>().useGravity = false;
               }
          }
          /// <summary>
          /// 结束拾取
          /// </summary>
          public void EndHold()
          {
               holding = false;
               S_update.Instance.fn_remove(fn_update);
               transform.GetComponent<Rigidbody>().useGravity = true;
          }
          /// <summary>
          /// 设置把手和断路器状态
          /// </summary>
          /// <param name="state"></param>
          public void SetState(handfusestate state)
          {
               switch (state)
               {
                    case handfusestate.disconnect:
                         fuse.SetActive(true);
                         h_f_state = handfusestate.connect;
                         break;
                    case handfusestate.connect:
                         fuse.SetActive(false);
                         h_f_state = handfusestate.disconnect;
                         break;
                    default:
                         break;
               }
          }

          private bool link;
          private void CalculateAngelDistance()
          {
               //确定熔断器和其位置的距离
               float distance = Vector3.Distance(jointpos.position, fuse_pos.transform.position);

               //确定熔断器和其位置的夹角
               float angle = Mathf.Acos(Vector3.Dot(jointpos.forward.normalized, fuse_pos.transform.forward.normalized)) * Mathf.Rad2Deg;
               //print((distance <= judgedistance) + "#########" + (angle <= judgeangle) + "#####" + (link == false));

               if (distance <= judgedistance && angle <= judgeangle && link == false)
               {
                    LockToPos();
                    link = true;
               }
               else if (distance > judgedistance + 0.02f)
               {
                    link = false;
               }

          }
          /// <summary>
          /// 链接位置
          /// </summary>
          /// <param name="state"></param>
          public void LockToPos()
          {

               if (h_f_state == handfusestate.connect)
               {
                    print("link");
                    fuseposchange(true);
                    h_f_state = handfusestate.disconnect;
                    fuse.SetActive(false);
               }
               else if (h_f_state == handfusestate.disconnect)
               {
                    print("linkoff");
                    fuseposchange(false);
                    h_f_state = handfusestate.connect;
                    fuse.SetActive(true);
               }


          }

          /// <summary>
          /// 确定链接发送消息
          /// </summary>
          /// <param name="state"></param>
          public void fuseposchange(bool state)
          {
               if (state)
               {
                    GetComponent<I_Control>().fni_on();
                    fuse_pos.Link();
               }
               else
               {
                    GetComponent<I_Control>().fni_off();
                    fuse_pos.LinkOff();
               }
          }



     }

}