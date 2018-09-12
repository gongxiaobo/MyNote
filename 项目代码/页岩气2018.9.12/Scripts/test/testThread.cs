using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class testThread : MonoBehaviour {

	// Use this for initialization
	void Start () {
          //Thread t_thread = new Thread(() => { fnp_out(); });
          //t_thread.Start();
          //t_thread.Join();
          ////fnp_out();
          //fnp_out2();
          Debug.Log("<color=blue>blue1:</color>" + m_dox.m_id);
          Thread t_threadInput = new Thread(() => { fnp_changeThread(); });
          t_threadInput.Start();
         
		
	}
     protected void fnp_out()
     {
          for (int i = 0; i < 10; i++)
          {
               
               Debug.Log("<color=blue>blue:</color>"+i.ToString());
     
          }
     }
     protected void fnp_out2()
     {
          for (int i = 0; i < 10; i++)
          {

               Debug.Log("<color=red>red:</color>"+i.ToString());

          }
     }
     N_dox m_dox = new N_dox();
     protected void fnp_change(N_dox _dox)
     {
          _dox.m_id = 10;

          Debug.Log("<color=blue>blue:</color>" + m_dox.m_id);
     
     }
     protected void fnp_changeThread()
     {
          fnp_change(m_dox);
     }
	// Update is called once per frame
	void Update () {
		
	}
     public class N_dox
     {
          public int m_id;
     }
}
