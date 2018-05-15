using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testheadcontrol : MonoBehaviour {
     public AB_SetAniValue m_setAniValue = null;
     Transform m_this;
     Transform m_parent = null;
	// Use this for initialization
	void Start () {
          //m_setAniValue = GetComponent<AB_SetAniValue>();
          m_this = GetComponent<Transform>();
          m_parent = m_setAniValue.gameObject.transform.parent;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
          //Debug.Log("<color=blue>blue:</color>" + m_this.localRotation.eulerAngles.x);
          float t_lr = m_this.localRotation.eulerAngles.z % 360f;
          float t_ud = m_this.localRotation.eulerAngles.x % 360f;
          float lr = t_lr > 180f ? (t_lr - 360f) : t_lr;
          float ud = t_ud > 180f ? (t_ud - 360f) : t_ud;
          //Debug.Log("<color=blue>blue:</color>" + lr);
          m_setAniValue.fn_set(lr, ud);

          Vector3 t_people = m_parent.rotation.eulerAngles;
          //t_people=



          //m_setAniValue.gameObject.transform.rotation.SetEulerAngles(new Vector3(t_people.x, m_this.rotation.eulerAngles.y, t_people.z));
          m_parent.eulerAngles = new Vector3(t_people.x, m_this.rotation.eulerAngles.y, t_people.z);
          m_parent.localPosition = new Vector3(m_this.localPosition.x, m_this.localPosition.y, m_this.localPosition.z + 0.5f);
	}
}
