using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class testinitButn : MonoBehaviour
     {

          // Use this for initialization
          void Start()
          {
               AB_State t_state = GetComponent<AB_State>();
               if (t_state != null)
               {
                    //StateValue[] m_state = new StateValue[2];
                    //m_state[0] = new StateValueString("xx","good");
                    //m_state[1] = new StateValueInt("yy",10);
                    StateValue[] m_state = new StateValue[2]{
                    new StateValueString("xx", "good"),
                    new StateValueInt("yy", 10)};

                    t_state.fn_setValue(m_state);
               }
          }

          // Update is called once per frame
          //void Update () {

          //}
     }

}