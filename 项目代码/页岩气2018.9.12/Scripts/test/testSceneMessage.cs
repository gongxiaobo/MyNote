using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     public class testSceneMessage : MonoBehaviour
     {

          // Use this for initialization
          void Start()
          {
               AB_Message t_msg = new N_Message();
               t_msg.fn_init(E_MessageType.e_sceneMsg,
                    new StateValue[3]{
               new StateValueString("sceneType","train"),
               new StateValueString("subject_init","test01_pre"),
               new StateValueString("subject_step","test01_step")},
                    "sceneMsg", 0, 0);
               S_SceneMessage.Instance.fn_addMsg(t_msg);

          }

          // Update is called once per frame
          void Update()
          {

          }
     }

}