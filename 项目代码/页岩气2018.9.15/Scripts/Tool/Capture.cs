﻿using UnityEngine;
using System.Collections;
using System.IO;
/// <summary>
/// 截屏专用
/// 挂载代码到想要截屏的摄像机上，在运行时按下P键就可以保存图片到capture目录下
/// 可以调整图片的宽度，高度，格式
/// 还可以调整截图的快门时间
/// by gong 20170331 V1.0
/// </summary>
public class Capture : MonoBehaviour {
	Rect m_rect=new Rect(0,0,1920,1080);
	public float m_width=1920f;
	public float m_height=1080f;
	public Camera m_camera=null;
	public string m_saveFileName="capture";
	public E_format m_format =  E_format.png;
	string t_path;
	// Use this for initialization
	void Start () {
		
		fnp_init ();
	}
	private bool m_isInit = false;
	//初始化
	protected virtual void fnp_init(){
		if (m_saveFileName=="") {
			m_saveFileName="capture";
		}
		t_path=Application.dataPath;
		if (t_path.EndsWith("Assets")) {
			t_path=t_path.Substring (0, t_path.Length - 6);
		}
		if (!Directory.Exists(t_path+"/"+m_saveFileName)) {
			Directory.CreateDirectory (t_path + "/" + m_saveFileName);
		}
		m_camera=( transform.GetComponent<Camera> ())?? m_camera ;
		if (m_camera==null) {
               m_camera = (transform.GetComponentInChildren<Camera>()) ?? m_camera;
                    //Destroy (this);
		}
          if (m_camera == null)
          {
               //m_camera = (transform.GetComponentInChildren<Camera>()) ?? m_camera;
               Destroy(this);
          }
		if (m_shutterSpeed<0.1f) {
			m_shutterSpeed = 0.2f;
		}
		if (m_shutterSpeed>2f) {
			m_shutterSpeed = 1f;
		}
          //if (m_width<100f||m_width>4096f || m_height<100 |m_height>4096f) {
          //     m_width = 1920f;
          //     m_height = 1080f;
          //}
		m_rect.width = m_width;
		m_rect.height = m_height;
		m_isInit = true;
	}
	//快门时间
	public float m_shutterSpeed=1f;
	float t_countdown=-1f;
	// Update is called once per frame
	void Update () {

		if (t_countdown > 0f) {
			t_countdown -= Time.deltaTime;
			m_canShot = false;
//			Debug.Log ("<color=blue>countdown:</color>"+Time.deltaTime);
		} else if(m_isInit){
			m_canShot = true;
			if (Input.GetKeyDown (KeyCode.P)) {

				fn_shot ();
			}
		}

	
	}

	private bool m_canShot = true;
	/// <summary>
	/// 拍摄
	/// </summary>
	public void fn_shot(){
		if (m_canShot) {
			m_canShot = false;
			t_countdown = m_shutterSpeed;
			if (m_camera != null) {
				fnpp_capture (m_camera, m_rect);

			}
		}
	
	}
	//执行截图
	protected virtual void fnpp_capture(Camera _ca,Rect _rect){
	
		RenderTexture t_rendertexture = new RenderTexture ((int)_rect.width, (int)_rect.height, 1);
		_ca.targetTexture = t_rendertexture;
		_ca.Render ();
		//
		RenderTexture.active=t_rendertexture;
		Texture2D t_screen = new Texture2D ((int)_rect.width, (int)_rect.height, TextureFormat.RGB24, false);
		t_screen.ReadPixels (_rect, 0, 0);
		t_screen.Apply ();
		//
		_ca.targetTexture=null;
		RenderTexture.active = null;
		GameObject.Destroy (t_rendertexture);
		byte[] t_bytes = t_screen.EncodeToPNG ();
		//
		System.DateTime  t_time=new System.DateTime();
		t_time = System.DateTime.Now;

		string t_picName = string.Format ("image{0}{1}{2}{3}{4}{5}{6}",t_time.Month, t_time.Day, t_time.Hour, t_time.Minute, t_time.Second,".",m_format.ToString());
		//
		string t_fileName=t_path+"/"+m_saveFileName+"/"+t_picName;
		System.IO.File.WriteAllBytes (t_fileName, t_bytes);

	
	
	
//		return null;
	}

}
public enum E_format{
	png=1,
	jpg=2,
}