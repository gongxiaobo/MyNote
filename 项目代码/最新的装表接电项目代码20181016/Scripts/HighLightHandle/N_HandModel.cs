using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class N_HandModel : AB_HandModel
     {
          Dictionary<string, MeshRenderer> m_models = new Dictionary<string, MeshRenderer>();
          protected override void fn_findMesh()
          {
               base.fn_findMesh();
               foreach (var item in GetComponentsInChildren<MeshRenderer>())
               {
                    if (item.name == "ray" || item.name == "tip")
                    {
                         continue;
                    }
                    if (m_default == null)
                    {
                         m_default = item.material;
                    }
                    if (!m_models.ContainsKey(item.gameObject.name))
                    {
                         m_models.Add(item.gameObject.name, item);
                    }
               }
          }
          public override void fn_setDefault()
          {
               CancelInvoke("fnp_light");
               m_lightName = "";
               m_isLight = false;

               fn_findMesh();
               foreach (var item in m_models.Values)
               {
                    item.material = m_default;
               }
          }
          public override void fn_setHighLight(string _btnName)
          {
               fn_findMesh();
               if (m_models.ContainsKey(_btnName))
               {
                    m_lightName = _btnName;
                    //m_models[_btnName].material = m_light;
                    InvokeRepeating("fnp_light", 1f, 0.75f);
               }
               else
               {

                    Debug.Log("<color=red>not contain : </color>" + _btnName);

               }
          }
          bool m_isLight = false;
          string m_lightName = "";
          protected virtual void fnp_light()
          {
               m_isLight = !m_isLight;
               if (m_models.ContainsKey(m_lightName))
               {
                    if (m_isLight)
                    {
                         m_models[m_lightName].material = m_light;
                    }
                    else
                    {
                         m_models[m_lightName].material = m_default;
                    }
               }
          }


     }

}