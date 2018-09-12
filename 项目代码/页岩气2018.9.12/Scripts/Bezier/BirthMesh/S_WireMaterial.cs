using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GasPowerGeneration;
/// <summary>
/// 线的材质管理
/// </summary>
public class S_WireMaterial : GenericSingletonClass<S_WireMaterial>
{
     [SerializeField]
     private MaterialObj m_materialObj;

     public MaterialObj MaterialObj
     {
          get { return m_materialObj; }
          //set { m_materialObj = value; }
     }
	// Use this for initialization
	void Start () {
          Object t_date = Resources.Load("Material/" + "mat_data_03" );
          if (t_date != null)
          {
               m_materialObj = (t_date as MaterialObj);
          }
	}
	
	
}
