using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class Hand_model_change : MonoBehaviour
     {

          private SteamVR_TrackedObject trackObj;
          private SteamVR_TrackedController control;
          private SteamVR_Controller.Device device;

          private MeshRenderer idle_mesh;
          private MeshRenderer hold_mesh;
          private MeshRenderer point_mesh;

          //private Rigidbody rig;
          // Use this for initialization
          void Start()
          {
               trackObj = transform.parent.GetComponent<SteamVR_TrackedObject>();
               control = transform.parent.GetComponent<SteamVR_TrackedController>();
               idle_mesh = transform.GetChild(0).GetComponent<MeshRenderer>();
               hold_mesh = transform.GetChild(1).GetComponent<MeshRenderer>();
               point_mesh = transform.GetChild(2).GetComponent<MeshRenderer>();
               fn_idle();
               //fly_machine.SetActive(false);
               //device = SteamVR_Controller.Input((int)trackObj.index);
          }

          // Update is called once per frame
          void Update()
          {
               if (device == null)
                    device = SteamVR_Controller.Input((int)trackObj.index);
               if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
               {
                    fn_point();
               }
               if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
               {
                    fn_idle();
               }
               if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
               {
                    fn_hold();
               }
               if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
               {
                    fn_idle();
               }
          }

          private void fn_hold()
          {
               hold_mesh.enabled = true;
               idle_mesh.enabled = false;
               point_mesh.enabled = false;
          }
          private void fn_idle()
          {
               hold_mesh.enabled = false;
               idle_mesh.enabled = true;
               point_mesh.enabled = false;
          }
          private void fn_point()
          {
               hold_mesh.enabled = false;
               idle_mesh.enabled = false;
               point_mesh.enabled = true;
          }
     }

}