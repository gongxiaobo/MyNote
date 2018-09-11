using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 摄像机离UI的距离检测
/// 动态调整UI的字体清晰度
/// </summary>
public class DisToCamera : MonoBehaviour {
     public Transform m_cameraRig = null;
     protected Transform m_eye = null;
     public CanvasScaler m_thisCanvas = null;
     public float m_distance = 2f;
     Transform m_this;
	// Use this for initialization
	void Start () {
          m_this = this.gameObject.transform;
          if (m_cameraRig!=null)
          {
               m_eye = m_cameraRig.gameObject.GetComponentInChildren<SteamVR_Camera>().transform;
          }
          m_thisCanvas = GetComponentInChildren<CanvasScaler>();
	}
     //高分辨率
     public float m_high = 3f;
     //低分辨率
     public float m_low = 1f;
	// Update is called once per frame
	void FixedUpdate () {
          if (m_thisCanvas == null || m_eye==null)
          {
               return;
          }
          float t_dis=Vector3.Distance(m_eye.position, m_this.position) ;
          if (m_useLerp==false)
          {
               if (t_dis <= m_distance)
               {//高清显示UI
                    m_thisCanvas.dynamicPixelsPerUnit = m_high;
               }
               else
               {
                    m_thisCanvas.dynamicPixelsPerUnit = m_low;
               }
          }
          else
          {
               m_thisCanvas.dynamicPixelsPerUnit = fnp_changeLerp(t_dis);
          }
	}
     //实时的渐变
     public bool m_useLerp = false;
     /// <summary>
     /// 根据距离渐变
     /// </summary>
     /// <param name="_disNow"></param>
     /// <returns></returns>
     protected float fnp_changeLerp(float _disNow)
     {
          float t_per= _disNow / m_distance;
          t_per =Mathf.Clamp01( t_per);
          float t_lerp = (1f - t_per)*(m_high - m_low);
          return t_lerp;
     }
}
