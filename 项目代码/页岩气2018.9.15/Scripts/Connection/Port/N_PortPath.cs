//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Connection.PointOnPlane;
namespace Assets.Scripts.Connection.Port
{
     public class N_PortPath : AB_PortPath
     {
          public PortPathData m_thePortPathData;
          protected override void Start()
          {
               base.Start();
               if (m_thePortPathData==null)
               {
                    Object t_date = Resources.Load("ConnectionPortPath/" + this.gameObject.name);
                    if (t_date != null)
                    {
                         m_thePortPathData = t_date as PortPathData;
                    }
                    else
                    {
                         Debug.Log(this.gameObject.name + "<color=red> not find pathdata!</color>");
                    } 
               }
               if (m_portPos==null)
               {
                    m_portPos = transform.Find("port");
               }

          }
          public override PortPathData M_PortPath
          {
               get { return m_thePortPathData; }
          }
          Transform m_portPos = null;
          public override Transform M_PortPos
          {
               get
               {
                    if (m_portPos == null)
                    {
                         m_portPos = transform.Find("port");
                    }
                    if (m_portPos==null)
                    {
                         m_portPos = this.gameObject.transform;
                    }
                    return m_portPos;
               }
          }
     }
}
