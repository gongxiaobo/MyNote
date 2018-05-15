using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using GasPowerGeneration;
namespace Assets.Scripts.test.Optimization
{
     [DisallowMultipleComponent]
     public class N_OpMesh : AB_OpMesh
     {
          MeshRenderer m_meshrd = null;
          public string m_theName = "";

          protected override void Start()
          {
               base.Start();
               fnp_log();
          }
          protected override void fnp_log()
          {
               m_meshrd = GetComponent<MeshRenderer>();
               if (m_meshrd==null)
               {//没有meshrender的物体
                    Destroy(this);
                    return;
               }
               if (GetComponent<AB_LightOneObj>() != null)
               {//需要代码控制的高亮物体
                    Destroy(this);
                    return;
               }
               if (GetComponent<AB_HideModel>()!=null)
               {//是需要代码控制的隐藏物体
                    Destroy(this);
                    return;
               }
               S_OpMesh.Instance.fn_login(M_Name, this);
              

          }

          public override string M_Name
          {
               get { return m_theName; }
               set { m_theName = value; }
          }

          public override void fn_hide(bool _hide = true)
          {
#if UNITY_EDITOR
               if (m_meshrd == null)
               {//没有meshrender的物体
                    m_meshrd = GetComponent<MeshRenderer>();

               }
               if (m_meshrd == null)
               {
                    return;
               } 
#endif
               m_meshrd.enabled = _hide;
               m_state = _hide;
          }
          bool m_state=true;
          public override bool fn_hideState()
          {
               return m_state;
          }
     }
}
