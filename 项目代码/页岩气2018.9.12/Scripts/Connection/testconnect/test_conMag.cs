using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class test_conMag : MonoBehaviour
     {

          // Use this for initialization
          void Start()
          {
               m_RopeMag = GetComponentInChildren<test_Ropes>();
          }

          //// Update is called once per frame
          //void Update()
          //{

          //}
          test_Ropes m_RopeMag = null;
          public GameObject m_select1, m_select2;
          public void fn_Select(GameObject _in)
          {
               if (m_select1==null)
               {
                    m_select1 = _in;
               }
               else
               {
                    if (m_select1==_in)
                    {//两次选择同一个物体时
                         m_select1.GetComponent<test_ChangeMat>().fn_back();
                         m_select1 = null;
                         return;
                    }
                    m_select2 = _in;
                    fnp_readyConnect();
               }
          }
          protected void fnp_readyConnect() {
               GameObject t_s1 = m_select1;
               GameObject t_s2 = m_select2;
               m_select1 = null;
               m_select2 = null;
               fnp_connect(t_s1.name, t_s2.name);
               t_s1.GetComponent<test_ChangeMat>().fn_back();
               t_s2.GetComponent<test_ChangeMat>().fn_back();
          
          }
          //List<test_ChangeMat> m_connect = new List<test_ChangeMat>();
          protected void fnp_connect(string _name1, string _name2)
          {
               //for (int i = 0; i < m_connect.Count; i++)
               //{
               //     m_connect[i].fn_back();
               //}
               //m_connect.Clear();

               if (m_RopeMag.fn_showRope(_name1 +"_"+ _name2)==false)
               {
                    if (m_RopeMag.fn_showRope(_name2 + "_" + _name1) == false)
                    {//没有找到对应名称的线路


                    }
               }
          }
     } 
}
