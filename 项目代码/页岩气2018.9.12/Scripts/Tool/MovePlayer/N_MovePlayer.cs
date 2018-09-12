using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 给定一个世界空间位置
     /// 移动
     /// </summary>
     public class N_MovePlayer : AB_MovePlayer
     {

          protected override void Start()
          {
               base.Start();

               fnp_findCameraAndArea();
               S_Player.Instance.m_moveplayer = this;
          }

          private void fnp_findCameraAndArea()
          {
               if (m_vrCamera == null)
               {
                    SteamVR_Camera steamVR_Camera = transform.gameObject.GetComponentInChildren<SteamVR_Camera>();
                    if (steamVR_Camera == null) m_vrCamera = Camera.main.transform;
                    else m_vrCamera = steamVR_Camera.transform;
               }
               if (m_vrCamera == null)
               {
                    Debug.LogError("ArcTeleporter can't find camera!");
                    enabled = false;
                    return;
               }
               if (m_vrPlayArea == null)
               {
                    SteamVR_PlayArea steamVR_PlayArea = transform.gameObject.GetComponent<SteamVR_PlayArea>();
                    if (steamVR_PlayArea == null) m_vrPlayArea = transform.parent;
                    else m_vrPlayArea = steamVR_PlayArea.transform;
               }
               if (m_vrPlayArea == null)
               {
                    Debug.LogError("ArcTeleporter must be a child of the steam vr play area attached to the controller tracked object");
                    enabled = false;
                    return;
               }
          }
          public override void fn_movePlayerToWPos(Vector3 _worldpos)
          {
               if (m_vrCamera != null && m_vrPlayArea != null)
               {
                    Vector3 camSpot = new Vector3(m_vrCamera.position.x, 0, m_vrCamera.position.z);
                    Vector3 roomSpot = new Vector3(m_vrPlayArea.position.x, 0, m_vrPlayArea.position.z);
                    Vector3 offset = roomSpot - camSpot;
                    StartCoroutine(fade(_worldpos + offset));
               }
          }
          IEnumerator fade(Vector3 _pos)
          {

               SteamVR_Fade.Start(new Color(0f, 0f, 0f, 1f), 0.24f);
               yield return new WaitForSeconds(0.25f);
               m_vrPlayArea.position = _pos;
               SteamVR_Fade.Start(new Color(0f, 0f, 0f, 0f), 0.2f);

          }
          //摄像机位置
          private Transform m_vrCamera;
          //玩家区域位置
          private Transform m_vrPlayArea;


     }

}