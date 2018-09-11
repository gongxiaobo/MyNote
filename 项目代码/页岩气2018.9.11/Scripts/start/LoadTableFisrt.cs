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
     /// 完成加载所有的声音后，跳转到选择场景
     /// </summary>
     public class LoadTableFisrt : MonoBehaviour
     {
          // Use this for initialization
          void Start()
          {

#if UNITY_EDITOR
               Debug.unityLogger.logEnabled = true;
#else
               Debug.unityLogger.logEnabled = false;
#endif
               //最先加载的第一张表格
               S_LoadTable.Instance.fn_loadtable("table_names");
               //再根据第一张表格来加载其他所有的表格
               Invoke("fnp_loadallTable", 0.3f);
               //设置场景的名称
               S_SceneMessage.Instance.me_thisSceneName = E_sceneName.e_start;
          }
          /// <summary>
          /// 加载table_names中的所有表格
          /// </summary>
          protected void fnp_loadallTable()
          {
               foreach (var item in S_LoadTable.Instance.M_alltables.Values)
               {
                    if (item.m_type == "")
                    {//普通表格加载
                         S_LoadTable.Instance.fn_loadtable(item.m_names);
                    }
                    else
                    {//根据表的类型来加载表格
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
          /// <summary>
          /// 加载完成表格后要跳转的场景
          /// </summary>
          public string m_loadNextScene = "Main1";
          IEnumerator fn_checkLoadSound()
          {
               yield return new WaitForSeconds(1f);
               if (S_FindVoice.Instance.fn_QueueNum() > 0)
               {
                    StartCoroutine("fn_checkLoadSound");
               }
               else
               {
                    fnp_SkipSelect();
                    //正式加载登陆界面场景
                    S_SceneMessage.Instance.me_thisSceneName = E_sceneName.e_select;
                    SceneManager.LoadScene(m_loadNextScene);
               }
          }
          /// <summary>
          /// 是否略过选择场景直接组装场景消息，然后跳转到操作场景
          /// </summary>
          protected void fnp_SkipSelect()
          {
               test_makeSceneMsg t_makeSceneMsg = GetComponent<test_makeSceneMsg>();
               if (t_makeSceneMsg!=null)
               {
                    t_makeSceneMsg.fn_makeSceneMsg();
               }
          }

     }

}