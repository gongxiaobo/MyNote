using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.test.Optimization;
namespace GasPowerGeneration
{
     /// <summary>
     /// 头显得位置移动
     /// </summary>
     public class N_MoveTo : AB_MoveTo
     {
          private Transform m_vrCamera;
          //玩家位置
          private Transform m_vrPlayArea;
          bool canuse = true;
          void Start()
          {
               S_SceneMagT1.Instance.M_PlayerMove = this;
               //S_OpMesh.Instance.Player = this.gameObject.transform;
          }
          public override void fn_MoveTo(Vector3 _pos)
          {
               fnp_findCamera();
               if (canuse)
               {
                    fn_Teleport(_pos);
               }
               //throw new System.NotImplementedException();
          }
          protected virtual void fnp_findCamera()
          {
               SteamVR_Camera steamVR_Camera = transform.GetComponentInChildren<SteamVR_Camera>();
               if (steamVR_Camera == null) m_vrCamera = Camera.main.transform;
               else m_vrCamera = steamVR_Camera.transform;
               if (m_vrCamera == null)
               {
                    Debug.LogError("ArcTeleporter can't find camera!");
                    canuse = false;
                    return;
               }
               SteamVR_PlayArea steamVR_PlayArea = transform.GetComponent<SteamVR_PlayArea>();
               if (steamVR_PlayArea == null) m_vrPlayArea = transform.parent;
               else m_vrPlayArea = steamVR_PlayArea.transform;
               if (m_vrPlayArea == null)
               {
                    Debug.LogError("ArcTeleporter must be a child of the steam vr play area attached to the controller tracked object");
                    canuse = false;
                    return;
               }
          }
          public virtual void fn_Teleport(Vector3 _worldpos)
          {
               Vector3 camSpot = new Vector3(m_vrCamera.position.x, 0, m_vrCamera.position.z);
               Vector3 roomSpot = new Vector3(m_vrPlayArea.position.x, 0, m_vrPlayArea.position.z);
               Vector3 offset = roomSpot - camSpot;
               m_vrPlayArea.position = _worldpos + offset;
               //m_coroutine = StartCoroutine(fade(_worldpos + offset));
          }

     }

}