using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 建议使用多线程访问
/// 用于装载操作mysql的命令类
/// 所有的组合命令的组合在这里完成
/// 2017.0329 V1
/// </summary>
 public static class S_makeCmd
{
     /// <summary>
     /// 检查一张表中两个字段的值是否存在，并返回存在行的id的命令
     /// </summary>
     /// <param name="_tableName">表名</param>
     /// <param name="_checkField1">字段1</param>
     /// <param name="_checkField1Value">字段1的值</param>
     /// <param name="_checkField2">字段2</param>
     /// <param name="_checkField2Value">字段2的值</param>
     /// <returns>cmd</returns>
     public static string fns_readCmd2(string _tableName,string _checkField1,string _checkField1Value,string _checkField2,string _checkField2Value) {
         if (fns_checkCanUse(_tableName, _checkField1, _checkField2) == false)
         {
             return "";
         }
            string t_cmd = "";
            t_cmd = "SELECT id FROM  " + _tableName + 
                "  WHERE  " +
                _checkField1 + "=" + "'" + _checkField1Value + "'" +
                " and " + _checkField2 + "=" + "'" + _checkField2Value + "'";
            return t_cmd;
     }
     /// <summary>
     /// 检查一张表中一个字段的值是否存在，并返回存在行的id的命令
     /// </summary>
     /// <param name="_tableName">表名</param>
     /// <param name="_checkField1">字段1</param>
     /// <param name="_checkField1Value">字段1的值</param>
     /// <returns>cmd</returns>
     public static string fns_readCmd1(string _tableName, string _checkField1, string _checkField1Value)
     {
     
         if (fns_checkCanUse(_tableName, _checkField1) == false)
         {
             return "";
         }
         string t_cmd = "";
         t_cmd = "SELECT id FROM  " + _tableName +
             "  WHERE " +
             _checkField1 + "=" + "'" + _checkField1Value + "'" ;
         return t_cmd;
     }
     /// <summary>
     /// 查找表中最新的自增的 最新的id值
     /// </summary>
     /// <param name="_tableName">表名</param>
     /// <returns>cmd</returns>
     public static string fns_lastID(string _tableName) {
         if (fns_checkCanUse(_tableName) == false)
         {
             return "";
         }
         string t_cmd = "";
         t_cmd = "SELECT MAX(id) FROM " + _tableName ;
         return t_cmd;
     
     }
     /// <summary>
     /// 插入时间
     /// </summary>
     /// <param name="_tableName"></param>
     /// <param name="_checkField1"></param>
     /// <param name="_checkField1Value"></param>
     /// <returns></returns>
     public static string fns_insertTime(string _tableName, string _checkField1, string _checkField1Value)
     {

         if (fns_checkCanUse(_tableName, _checkField1) == false)
         {
             return "";
         }
         string t_cmd = "";
         t_cmd = "INSERT INTO " + _tableName +
             "(" + _checkField1 + ")" +
             "  VALUE "
             + "("  + _checkField1Value  + ")";
         return t_cmd;
     }
     /// <summary>
     /// 写入一个值
     /// </summary>
     public static string fns_insert1(string _tableName, string _checkField1, string _checkField1Value)
     {

         if (fns_checkCanUse(_tableName, _checkField1) == false)
         {
             return "";
         }
         string t_cmd = "";
         t_cmd = "INSERT INTO " + _tableName +
             "(" + _checkField1  + ")" +
             "  VALUE "
             + "(" + "'" + _checkField1Value + "'" + ")";
         return t_cmd;
     }
     /// <summary>
     /// 写入两个个值
     /// 值的类型支持 string,uint16
     /// </summary>
     public static string fns_insert2<T,U>(string _tableName, string _checkField1, T _checkField1Value, string _checkField2, U _checkField2Value)
     {

         if (fns_checkCanUse(_tableName, _checkField1,_checkField2) == false)
         {
             return "";
         }
         string t_cmd = "";
         if (typeof(T)==typeof(string) && typeof(U)==typeof(string))
         {
             t_cmd = "INSERT INTO " + _tableName +
          "(" + _checkField1 + "," + _checkField2 + ")" +
          "  VALUE "
          + "(" + "'"+_checkField1Value +"'"+ "," +"'"+ _checkField2Value+"'" + ")";
         }
         else if (typeof(T) == typeof(UInt16) && typeof(U) == typeof(Byte))
         {
             t_cmd = "INSERT INTO " + _tableName +
              "(" + _checkField1 + "," + _checkField2 + ")" +
              "  VALUE "
              + "(" + _checkField1Value + "," + _checkField2Value + ")";
         }



      
         return t_cmd;
     }
     /// <summary>
     /// 向表中写入3个值
     /// </summary>
     public static string fns_insert3(string _tableName, string _checkField1, string _checkField1Value, 
         string _checkField2, string _checkField2Value,string _checkField3, string _checkField3Value) {
 
         if (fns_checkCanUse(_tableName,_checkField1,_checkField2,_checkField3)==false)
         {
             return "";
         }
         string t_cmd = "";
         t_cmd = "INSERT INTO  " + _tableName + 
             "(" + _checkField1 + "," + _checkField2 + "," + _checkField3 + ")" + 
             "  VALUE  " 
             + "(" + "'"+_checkField1Value +"'"+ "," +"'"+ _checkField2Value +"'"+ "," + "'"+_checkField3Value+"'"+")";
         return t_cmd;
     }
     /// <summary>
     /// 更新表中3个值,一个条件id
     /// 根据指定类型生成命令字符串
     /// 使用 学习，练习，考试记录的更新操作
     /// </summary>
     public static string fns_update3_1<T,U,E,W>(string _tableName, 
         string _checkField1, T _checkField1Value, 
         string _checkField2, U _checkField2Value, 
         string _checkField3, E _checkField3Value, 
         string _conField4, W _conField4Value)
     {

         if (fns_checkCanUse(_tableName, _checkField1, _checkField2, _checkField3, _conField4) == false)
         {
             return "";
         }
         string t_cmd = "";
         if (typeof(T)==typeof(string)&&
             typeof(U)==typeof(string)&&
             typeof(E)==typeof(string) &&
               typeof(W) == typeof(string) 
             )
         {
             t_cmd = "UPDATE  " + _tableName + " SET  " +
            _checkField1 + "=" + "'" + _checkField1Value + "'" + "," +
            _checkField2 + "=" + "'" + _checkField2Value + "'" + "," +
            _checkField3 + "=" + "'" + _checkField3Value + "'" +
            " WHERE  " +
             _conField4 + "=" + "'" + _conField4Value + "'"
            ;
         }
         else if (typeof(T) == typeof(UInt16) &&
            typeof(U) == typeof(Byte) &&
            typeof(E) == typeof(string) &&
              typeof(W) == typeof(uint) 
             ){
              t_cmd = "UPDATE  " + _tableName + " SET " + 
             _checkField1 + "=" + _checkField1Value  + "," +
             _checkField2 + "=" +  _checkField2Value + "," +
             _checkField3 + "=" + _checkField3Value +
             "  WHERE  "+
              _conField4 + "=" +   _conField4Value  
             ;
         
         }
        
         return t_cmd;
     }
     public static string fns_update2_1<T, U, W>(string _tableName,
        string _checkField1, T _checkField1Value,
        string _checkField2, U _checkField2Value,
        string _conField4, W _conField4Value)
     {

         if (fns_checkCanUse(_tableName, _checkField1, _checkField2, _conField4) == false)
         {
             return "";
         }
         string t_cmd = "";
         if (typeof(T) == typeof(string) &&
             typeof(U) == typeof(string) &&
               typeof(W) == typeof(string)
             )
         {
             t_cmd = "UPDATE  " + _tableName + " SET " +
            _checkField1 + "=" + "'" + _checkField1Value + "'" + "," +
            _checkField2 + "=" + "'" + _checkField2Value + "'" + "," +
            " WHERE  " +
             _conField4 + "=" + "'" + _conField4Value + "'"
            ;
         }
         else if (typeof(T) == typeof(UInt16) &&
            typeof(U) == typeof(Byte) &&
              typeof(W) == typeof(uint)
             )
         {
             t_cmd = "UPDATE  " + _tableName + " SET " +
            _checkField1 + "=" + _checkField1Value + "," +
            _checkField2 + "=" + _checkField2Value + "," +
            "  WHERE " +
             _conField4 + "=" + _conField4Value
            ;

         }

         return t_cmd;
     }

