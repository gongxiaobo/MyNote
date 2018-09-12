using UnityEngine;
using System.Collections;
using System;
namespace GasPowerGeneration
{
     ///<summary>
     ///状态值类型
     ///</summary>
     [Serializable]
     public class StateValue
     {


          /// <summary>
          /// string:s
          /// bool:b
          /// float:f
          /// int:i
          /// null:null
          /// other ...
          /// </summary>
          private string m_type;
          /// <summary>
          /// 值类型
          /// </summary>
          public string Type
          {
               get { return m_type; }
               //set { m_type = value; }
          }

          private string m_name;
          /// <summary>
          /// 值的名称
          /// </summary>
          public string Name
          {
               get { return m_name; }
               //set { m_name = value; }
          }

          public StateValue()
          {
          }

          public StateValue(string _type)
          {

               m_type = _type;
          }
          public StateValue(string _name, string _type)
          {
               m_name = _name;
               m_type = _type;
          }


     }
     [Serializable]
     public class StateValueString : StateValue
     {
          [SerializeField]
          public string m_date;
          public StateValueString()
          {
          }

          public StateValueString(string _date)
               : base("s")
          {

               m_date = _date;
          }
          public StateValueString(string _name, string _date)
               : base(_name, "s")
          {

               m_date = _date;
          }
     }
     [Serializable]
     public class StateValueInt : StateValue
     {
          public int m_date;
          public StateValueInt()
          {
          }

          public StateValueInt(int _date)
               : base("i")
          {

               m_date = _date;
          }
          public StateValueInt(string _name, int _date)
               : base(_name, "i")
          {

               m_date = _date;
          }

     }
     [Serializable]
     public class StateValueBool : StateValue
     {
          public bool m_date;
          public StateValueBool()
          {
          }

          public StateValueBool(bool _date)
               : base("b")
          {

               m_date = _date;
          }
          public StateValueBool(string _name, bool _date)
               : base(_name, "b")
          {

               m_date = _date;
          }


     }
     [Serializable]
     public class StateValueFloat : StateValue
     {
          public float m_date;

          public StateValueFloat()
          {
          }

          public StateValueFloat(float _date)
               : base("f")
          {

               m_date = _date;
          }

          public StateValueFloat(string _name, float _date)
               : base(_name, "f")
          {

               m_date = _date;
          }
     } 
}