using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     /// <summary>
     /// 在加载表和声音后，直接生成场景消息，跳转到操作场景，忽略选择场景
     /// </summary>
     public class test_makeSceneMsg : MonoBehaviour
     {
          [SerializeField]
          public sceneMsg m_sceneMsg=new sceneMsg();
          // Use this for initialization
          void Start()
          {

          }
          public void fn_makeSceneMsg()
          {
               //关卡初始化消息
               AB_Message t_msg = new N_Message();
               t_msg.fn_init(E_MessageType.e_sceneMsg,
                    new StateValue[5]{
               new StateValueString("sceneType",m_sceneMsg.m_mode.ToString()),//场景的模式，训练还是考试
               new StateValueString("subject_init",m_sceneMsg.m_initTableName),//初始化表格名称
               new StateValueString("subject_step",m_sceneMsg.m_stepTableName),//训练步骤表格名称
               new StateValueString("lg",m_sceneMsg.m_language.ToString()),//语言的选择
               new StateValueString("item_name","item_names_"+"ce")},//item_name表格类型选择
                    "sceneMsg", 0, 0);
               S_SceneMessage.Instance.fn_addMsg(t_msg);

               S_SceneMessage.Instance.me_thisSceneName = E_sceneName.e_step;
          }

     }
     [Serializable]
     public struct sceneMsg
     {
          public Select_mode m_mode;
          public string m_initTableName;
          public string m_stepTableName;
          public Language m_language;

     }

}
