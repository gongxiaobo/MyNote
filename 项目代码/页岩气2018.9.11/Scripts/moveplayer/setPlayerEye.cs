using UnityEngine;
using System.Collections;

namespace GasPowerGeneration
{
     public class setPlayerEye : MonoBehaviour
     {
          public Transform m_eyeFront;
          // Use this for initialization
          void Start()
          {
               S_Player.Instance.m_playerhead = this.gameObject.transform;
               S_Player.Instance.m_playerEye_front = m_eyeFront;
               Destroy(this);
          }

          // Update is called once per frame
          //	void Update () {
          //	
          //	}
     } 
}
