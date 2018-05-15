using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace GasPowerGeneration
{
     /// <summary>
     /// 程序开始
     /// 加载表
     /// 加载声音
     /// </summary>
     public class LoadTableFisrt : MonoBehaviour
     {

          // Use this for initialization
          void Start()
          {
               S_LoadTable.Instance.fn_loadtable("table_names");
               Invoke("fnp_loadallTable", 0.3f);
               S_SceneMessage.Instance.me_thisSceneName = E_sceneName.e_start;
          }
          protected void fnp_loadallTable()
          {
               foreach (var item in S_LoadTable.Instance.M_alltables.Values)
               {

                    //Debug.Log("<color=blue>blue:</color>" + item.m_names);

                    if (item.m_type == "")
                    {
                         S_LoadTable.Instance.fn_loadtable(item.m_names);
                    }
                    else
                    {
                         S_LoadTable.Instance.fn_loadtable(item.m_names, item.m_type);
                    }
               }
               Invoke("fnp_loadSoundAll", 1.5f);
          }
          protected void fnp_loadSoundAll()
          {
               //List<string> t_name1 = new List<string>();
               //foreach (var item in S_LoadTable.Instance.M_allsounds.Values)
               //{
               //     t_name1.Add(item.m_name);
               //}
               //string[] t_name = t_name1.ToArray();
               //S_SoundCreate.Instance.fn_createSoundCom(t_name);

               S_SoundCreate.Instance.fn_createSoundCom();
               StartCoroutine("fn_checkLoadSound");

          }
          IEnumerator fn_checkLoadSound()
          {
               yield return new WaitForSeconds(1f);
               if (S_FindVoice.Instance.fn_QueueNum() > 0)
               {
                    StartCoroutine("fn_checkLoadSound");
               }
               else
               {
                    //正式加载登陆界面场景
                    SceneManager.LoadScene("Main1");
               }
          }

     }

}