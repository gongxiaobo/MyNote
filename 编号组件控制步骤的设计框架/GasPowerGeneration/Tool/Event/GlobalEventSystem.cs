using UnityEngine;
//using System.Collections;
using System.Collections.Generic;
using System;

//namespace GCode
//{
	public abstract class GlobalEventSystem
	{
		public abstract void CleamEventSystem();
	}
	//
	public class GlobalEventSystem<T> :GlobalEventSystem
	{
		private static  GlobalEventSystem<T> _eventSystemInstance;
		private static GlobalEventSystem<T> EventSystemInstance
		{
			get { return _eventSystemInstance ?? (_eventSystemInstance =new GlobalEventSystem<T>());}
		}
		//
		private Action<T> _eventBackingDelegate;
		/// <summary>
		/// 外部增加事件
		/// </summary>
		public static event Action<T> eventHappened{
			add {
				if(EventSystemInstance._eventBackingDelegate ==null)
				{
					GlobalEventSystemMaitenance.RegisterNewEventSystem(EventSystemInstance);
				}
				EventSystemInstance._eventBackingDelegate += value;
			}
			remove{EventSystemInstance._eventBackingDelegate -= value;}
		}
		/// <summary>
		/// 触发事件
		/// </summary>
		/// <param name="eventDate">Event date.</param>
		public static void Raise(T eventDate)
		{
			EventSystemInstance.SafeRaise (eventDate);
		}
		private void SafeRaise(T eventDate)
		{
			if (_eventBackingDelegate != null) {
				_eventBackingDelegate (eventDate);
			}
		}
		/// <summary>
		/// 销毁事件
		/// </summary>
		private static void CleanCurrentEventSystem()
		{
			if (_eventSystemInstance != null) {
				_eventSystemInstance.CleanSubscribersList ();
				_eventSystemInstance = null;
			}
		}
		private void CleanSubscribersList()
		{
			_eventBackingDelegate = null;
		}
		public override void CleamEventSystem()
		{
			GlobalEventSystem<T>.CleanCurrentEventSystem ();
		}

	}
	/// <summary>
	/// Global event system maitenance.
	/// 维护和存储世界事件
	/// </summary>
	public static class GlobalEventSystemMaitenance
	{
		private static readonly List<GlobalEventSystem> GlobalEvents = new List<GlobalEventSystem> ();
		public static void RegisterNewEventSystem(GlobalEventSystem eventSystem)
		{
			if (!GlobalEvents.Contains (eventSystem)) {
			
				GlobalEvents.Add (eventSystem);
			}
		}

		public static void CleanUpEventSystem()
		{
			foreach (var globalEvent in GlobalEvents) {
				globalEvent.CleamEventSystem ();
			}
			GlobalEvents.Clear ();
		}
	}
//}

