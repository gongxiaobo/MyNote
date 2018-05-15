using UnityEngine;
using System.Collections;
//using UnityEngine.Networking;
namespace GasPowerGeneration
{

     public class HandMenu : MonoBehaviour
     {

          public Transform head;
          private GameObject cameraRig;
          private GameObject handMenu;
          private SteamVR_TrackedObject trackObj;
          SteamVR_Controller.Device device;
          void Start()
          {
               //cameraRig = GameObject.Find("[CameraRig]_normal");
               cameraRig = GameObject.FindObjectOfType(typeof(SteamVR_ControllerManager)) as GameObject;
               trackObj = GetComponent<SteamVR_TrackedObject>();
               handMenu = GameObject.Find("HandUI");
               Invoke("fn_hide_hand_ui", 2f);
          }
          void fn_hide_hand_ui()
          {
               if (handMenu != null)
                    handMenu.gameObject.SetActive(false);
          }
          // Update is called once per frame
          void Update()
          {

               if (trackObj != null)
               {
                    var device = SteamVR_Controller.Input((int)trackObj.index);
                    if (device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
                    {

                         if (!handMenu.activeSelf)
                         {
                              Reset_ui_pos();
                         }
                         else
                         {
                              handMenu.SetActive(false);
                         }
                    }
               }
          }
          private void Reset_ui_pos()
          {
               handMenu.SetActive(true);
               handMenu.transform.position = TransformHelper.FindChild(transform, "UIPos").transform.position;
               handMenu.transform.LookAt(head);
               Vector3 temp = handMenu.transform.localEulerAngles;
               temp.z = 0;
               handMenu.transform.localEulerAngles = temp;
          }

     }


}