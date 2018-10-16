using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace GasPowerGeneration
{
     /// <summary>
     /// 快速启动的方式
     /// </summary>
     public class Panel_login : UIScene
     {


          private UISceneWidget btn_load, inpf_account, inpf_pwd;
          private Text account, pwd;
          protected override void Start()
          {
               base.Start();
               btn_load = GetWidget("Button_Load");
               inpf_account = GetWidget("InputField_account");
               inpf_pwd = GetWidget("InputField_pwd");
               UISceneWidget.Get(btn_load.gameObject).onClick += btn_load_click;
               UISceneWidget.Get(inpf_account.gameObject).onClick += inpf_account_click;
               UISceneWidget.Get(inpf_pwd.gameObject).onClick += inpf_pwd_click;
               account = inpf_account.transform.Find("Text").GetComponent<Text>();
               pwd = inpf_pwd.transform.Find("Text").GetComponent<Text>();



               //测试用脚本
               int test = PlayerPrefs.GetInt("test");
               if (test == 0)
               {
                    //暂时跳过直接至关卡选择界面
                    ChangePanel(UIName.Panel_WorldMenu);
                    return;
               }
               int index = PlayerPrefs.GetInt("index");
               string pro = PlayerPrefs.GetString("project");
               string mode = PlayerPrefs.GetString("mode");
               string t_lg = PlayerPrefs.GetString("language");
               AB_Message t_msg = new N_Message();
               //UIdata.language_type.ToString()
               t_msg.fn_init(E_MessageType.e_sceneMsg,
                    new StateValue[5]{
               new StateValueString("sceneType",mode),
               new StateValueString("subject_init",pro+"_s"+index.ToString()+"_train"),
               new StateValueString("subject_step",pro+"_s"+index.ToString()+"_step_ce"),
               new StateValueString("lg",t_lg),
                new StateValueString("item_name","item_names_ce")},
                    "sceneMsg", 0, 0);
               S_SceneMessage.Instance.fn_addMsg(t_msg);
               S_SceneMessage.Instance.me_thisSceneName = E_sceneName.e_step;

               if (index >= 33&& index<=42)
                    SceneManager.LoadScene("BengCheck");
               else if(index >0 && index <= 32)
                   SceneManager.LoadScene("test_step1");
               else if (index >= 43 && index < 50)
               {
                    SceneManager.LoadScene("Table1");
               }
               else
               {
                    SceneManager.LoadScene("test_step1");
               }



          }

          private void inpf_pwd_click(GameObject go)
          {
               throw new System.NotImplementedException();
          }

          private void inpf_account_click(GameObject go)
          {
               throw new System.NotImplementedException();
          }

          private void btn_load_click(GameObject go)
          {
               if (Account_check(account.text, pwd.text))
                    ChangePanel(UIName.Panel_WorldMenu);
          }

          private bool Account_check(string account, string pwd)
          {
               return true;
          }


     }

}