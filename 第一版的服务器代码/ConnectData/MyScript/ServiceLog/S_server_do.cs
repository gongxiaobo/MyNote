using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitJson;
/// <summary>
///服务器处理任务，
///被多线程访问
/// </summary>
static class S_server_do
{
    #region 登陆和退出
    //private static readonly object m_lock01 = new object();
    /// <summary>
    /// 用户登录验证
    /// </summary>
    /// <param name="_obj">json数据</param>
    /// <param name="_sendback"></param>
    public static void fns_load(string _obj, I_sendBackClient _sendback)
    {
        //Console.WriteLine("user loading...");
        //lock (m_lock01)
        //{
        I_sendBackClient t_send = _sendback;
        N_msg_userload t_user = JsonMapper.ToObject<N_msg_userload>(_obj);
        if (t_user == null)
        {
            N_msg_canLoad t_canload = new N_msg_canLoad(false);
            t_send.fn_sendback(JsonMapper.ToJson(t_canload));
        }
        else
        {  //去数据库查找相应的用户名和密码信息
            new Task(() =>
            {
                S_useMysql.fns_canLoad(t_user.m_username, t_user.m_password, t_user.m_machineID, t_send);
            }).Start();
            Console.WriteLine("user id= " + t_user.m_username);

        }

        //}
    }

    //private static readonly object m_lock02 = new object();
    /// <summary>
    /// 用户退出请求
    /// </summary>
    /// <param name="_obj"></param>
    /// <param name="_sendback"></param>
    public static void fns_clientExit(string _obj, I_sendBackClient _sendback)
    {
        //lock (m_lock02)
        //{
        I_sendBackClient t_send = _sendback;
        N_msg_userExit t_userout = JsonMapper.ToObject<N_msg_userExit>(_obj);
        if (t_userout != null)
        {
            new Task(() =>
            {
                //做些退出处理
                I_RemoveClient t_removeClient = S_ClientSocket.M_instance;
                if (t_removeClient != null)
                {
                    t_removeClient.fni_remove(t_userout.m_username);
                    I_checkIsLoaded t_checkIsLoaded = S_sql.M_instance;
                    t_checkIsLoaded.fni_remove(t_userout.m_username);
                }

            }).Start();
        }


        //}
    }
    /// <summary>
    /// 学员退出登录
    /// </summary>
    /// <param name="_obj"></param>
    /// <param name="_sendback"></param>
    public static void fns_studentExit(string _obj, I_sendBackClient _sendback)
    {
        I_sendBackClient t_send = _sendback;
        N_msg_studentExit t_userout = JsonMapper.ToObject<N_msg_studentExit>(_obj);
        if (t_userout != null)
        {
            new Task(() =>
            {
                //做些学员退出处理
                //I_RemoveClient t_removeClient = S_ClientSocket.M_instance;
                //if (t_removeClient != null)
                //{
                //    t_removeClient.fni_remove(t_userout.m_username);
                //    I_checkIsLoaded t_checkIsLoaded = S_sql.M_instance;
                //    t_checkIsLoaded.fni_remove(t_userout.m_username);
                //}
                I_checkIsLoaded t_checkIsLoaded = S_sql.M_instance;
                t_checkIsLoaded.fni_remove(t_userout.m_username);

            }).Start();

        }
    }
    #endregion
    #region 记录登陆信息

    /// <summary>
    /// 学员登陆成功后，写入登陆记录
    /// </summary>
    /// <param name="_obj">收到的json数据</param>
    /// <param name="_sendback">反馈接口</param>
    public static void fns_loadStart(string _obj, I_sendBackClient _sendback)
    {
        //lock (m_lock02)
        //{

        new Task(() =>
        {
            I_sendBackClient t_send = _sendback;
            N_msg_loadStart t_userstart = JsonMapper.ToObject<N_msg_loadStart>(_obj);
            if (t_userstart != null)
            {
                //组装写入信息语句，
                Task<string> t_makeCmd = new Task<string>(() =>
                {
                    return S_makeCmd.fns_insert_load_record("xian_user_load_record_1", "studentID", t_userstart.m_studentID);
                });
                t_makeCmd.Start();
                //写入登陆记录 
                string t_cmd = t_makeCmd.Result;
                new Task(() =>
                {
                    S_useMysql.fns_insertMsg(t_cmd, "xian_user_load_record_1", t_send);
                }).Start();
            }


        }).Start();

    }
    /// <summary>
    /// 学员退出登录,更新学员的登陆记录
    /// </summary>
    /// <param name="_obj">退出</param>
    /// <param name="_sendback"></param>
    public static void fns_loadEnd(string _obj, I_sendBackClient _sendback)
    {
        new Task(() =>
        {
            //I_sendBackClient t_send = _sendback;
            N_msg_loadEnd t_userend = JsonMapper.ToObject<N_msg_loadEnd>(_obj);
            if (t_userend != null)
            {
                //组装写入信息语句，
                Task<string> t_makeCmd = new Task<string>(() =>
                {
                    return S_makeCmd.fns_update_load_record("xian_user_load_record_1", "id", t_userend.m_id);
                });
                t_makeCmd.Start();
                //写入登陆记录 
                string t_cmd = t_makeCmd.Result;
                new Task(() =>
                {
                    S_useMysql.fns_updateMsg(t_cmd);
                }).Start();
            }

        }).Start();


    }

    #endregion
    #region 学习，练习，考试场景记录数据

