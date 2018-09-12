using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class N_startFade : MonoBehaviour
     {
          //SteamVR_Fade m_fade = null;
          // Use this for initialization
          void Start()
          {
               //SteamVR_Fade.Start(new Color(0f, 0f, 0f, 1f), 2f);
               //SteamVR_Fade.Start(Color.black, 3);
               //SteamVR_Fade.Start(Color.clear, 3);
               Debug.Log("<color=blue>开始黑屏</color>");
               SteamVR_Fade.View(Color.black, 0);
               Invoke("fnp_fade", 4f);
               //SteamVR_Overlay.instance.UpdateOverlay();
               //SteamVR_Fade.Start(new Color(1f, 1f, 1f), 3f);
          }
          void fnp_fade()
          {
               //SteamVR_Fade.Start(new Color(1f, 1f, 1f, 1f), 3f);
               //SteamVR_Fade.Start(Color.clear, 1);
               Debug.Log("<color=blue>开始显示</color>");
               SteamVR_Fade.View(Color.clear, 1);
          }
          IEnumerator fade(Vector3 _pos)
          {
               //		Debug.Log ("屏幕暗");
               SteamVR_Fade.Start(new Color(0f, 0f, 0f, 1f), 0.24f);
               yield return new WaitForSeconds(0.25f);

               SteamVR_Fade.Start(new Color(0f, 0f, 0f, 0f), 0.2f);
               //		yield return new WaitForSeconds (0.25f);

          }
          // Update is called once per frame
          //void Update () {

          //}
     }

}