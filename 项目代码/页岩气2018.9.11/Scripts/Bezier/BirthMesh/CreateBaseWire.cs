using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GasPowerGeneration;
/// <summary>
/// 为动态生成电线的类做一些准备工作
/// 创建一个电线连接物体，然后在链接时才生成电线
/// </summary>
public class CreateBaseWire : MonoBehaviour {

	// Use this for initialization
	void Start () {
          AB_BirthMesh t_bm = GetComponent<AB_BirthMesh>();
          t_bm.fn_CreatMeshObj();
          if (t_bm.M_MeshObj!=null)
          {
               t_bm.M_MeshObj.AddComponent<N_Wire02>();
          }
          Destroy(this);
	}
	
	
}
