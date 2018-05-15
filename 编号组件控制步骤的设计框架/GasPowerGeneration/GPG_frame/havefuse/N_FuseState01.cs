using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class N_FuseState01 : AB_FuseState
     {
          protected override void Start()
          {
               base.Start();
               //Object t_matrial = Resources.Load("Material/" + m_goodname);
               //m_good = (t_matrial != null) ? Instantiate(t_matrial as Material) : null;
               ////t_matrial = null;
               //Object t_matrialbad = Resources.Load("Material/" + m_badname);
               //m_bad = (t_matrial != null) ? Instantiate(t_matrialbad as Material) : null;
               //t_matrialbad = null;
               m_good = transform.Find("DKF_MCC_C_06").gameObject;
               m_bad = transform.Find("DKF_MCC_C_07").gameObject;
               fnp_changelooks();
               //t_matrial = null;
               //t_matrialbad = null;
          }

          private void fnp_changelooks()
          {
               //MeshRenderer t_r = GetComponent<MeshRenderer>();
               if (m_good != null && m_bad != null)
               {
                    if (m_canUse)
                    {
                         m_good.SetActive(true);
                         m_bad.SetActive(false);
                    }
                    else
                    {
                         m_good.SetActive(false);
                         m_bad.SetActive(true);
                    }
               }
          }
          //public string m_goodname = "fusegood", m_badname = "fusebad";
          //public Material m_good, m_bad;
          GameObject m_good, m_bad;
          /// <summary>
          /// 是否可以使用
          /// </summary>
          public bool m_canUse = true;

          public override bool fn_CanWork()
          {
               return m_canUse;
          }

          public override void fn_setState(bool _canuse)
          {
               m_canUse = _canuse;
               fnp_changelooks();
          }
     }

}