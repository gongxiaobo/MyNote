using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GasPowerGeneration;
public class PoolManager:  GenericSingletonClass<PoolManager>{
//	private const int listname = 1;
//	// Use this for initialization
//	void Start () {
//	
//	}
	
//	// Update is called once per frame
//	void Update () {
//	
//	}
	/// <summary>
	/// 所有加入对象池的对象名字
	/// 对象为GameObject
	/// </summary>
	Dictionary<string,List<GameObject>>  allGameObjectName=
          new Dictionary<string, List<GameObject>>();
	private List<GameObject> parents = new List<GameObject> ();
	/// <summary>
	/// 加入对象池的对象
	/// </summary>
	/// <param name="go">Go.</param>
	public void fnAddGameObjectPool(GameObject go,int limit){

		if (limit <= 0f)
			return;
		if (go == null)
			return;
		
		if (!allGameObjectName.ContainsKey (go.name)) {
			//


			//
			List<GameObject> namegroup = new List<GameObject> ();
			namegroup.Add (go);
			allGameObjectName.Add (go.name, namegroup);


				GameObject emptygameobje = new GameObject ();
				emptygameobje.transform.position = Vector3.zero;
				emptygameobje.name = (go.name + "s");
				go.transform.parent = emptygameobje.transform;
				parents.Add (emptygameobje);


			go.SetActive (false);

			Debug.Log (go.name+"加入对象池成功");
			return;
		} else {
			if (allGameObjectName [go.name].Count <= limit) {
//				GameObject parentobje = GameObject.Find ((go.name + "s"));
				GameObject temp = Instantiate (go);
				temp.name = go.name;
				foreach (GameObject parentsGO in parents) {
					if(parentsGO.name==(go.name + "s")){
						temp.transform.parent = parentsGO.transform;
//						temp.SetActive (false);
						break;
					}

				}
				allGameObjectName [go.name].Add (temp);
				temp.SetActive (false);

				Debug.Log (go.name+"加入对象池成功");

			} else {
				Debug.Log ("对象数量已经达到上线----" + limit);
			}

		}

	}
	/// <summary>
	/// 更加名字获取对象
	/// 当物体位置小于（-1000f）就认为为可用对象
	/// </summary>
	/// <returns>The get game object pool.</returns>
	/// <param name="_name">Name.</param>
	public GameObject fnGetGameObjectPool(string _name){
		if (allGameObjectName.ContainsKey (_name)) {
			for (int i = 0; i < allGameObjectName [_name].Count; i++) {
				if (allGameObjectName [_name] [i].activeSelf==false) {
					allGameObjectName [_name] [i].SetActive(true);
//					Debug.Log ("找到可用的");
					return allGameObjectName [_name] [i];
				}
			}
//			Debug.Log ("没有找到可用的");
			for (int i = 0; i < allGameObjectName [_name].Count; i++) {
				if (allGameObjectName [_name] [i]!=null) {
					fnAddGameObjectPool (allGameObjectName [_name] [i], 
                              allGameObjectName [_name].Count + 1);
					break;
				}
			}


			return fnGetGameObjectPool( _name);

		} else {
			
			return null;
		}
	
	}
	/// <summary>
	/// 返回类对象的集合
	/// </summary>
	/// <returns>The get object list.</returns>
	/// <param name="_name">Name.</param>
	public List<GameObject> fnGetObjList(string _name){
		if (allGameObjectName.ContainsKey (_name)) {
			return allGameObjectName [_name];
		}
		return null;
	}
	/// <summary>
	/// 销毁所有
	/// </summary>
	public void ClearAll(){
		foreach (List<GameObject> lt in allGameObjectName.Values) {
			foreach (GameObject go in lt) {
				Destroy (go);
			}
			lt.Clear ();
		}
		allGameObjectName.Clear ();
		parents.Clear ();
	}
	/// <summary>
	/// 销毁当前没有用的对象
	/// </summary>
	public void ClearDisable(){
		foreach (List<GameObject> lt in allGameObjectName.Values) {
			foreach (GameObject go in lt) {
				if (false == go.activeSelf) {
					lt.Remove (go);
					Destroy (go);
				}


			}
		}
	}


}