     /// <summary>
     /// 达到一个表中的值
     /// </summary>
     /// <param name="_tableName"></param>
     /// <param name="_checkField1"></param>
     /// <param name="_conField1"></param>
     /// <param name="_conField1Value"></param>
     /// <returns></returns>
     public static string fns_select1(string _tableName, string _checkField1, string _conField1, string _conField1Value)
     {
         if (fns_checkCanUse(_tableName, _checkField1, _conField1, _conField1Value) == false)
         {
             return "";
         }
         string t_cmd = "";
         t_cmd = "SELECT  " + _checkField1 + " FROM " + _tableName + " WHERE " + _conField1 + " = " + "'" + _conField1Value + "'";

         ;
         return t_cmd;
     }

     /// <summary>
     /// 判断输入是否为不可用的字段
     /// </summary>
     /// <param name="_para">参数 字符串类型</param>
     /// <returns> false 有不可用字段</returns>
     public static bool fns_checkCanUse(params string[] _para) {
         foreach (var item in _para)
         {
             if (item=="")
             {
                 return false;
             }
         }
         return true;
     }
     public static bool fns_checkCanUse<T >(params T[] _para) where T : class
     {
         foreach (var item in _para)
         {
             if (item == null)
             {
                 return false;
             }
         }
         return true;
     }

