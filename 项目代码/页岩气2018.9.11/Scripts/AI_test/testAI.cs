using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace GasPowerGeneration
{
     public class testAI : MonoBehaviour
     {
          protected NavMeshAgent m_agent;
          public Transform m_target;
          public Transform m_target1;
          // Use this for initialization
          void Start()
          {
               m_agent = GetComponent<NavMeshAgent>();
               m_timecall = new TimeCount1();
               m_timecall.SetCallSpace(0.5f, fn_do);
          }
          bool m_dir = false;
          bool m_isMoving = false;
          // Update is called once per frame
          void Update()
          {
               if (Input.GetKeyDown(KeyCode.A))
               {
                    if (m_agent != null)
                    {
                         m_agent.destination = m_dir ? m_target.position : m_target1.position;
                         m_dir = (!m_dir);
                         m_isMoving = true;

                    }
               }
               if (m_agent != null)
               {
                    m_isMoving = m_agent.remainingDistance == 0f ? false : true;
                    //Debug.Log("<color=blue>blue:</color>");
                    if (m_isMoving)
                    {

                         Debug.Log("<color=blue>blue:</color>");

                    }
               }
               m_timecall.CallTime(Time.deltaTime);
               m_nowPos = transform.position;
          }
          public GameObject m_dot;
          List<GameObject> m_gameobject = new List<GameObject>();
          void fn_do()
          {
               if (m_isMoving == false)
               {
                    CancelInvoke("fn_birth");
                    for (int i = 0; i < m_gameobject.Count; i++)
                    {
                         Destroy(m_gameobject[i]);
                    }
                    m_gameobject.Clear();
                    return;
               }
               if (m_dot == null)
               {
                    return;
               }
               //m_dot.transform.LookAt(transform.position);
               m_lastPos = transform.position;

               //GameObject t_dot = Instantiate(m_dot);
               //t_dot.transform.position = transform.position;
               //t_dot.transform.rotation = Quaternion.FromToRotation(
               //     t_dot.transform.forward, transform.position - m_dot.transform.position);

               //m_gameobject.Add(t_dot);
               Invoke("fn_birth", 0.35f);
          }
          Vector3 m_lastPos;
          Vector3 m_nowPos;
          protected void fn_birth()
          {
               GameObject t_dot = Instantiate(m_dot);

               t_dot.transform.position = m_lastPos;
               t_dot.transform.LookAt(m_nowPos);
               //t_dot.transform.rotation = Quaternion.FromToRotation(
               //     t_dot.transform.forward, transform.position - m_dot.transform.position);

               m_gameobject.Add(t_dot);
          }
          TimeCount1 m_timecall = null;
     }

}