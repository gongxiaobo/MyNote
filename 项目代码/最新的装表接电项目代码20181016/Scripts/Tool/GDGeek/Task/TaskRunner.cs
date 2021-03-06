﻿using UnityEngine;
using System.Collections;
namespace GDGeek{
	public class TaskRunner : MonoBehaviour {

		private Filter filter_ = new Filter();
		private ArrayList tasks_ = new ArrayList();

		public static TaskRunner Create(GameObject obj){
			TaskRunner runner = obj.GetComponent<TaskRunner>();
			if(runner == null){
				runner = obj.AddComponent<TaskRunner>();
			}
			return runner;
		}

          public int m_taskCount = 0;
		public void update(float d){
             
			var tasks = new ArrayList();
			
			for(var i=0; i< this.tasks_.Count; ++i){
				Task task = this.tasks_[i] as Task;
				task.update(d);
				if(!task.isOver()){
					tasks.Add(task);
				}else{
					task.shutdown();
				}
			}
			this.tasks_ = tasks;
               if (this.tasks_.Count > 10)
                    Debug.LogWarning("Task work hard,task number=" + this.tasks_.Count);
		}
		/*
		protected virtual void  OnDestroy(){
			try{
				for(int i=0; i< this.tasks_.Count; ++i){
					Task task = this.tasks_[i] as Task;
					task.shutdown();
				}
				tasks_ = new ArrayList();
			}catch(System.Exception e){ 
				Debug.LogWarning(e.Message);			
			}
		}*/
		

		public void addTask(Task task){
			task.init();
			this.tasks_.Add(task);
               m_taskCount = this.tasks_.Count;
               //Debug.LogWarning("task number=" + this.tasks_.Count);
		}
		
		protected virtual void Update() { 
			float d = filter_.interval(Time.deltaTime);
			this.update(d);
		}
	}
}
