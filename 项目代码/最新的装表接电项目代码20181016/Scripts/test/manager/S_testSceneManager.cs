using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class S_testSceneManager : GenericSingletonClass<S_testSceneManager>
     {
          Dictionary<string, AB_manager> m_machines = new Dictionary<string, AB_manager>();
          // Use this for initialization
          void Start()
          {
               Invoke("fnp_initAll", 2f);
          }
          protected void fnp_initAll()
          {
               foreach (var item in m_machines.Values)
               {
                    item.fn_init();
               }
          }
          public void fn_putin(AB_manager _mag)
          {
               if (!m_machines.ContainsKey(_mag.m_machineName))
               {
                    m_machines.Add(_mag.m_machineName, _mag);
               }
          }
          // Update is called once per frame
          //void Update () {

          //}
     }

}