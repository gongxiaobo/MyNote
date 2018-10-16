using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDGeek
{
     public class Task_my : Task
     {
          public Task_my() {
               this.init = fn_init;
               this.update = fn_update;
               this.isOver = fn_isOver;
          
          }
          protected FSM m_fsm = null;
          protected float m_countTime=0f;
          public void fn_set(FSM _fsm, float _countTime)
          {
               m_fsm = _fsm;
               m_countTime = _countTime;
          }
          public void fn_set(FSM _fsm)
          {
               m_fsm = _fsm;
               //m_countTime = _countTime;
          }
          protected bool m_over = false;
          protected virtual void fn_init()
          {
               m_over = false;
          }
          protected virtual void fn_update(float _deltTime)
          {
               return;
          }
          protected virtual bool fn_isOver()
          {
               return m_over;
          }
          
         
     } 
}
