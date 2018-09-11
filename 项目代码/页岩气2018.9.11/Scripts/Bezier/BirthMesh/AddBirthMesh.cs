using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GasPowerGeneration;
/// <summary>
/// 把动态生成管道模型的类加入到集合中，在集合中通过名称来寻找
/// </summary>
public class AddBirthMesh : MonoBehaviour {

	// Use this for initialization
	void Start () {
          S_BirthMeshs.Instance.fn_add(this.gameObject.name, GetComponent<AB_BirthMesh>());
          Destroy(this);
	}
	
	
}
