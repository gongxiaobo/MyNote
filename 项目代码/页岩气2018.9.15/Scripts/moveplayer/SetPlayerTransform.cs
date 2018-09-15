using UnityEngine;
using System.Collections;

namespace GasPowerGeneration
{
     public class SetPlayerTransform : MonoBehaviour
     {

          // Use this for initialization
          void Start()
          {
               S_Player.Instance.m_playerTran = this.gameObject.transform;
               //		Transform t_camerahead = this.gameObject.transform.FindChild ("Camera(eye)");
               //		S_Player.Instance.m_playerhead = t_camerahead;
               Destroy(this);
          }


     } 
}
