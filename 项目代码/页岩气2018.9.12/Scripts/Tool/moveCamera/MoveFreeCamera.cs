using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class MoveFreeCamera : AB_moveFreeCamera
     {

          public float m_speed = 1f;
          public Transform m_this = null;
          public Transform m_RotateleftRight;
          public Transform m_RotateupDown;
          protected override void Start()
          {
               base.Start();
               m_this = this.gameObject.transform;
          }
          //protected override void Start()
          //{
          //     base.Start();
          //     m_this = this.gameObject.transform;
          //}
          protected override void Update()
          {
               base.Update();

               if (Input.GetKey(KeyCode.W))
               {
                    fn_forward(m_speed);
               }
               if (Input.GetKey(KeyCode.S))
               {
                    fn_back(m_speed);
               }
               if (Input.GetKey(KeyCode.A))
               {
                    fn_left(m_speed);
               }
               if (Input.GetKey(KeyCode.D))
               {
                    fn_right(m_speed);
               }


               if (Input.GetKey(KeyCode.Q))
               {
                    fn_up(m_speed);
               }
               if (Input.GetKey(KeyCode.E))
               {
                    fn_down(m_speed);
               }
               if (Input.GetKey(KeyCode.UpArrow))
               {
                    fn_rotateUp(m_speed);
               }
               if (Input.GetKey(KeyCode.DownArrow))
               {
                    fn_rotateDown(m_speed);
               }
               if (Input.GetKey(KeyCode.LeftArrow))
               {
                    fn_rotateLeft(m_speed);
               }
               if (Input.GetKey(KeyCode.RightArrow))
               {
                    fn_rotateRight(m_speed);
               }

          }
          public override void fn_forward(float _speed)
          {
               m_this.Translate(Vector3.forward * _speed * Time.deltaTime);
          }
          public override void fn_back(float _speed)
          {
               m_this.Translate(Vector3.back * _speed * Time.deltaTime);
          }
          public override void fn_up(float _speed)
          {
               m_this.Translate(Vector3.up * _speed * Time.deltaTime);
          }
          public override void fn_down(float _speed)
          {
               m_this.Translate(Vector3.down * _speed * Time.deltaTime);
          }
          public override void fn_left(float _speed)
          {
               m_this.Translate(Vector3.left * _speed * Time.deltaTime);
          }
          public override void fn_right(float _speed)
          {
               m_this.Translate(Vector3.right * _speed * Time.deltaTime);
          }



          //float m_yrotate = 0f;
          public override void fn_rotateLeft(float _rSpeed)
          {
               //m_this.rotation = Quaternion.AngleAxis(m_yrotate++, new Vector3(0f, 1f, 0f));
               Vector3 t_rotate = m_RotateleftRight.rotation.eulerAngles;
               Vector3 t_rotateNow = new Vector3(0f, t_rotate.y += 1, 0f);
               m_RotateleftRight.rotation = Quaternion.Euler(t_rotateNow);
          }
          public override void fn_rotateRight(float _rSpeed)
          {
               //m_this.rotation = Quaternion.AngleAxis(m_yrotate--, new Vector3(0f, 1f, 0f));
               Vector3 t_rotate = m_RotateleftRight.rotation.eulerAngles;
               Vector3 t_rotateNow = new Vector3(0f, t_rotate.y -= 1, 0f);
               m_RotateleftRight.rotation = Quaternion.Euler(t_rotateNow);
          }
          //float m_xroate = 0f;
          public override void fn_rotateDown(float _rSpeed)
          {
               //m_this.rotation = m_this.rotation+ Quaternion.AngleAxis(1f , new Vector3(1f, 0f, 0f));
               //m_this.rotation = Quaternion.AngleAxis(m_xroate++, new Vector3(1f, 0f, 0f));
               Vector3 t_rotate = m_RotateupDown.rotation.eulerAngles;
               float t_upAngel = fnp_limitValue(t_rotate.x + 1);

               //Debug.Log("<color=blue>blue:</color>" + t_upAngel);

               Vector3 t_rotateNow = new Vector3(t_upAngel, t_rotate.y, t_rotate.z);
               m_RotateupDown.rotation = Quaternion.Euler(t_rotateNow);

          }
          public override void fn_rotateUp(float _rSpeed)
          {
               //m_this.rotation = Quaternion.AngleAxis(m_xroate--, new Vector3(1f, 0f, 0f));
               Vector3 t_rotate = m_RotateupDown.rotation.eulerAngles;

               float t_upAngel = fnp_limitValue(t_rotate.x - 1);
               //Debug.Log("<color=red>red:</color>" + t_upAngel);
               Vector3 t_rotateNow = new Vector3(t_upAngel, t_rotate.y, t_rotate.z);
               m_RotateupDown.rotation = Quaternion.Euler(t_rotateNow);
          }
          protected float fnp_limitValue(float _input)
          {
               if (_input > 270f && _input <= 280f)
               {
                    return 280f;
               }
               else if (_input < 90f && _input >= 80f)
               {
                    return 80f;
               }
               else
               {
                    return _input;
               }

          }

     }

}