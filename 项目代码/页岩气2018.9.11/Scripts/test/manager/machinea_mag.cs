using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class machinea_mag : AB_manager
     {
          protected override void Start()
          {
               base.Start();
          }

          protected Dictionary<string, GameObject> m_allBtn =
               new Dictionary<string, GameObject>();
          public override void fn_init()
          {
               btn_name[] t_allbtn = GetComponentsInChildren<btn_name>();
               for (int i = 0; i < t_allbtn.Length; i++)
               {
                    m_allBtn.Add(t_allbtn[i].m_name, t_allbtn[i].gameObject);
                    btn_state t_st = t_allbtn[i].gameObject.GetComponent<btn_state>();
                    t_st.m_state = "off";
               }
          }
     }

}