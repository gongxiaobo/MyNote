using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitJson;
/// <summary>
/// 根据需求去查询数据库，反馈结果给客服端
/// 使用这里边的方法都是新创建的线程，所有，不需要给方法加锁
/// </summary>
static class S_useMysql
{
    /// <summary>
    /// 创建数据库连接
    /// </summary>
    //private static A_connectTodata m_dataBase = new N_connectTodata();
    //private static readonly object m_locker01 = new object();
    /// <summary>
    /// 查询表，用户名，和密码，返回登陆是否成功
    /// </summary>
    /// <param name="_sendback"></param>
    public static void fns_canLoad(string _name,string _pass,string _macID, I_sendBackClient _sendback)
    {
        //lock (m_locker01)
        //{
            string t_name = _name;
            string t_pass = _pass;
            I_sendBackClient t_send = _sendback;
            //查询数据库
            string t_cmd ;
            Task<string> t_getCmd = new Task<string>(() => {
                return S_makeCmd.fns_readCmd2("xian_user_1", "studentID", t_name, "password", _pass);
            });
            t_getCmd.Start();
            t_cmd = t_getCmd.Result;
            //Console.WriteLine("cmd:" + t_cmd);
            //反馈结果
            N_msg_canLoad t_canload=null;
        //检查数据库中有没有账号信息
            if (S_sql.M_instance.fn_read(t_cmd))
            {//这里还差限制一个账号只能登陆一次
                I_checkIsLoaded t_checkIsLoaded = S_sql.M_instance;
                if (!t_checkIsLoaded.fni_check(t_name))
                {//没有发现登陆信息
                    if (t_checkIsLoaded.fni_addIn(_macID, t_name))
                    {//加入登陆队列成功
                        t_canload = new N_msg_canLoad(true);
                    }
                    else {
                        t_canload = new N_msg_canLoad(false);
                    }

                }
                else {//登陆失败 
                    t_canload = new N_msg_canLoad(false);
                }
                //t_canload = new N_msg_canLoad(true);
            }
            else {
                t_canload = new N_msg_canLoad(false);
            }

            if (t_canload!=null)
            {
                if (t_send != null)
                    t_send.fn_sendback(JsonMapper.ToJson(t_canload)); 
            }
            
           
        //}

    }


    /// <summary>
    /// 插入数据 : 在数据库中，指定的表中插入数据，
    ///反馈 自增id : 反馈插入后的自增id
    /// </summary>
    /// <param name="_msgCmd">操作语句</param>
    /// <param name="_tableName">要插入数据的表名</param>
    /// <param name="_sendback">反馈接口</param>
    public static void fns_insertMsg(string _msgCmd,string _tableName,I_sendBackClient _sendback) {
        if (_sendback==null)
        {
            return; 
        }
        new Task(() => {
            string t_cmd = _msgCmd;
            string t_tablename = _tableName;
            I_sendBackClient t_back = _sendback;
            //向表中插入数据
            Task<uint> t_insert = new Task<uint>(() =>
            {
                return S_sql.M_instance.fn_insert(_msgCmd, _tableName);
            });
            t_insert.Start();
            uint t_id = t_insert.Result;
            //组装反馈信息
            N_msg_reordID t_backid = new N_msg_reordID(t_id, _tableName);
            string t_jsondata = JsonMapper.ToJson(t_backid);
            //反馈给客服端
            if (t_back != null)
            {
                t_back.fn_sendback(t_jsondata);
            }
            else {
                Console.WriteLine("有数据丢失");
            }

        }).Start();

    }
    /// <summary>
    /// 插入数，不反馈给客户端
    /// </summary>
    /// <param name="_msgCmd">控制命令</param>
    /// <param name="_tableName">表名</param>
    public static void fns_insertMsgNoBack(string _msgCmd, string _tableName)
    {
        new Task(() =>
        {
            string t_cmd = _msgCmd;
            string t_tablename = _tableName;
            //向表中插入数据
            Task<uint> t_insert = new Task<uint>(() =>
            {
                return S_sql.M_instance.fn_insert(_msgCmd, _tableName);
            });
            t_insert.Start();
            if (t_insert.Result<0)
            {
                Console.WriteLine("记录考试，练习场景，详细步骤数据失败");
            }
        }).Start();


    }


    /// <summary>
    /// 开启任务更新数据
    /// </summary>
    /// <param name="_msgCmd">任务命令</param>
    public static void fns_updateMsg(string _msgCmd) {
        if (_msgCmd!="")
        {
            new Task(() =>
            {
                //Console.WriteLine("-->" + _msgCmd);
                string t_cmd = _msgCmd;
                S_sql.M_instance.fn_update(t_cmd);

            }).Start(); 
        }
    }

}

