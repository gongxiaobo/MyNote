using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class testmovePlayer : MonoBehaviour
     {
          public ArcTeleporter_new m_teleporter = null;
          public Transform m_1, m_2, m_3;
          // Use this for initialization
          void Start()
          {
               Invoke("fnp_to1", 3f);
          }

          //// Update is called once per frame
          //void Update () {

          //}
          void fnp_to1()
          {
               m_teleporter.fn_Teleport(m_1.position);
               Invoke("fnp_to2", 4f);
          }
          void fnp_to2()
          {
               m_teleporter.fn_Teleport(m_2.position);
               Invoke("fnp_to3", 3f);
          }
          void fnp_to3()
          {
               m_teleporter.fn_Teleport(m_3.position);
               Invoke("fnp_to1", 4f);
          }
     }

}