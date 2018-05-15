using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;
/// <summary>
/// 2017.0328 v1: 数据库的实际操作，阻塞访问,
/// 20170329 v2: 更新方法，获取指定值，修改了小bug
/// 20170406 v3: 创建集合，保存学员登陆情况，处理一个账号同时只能登陆一台机器，实现接口：I_checkIsLoaded
/// </summary>
public class S_sql : Singleton<S_sql>,I_checkIsLoaded
{
    //private static S_sql m_instance;
    //private static readonly object m_lock = new object();
    //public static S_sql M_instance {
    //    get {
    //        if (m_instance==null)
    //        {
    //            lock (m_lock)
    //            {
    //                if (m_instance == null)
    //                {
    //                    m_instance = new S_sql();
    //                }
    //            }
    //        }
           
    //        return m_instance;
    //    }
    //}

    string t_connect = "server=localhost;user=root;port=3306;password=7410;database=xian;charset=utf8;";
    //读链接
    MySqlConnection t_connection_read;
    //写链接
    MySqlConnection t_connection_write;
    //读命令
    MySqlCommand t_cmdRead ;
    //写命令
    MySqlCommand t_cmdWrite ;
    #region 记录学员的登陆
    /// <summary>
    /// 已经登陆的学员学号
    /// </summary>
    private Dictionary<string, string> m_loadUser = new Dictionary<string, string>();
    private readonly object m_lockLoadUser = new object();
    /// <summary>
    /// 把登陆的学员加入到集合中
    /// true: 加入成功
    /// </summary>
    /// <param name="_studentID">学号</param>
    public bool fni_addIn(string _macID, string _studentID)
    {
        lock (m_lockLoadUser)
        {
            if (!m_loadUser.ContainsValue(_studentID))
            {
                m_loadUser.Add(_macID, _studentID);
                Console.WriteLine("登陆的机器和学号： macID=" + _macID + "  , studentID=" + _studentID + " ,count=" + m_loadUser.Count);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    /// <summary>
    /// 检查是否该学号已经登陆
    /// true :已经登陆，或者传入学号有误
    /// </summary>
    /// <param name="_studentID">学号</param>
    /// <returns></returns>
    public bool fni_check(string _studentID)
    {
        lock (m_lockLoadUser)
        {
            if (_studentID == "")
            {
                return true;
            }
            if (m_loadUser.ContainsValue(_studentID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
    public void fni_remove(string _macID)
    {
        lock (m_lockLoadUser)
        {
            if (m_loadUser.ContainsKey(_macID))
            {
                Console.WriteLine("退出登陆的机器： macID=" + _macID + "  , studentID=" + m_loadUser[_macID] + " ,count=" + m_loadUser.Count);
                m_loadUser.Remove(_macID);
              
            }
        }
    }
    public void fni_clear()
    {
        lock (m_lockLoadUser)
        {
            m_loadUser.Clear();
        }
    } 
    #endregion
    /// <summary>
    /// 打开数据库连接
    /// </summary>
    public void fn_open_connect()
    {
        if (t_connection_read == null)
        {
            t_connection_read = new MySqlConnection(t_connect);
        }
        if (t_connection_write == null)
        {
            t_connection_write = new MySqlConnection(t_connect);
          
        }
        try
        {

            t_cmdRead = new MySqlCommand("", t_connection_read);
            t_cmdWrite = new MySqlCommand("", t_connection_write);
            t_connection_read.Open();
            t_connection_write.Open();
        }
        catch (Exception ex)
        {

            Console.WriteLine("链接数据库出现问题："+ex.ToString());
            throw;
        }

    }
    /// <summary>
    /// 销毁数据库连接
    /// </summary>
    public void fn_close_connect()
    {
        if (t_cmdRead!=null)
        {
            t_cmdRead.Dispose();
        }
        if (t_cmdWrite != null)
        {
            t_cmdWrite.Dispose();
        }

        if (t_connection_read != null)
        {
            t_connection_read.Close();
            t_connection_read.Close();
        }
        if (t_connection_write != null)
        {
            t_connection_write.Close();
            t_connection_write.Close();
        }
    }
    /// <summary>
    /// 数据库的锁
    /// </summary>
    private readonly object m_lockMysql = new object();
    /// <summary>
    /// 查询是否有想要的字段
    /// 现阶段用于登陆查询
    /// 返回有或没有
    /// </summary>
    /// <param name="_cmd"></param>
    /// <returns></returns>
    public  bool fn_read(string _cmd)
    {

        lock (m_lockMysql)
        {
            string t_cmd = _cmd;
            if (t_cmd == "")
            {
                return false;
            }
            try
            {
                t_cmdRead.CommandText = t_cmd;
                //using (MySqlDataReader t_getID = t_cmdRead.ExecuteReader())
                //{
                //    if (t_getID.Read())
                //    {//查询等到：表中有相应的结果
                //        return true;
                //    }
                //    else
                //    {
                //        return false;
                //    }

                //}
                object t_result = t_cmdRead.ExecuteScalar();
                if (t_result != null)
                {
                    Console.WriteLine("有相同的 " + (uint)t_result);
                    return true;
                }
                else {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("read"+ex.ToString());
                return false;
                //throw;
            }
           
           
        }
        //return false;
    }
    /// <summary>
    /// 插入内容，返回插入这条类容的自增id
    /// </summary>
    /// <param name="_cmd"></param>
    /// <returns>自增 id</returns>
    public  uint fn_insert(string _cmd,string _tableName) {
        if (_cmd == "" || _tableName=="")
        {
            return 0;
        }
        lock (m_lockMysql)
        {
            string t_cmd = _cmd;
            string t_tableName = _tableName;
            try
            {

                //开始写入
                t_cmdWrite.CommandText = t_cmd;
                int t_result = t_cmdWrite.ExecuteNonQuery();
                if (t_result > 0)
                {//插入成功
                    Console.WriteLine("插入成功");
                    string t_lastID = S_makeCmd.fns_lastID(t_tableName);
                    t_cmdRead.CommandText = t_lastID;
                    object t_value = t_cmdRead.ExecuteScalar();
                    if (t_value != null)
                    {
                        return (uint)t_value;
                    }
                    else {
                        return 0;
                    }

                    
                }
                else {
                    return 0;
                }
               


            }
            catch (Exception ex)
            {
                Console.WriteLine("write"+ex.ToString());
                return 0;
                //throw;
            }


        }
        //return 0;
    }



    /// <summary>
    /// 更新操作
    /// </summary>
    public void fn_update(string _cmd) {
        if (_cmd == "" )
        {
            return ;
        }

        lock (m_lockMysql)
        {
            string t_cmd = _cmd;
           
            try
            {
                t_cmdWrite.CommandText = t_cmd;
                int t_result = t_cmdWrite.ExecuteNonQuery();
                if (t_result>0)
                {//更新成功
                    Console.WriteLine(" update ok...");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("更新失败：" + ex.ToString());
                return;
            }
        }
    
    }

    //
    /// <summary>
    /// 查询是否想要查询的值，返回这个值
    /// </summary>
    /// <param name="_cmd"></param>
    /// <returns></returns>
    public object fn_getDate(string _cmd)
    {

        lock (m_lockMysql)
        {
            string t_cmd = _cmd;
            if (_cmd == "")
            {
                return null;
            }
            try
            {
                t_cmdRead.CommandText = t_cmd;
                object t_result = t_cmdRead.ExecuteScalar();
                if (t_result != null)
                {

                    return t_result;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("read" + ex.ToString());
                return null;
                //throw;
            }


        }
        //return false;
    }

}