     /// <summary>
     /// 学习场景中插入一条新纪录时的命令
     /// 练习场景也可以使用
     /// 考试场景也可以使用
     /// </summary>
     public static string fns_study_insert<T,U,E>(
         string _tableName, 
         string _checkField1, T _checkField1Value,
         string _checkField2, T _checkField2Value, 
         string _checkField3, U _checkField3Value,
         string _checkField4, U _checkField4Value,
         string _checkField5, E _checkField5Value)
     {
         if (fns_checkCanUse(_tableName, _checkField1, _checkField2, _checkField3, _checkField4, _checkField5) == false)
         {
             return "";
         }
         string t_cmd = "";
         if (typeof(T)==typeof(string)&&
             typeof(U)==typeof(string)&&
             typeof(E)==typeof(string)
             )
         {
             t_cmd = "INSERT INTO  " + _tableName +
           "(" + _checkField1 + "," + _checkField2 + "," + _checkField3 + "," + _checkField4 + "," + _checkField5 + "," + " startTime " + "," + " finishTime " + ")" +
           "  VALUE "
           + "(" + "'" + _checkField1Value + "'" + "," 
           + "'" + _checkField2Value + "'" + "," 
           + "'" + _checkField3Value + "'" +","
           + "'" + _checkField4Value + "'" + ","
           +"'" + _checkField5Value +  "'" +","
           + " now() " +","+ 
          " now() "  + ")";
         }
         else if (typeof(T) == typeof(string) &&
            typeof(U) == typeof(UInt16) &&
            typeof(E) == typeof(Byte))
         {
           t_cmd = " INSERT INTO " + _tableName +
             "(" + _checkField1 + "," + _checkField2 + "," + _checkField3 +  "," + _checkField4+"," + _checkField5+","+" startTime "+","+" finishTime "+")" +
             "  VALUE "
             + "(" + "'" + _checkField1Value + "'" + "," 
             + "'" + _checkField2Value + "'" + "," 
             + _checkField3Value + ","
             + _checkField4Value + "," 
             + _checkField5Value +  "," 
             +  " now() " +  ","
             + " now() "+ ")";
         
         }
       
         return t_cmd;
     }
     /// <summary>
     /// 练习，考试场景的具体步骤记录
     /// </summary>
     public static string fns_insert_step(
          string _tableName,
         string _checkField1, uint _checkField1Value,
         string _checkField2, string _checkField2Value,
         string _checkField3, string _checkField3Value,
         string _checkField4, string _checkField4Value,
         string _checkField5, string _checkField5Value,
          string _checkField6, string _checkField6Value, 
         string _checkField7, string _checkField7Value, 
         string _checkField8, string _checkField8Value)
     {
         if (fns_checkCanUse(_tableName, _checkField1, _checkField2, _checkField3,
             _checkField4, _checkField5, _checkField6, _checkField7, _checkField8) == false)
         {
             return "";
         }
         string t_cmd = "";

         t_cmd = "INSERT INTO " + _tableName +
         "(" + _checkField1 + "," + _checkField2 + "," + _checkField3 + "," + _checkField4 + ","
         + _checkField5 + "," + _checkField6 + "," + _checkField7 +","+_checkField8+ ")" +
         "  VALUE "
         + "(" +  _checkField1Value + ","
         + "'" + _checkField2Value + "'" + ","
         + "'" + _checkField3Value + "'" + ","
         + "'" + _checkField4Value + "'" + ","
         + "'" + _checkField5Value + "'" + ","
         + "'" + _checkField6Value + "'" + ","
         +"'" + _checkField7Value + "'" +","
         +"'" + _checkField8Value + "'"+")";

         return t_cmd;
     
     
     
     }
     /// <summary>
     /// 用户登录记录写入数据
     /// 用户登录就开始调用一次
     /// </summary>
     public static string fns_insert_load_record(string _tableName, string _checkField1, string _checkField1Value)
     {

         if (fns_checkCanUse(_tableName, _checkField1) == false)
         {
             return "";
         }
         string t_cmd = "";
         t_cmd = "INSERT INTO " + _tableName +
             "(" + _checkField1 +","+" startTime "+","+" finishTime "+ ")" +
             "  VALUE "
             + "(" + "'" + _checkField1Value + "'" +","+
             " now() " + "," +
              " now() " + ")";
         return t_cmd;
     }
     /// <summary>
     /// 用户登录记录更新数据
     /// 用户登录关闭机器时调用，或者间隔时间调用
     /// </summary>
     public static string fns_update_load_record(string _tableName, string _conField1, uint _conField1Value)
     {

         if (fns_checkCanUse(_tableName, _conField1) == false)
         {
             return "";
         }
         string t_cmd = "";
         t_cmd = " UPDATE  " + _tableName + " SET " +
            " finishTime " + "= "  + " now() "  +
            "  WHERE  " +
             _conField1 + "="  + _conField1Value 
            ;
         return t_cmd;
     }

 
}