    /// <summary>
    /// 学习,练习，考试场景开始记录
    /// </summary>
    /// <param name="_obj">json 数据</param>
    /// <param name="_sendback">反馈接口</param>
    /// <param name="_tableName">要写入数据的表名</param>
    public static void fns_SPT_start(string _obj ,  I_sendBackClient _sendback , string _tableName)
    {

        if (_obj == "" || _sendback == null || _tableName=="")
        {
            return;
        }
        new Task(() =>
        {
            string t_jsondata = _obj;
            string t_table = _tableName;
            I_sendBackClient t_send = _sendback;
            N_msg_SPT_start t_userstudy_start = JsonMapper.ToObject<N_msg_SPT_start>(t_jsondata);
            if (t_userstudy_start != null)
            {

                //组装写入信息语句，
                Task<string> t_makeCmd = new Task<string>(() =>
                {
                    if (  _tableName=="study_load_1" || _tableName=="practise_load_1")
                    {
                        return S_makeCmd.fns_study_insert<string, UInt16, Byte>(t_table,
                                      "studentID", t_userstudy_start.m_studentID,
                                      "chapterID", t_userstudy_start.m_chapterID,
                                      "lastStepID", t_userstudy_start.m_lastStepID,
                                      "allStep", t_userstudy_start.m_allStep,
                                      "progress", t_userstudy_start.m_progress
                                      );
                    }
                    else if (_tableName == "test_load_1")
                    {
                        return S_makeCmd.fns_study_insert<string, UInt16, Byte>(t_table,
                                         "studentID", t_userstudy_start.m_studentID,
                                         "chapterID", t_userstudy_start.m_chapterID,
                                         "lastStepID", t_userstudy_start.m_lastStepID,
                                         "allStep", t_userstudy_start.m_allStep,
                                         "score", t_userstudy_start.m_score
                                         );

                    }
                    else {
                        return "";
                    }

                });
                t_makeCmd.Start();
                //写入登陆记录 
                string t_cmd = t_makeCmd.Result;
                new Task(() =>
                {
                    S_useMysql.fns_insertMsg(t_cmd, t_table, t_send);
                }).Start();
            }

        }).Start();
    }
    /// <summary>
    /// 学习场景结束学习
    /// </summary>
    /// <param name="_tableName">要写入数据的表名</param>
    public static void fns_SPT_end(string _obj ,  string _tableName)
    {
        new Task(() =>
        {
            string t_tablename = _tableName;
            //Console.WriteLine("表名=" + t_tablename);
            //I_sendBackClient t_send = _sendback;
            N_msg_SPT_end t_userend = JsonMapper.ToObject<N_msg_SPT_end>(_obj);
            if (t_userend != null)
            {
                //组装写入信息语句，
                Task<string> t_makeCmd = new Task<string>(() =>
                {

                    if (_tableName=="study_load_1" || _tableName=="practise_load_1")
                    {
                        return S_makeCmd.fns_update3_1<UInt16, Byte, string, uint>(_tableName,
                                        " lastStepID", t_userend.m_lastID,
                                        " progress ", t_userend.m_progress,
                                         "finishTime", " now() ",
                                        " id ", t_userend.m_id);
                    }
                    else if (_tableName == "test_load_1")
                    {
                        return S_makeCmd.fns_update3_1<UInt16, Byte, string, uint>(_tableName,
                                           "lastStepID", t_userend.m_lastID,
                                           "score", t_userend.m_score,
                                            "finishTime", " now() ",
                                           "id", t_userend.m_id);
                    }
                    else {
                        return "";
                    }


                });
                t_makeCmd.Start();
                //写入登陆记录 
                string t_cmd = t_makeCmd.Result;
                new Task(() =>
                {
                    if (t_cmd != "")
                    {
                        S_useMysql.fns_updateMsg(t_cmd); 
                    }
                }).Start();
            }

        }).Start();
    } 
    #endregion
    #region 详细步骤的记录

    /// <summary>
    /// 练习，考试详细步骤的记录
    /// </summary>
    /// <param name="_obj">json数据</param>
    /// <param name="_tableName">表名</param>
    public static void fns_PT_stepRecord(string _obj, string _tableName)
    {

        if (_obj == "" || _tableName == "")
        {
            return;
        }
        new Task(() =>
        {
            string t_jsondata = _obj;
            string t_table = _tableName;
            N_msg_PT_step t_step = JsonMapper.ToObject<N_msg_PT_step>(t_jsondata);
            if (t_step != null)
            {

                //组装写入信息语句，
                Task<string> t_makeCmd = new Task<string>(() =>
                {
                    return S_makeCmd.fns_insert_step(t_table,
                        "handleID", t_step.m_handleID,
                        "carName", t_step.m_carName,
                        "carDiscribe", t_step.m_carDiscribe,
                        "macName", t_step.m_macName,
                        "macDiscribe", t_step.m_macDiscribe,
                        "objID", t_step.m_objID,
                        "objDiscribe", t_step.m_objDiscribe,
                        "objState", t_step.m_objState
                        );

                });
                t_makeCmd.Start();
                //写入登陆记录 
                string t_cmd = t_makeCmd.Result;
                new Task(() =>
                {
                    if (t_cmd != "")
                    {
                        S_useMysql.fns_insertMsgNoBack(t_cmd, t_table);
                    }
                }).Start();
            }

        }).Start();

    } 
    #endregion

}
