using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitJson;
//namespace ConnectData.MyScript
//{
/// <summary>
/// 2017.0323：处理消息
/// </summary>
class N_handleMsg01 : N_handleMsg
{
    public override void fn_parse(string _jsonmsg)
    {
        //base.fn_parse(_jsonmsg);
        if (_jsonmsg == "") { return; }
        A_baseMsg t_basemsg = JsonMapper.ToObject<A_baseMsg>(_jsonmsg);
        if (t_basemsg != null) {
            string t_msgname=t_basemsg.m_msgName;
            string t_jsondata = _jsonmsg;
            switch (t_msgname)
            {
                case "N_msg_userload"://客服端向服务器发送登陆请求
                    new Task(() => {
                        S_server_do.fns_load(t_jsondata, mi_sendBackClient);
                    }).Start();
                       
                    
                    break;
                case "N_msg_userExit"://登陆的客户端告知服务器，退出
                    new Task(() =>
                    {
                        S_server_do.fns_clientExit(t_jsondata, mi_sendBackClient);
                    }).Start();
                   
                    break;
                case "N_msg_studentExit"://登陆的学员退出登录
                    new Task(() =>
                    {
                        S_server_do.fns_studentExit(t_jsondata, mi_sendBackClient);
                    }).Start();

                    break;
                    //-------------------------------------------
                case "N_msg_loadStart"://学员登陆成功后，写入登陆记录
                    new Task(() =>
                    {
                        S_server_do.fns_loadStart(t_jsondata, mi_sendBackClient);
                    }).Start();

                    break;
                case "N_msg_loadEnd"://退出登录时记录退出
                    new Task(() =>
                    {
                        S_server_do.fns_loadEnd(t_jsondata, mi_sendBackClient);
                    }).Start();

                    break;
                    //----------------------------------------------
                    //------------------------------------------------
                case "N_msg_study_start"://学习场景开始记录
                    new Task(() =>
                    {
                        S_server_do.fns_SPT_start(t_jsondata, mi_sendBackClient,"study_load_1");
                    }).Start();

                    break;
                case "N_msg_study_end"://学习场景记录结束请求
                    new Task(() =>
                    {
                        S_server_do.fns_SPT_end(t_jsondata, "study_load_1");
                    }).Start();

                    break;
                    //------------------------------------------------
                case "N_msg_prac_start"://练习场景开始记录
                    new Task(() =>
                    {
                        S_server_do.fns_SPT_start(t_jsondata, mi_sendBackClient, "practise_load_1");
                    }).Start();

                    break;
                case "N_msg_prac_end"://练习场景结束记录
                    new Task(() =>
                    {
                        S_server_do.fns_SPT_end(t_jsondata, "practise_load_1");
                    }).Start();

                    break;
                case "N_msg_prac_step"://练习场景的详细步骤记录
                    new Task(() =>
                    {
                        S_server_do.fns_PT_stepRecord(t_jsondata, "practise_record_1");
                    }).Start();

                    break;
                    //-------------------------------------------------
                case "N_msg_test_start"://考试场景开始记录
                    new Task(() =>
                    {
                        S_server_do.fns_SPT_start(t_jsondata, mi_sendBackClient, "test_load_1");
                    }).Start();

                    break;
                case "N_msg_test_end"://考试场景结束记录
                    new Task(() =>
                    {
                        S_server_do.fns_SPT_end(t_jsondata, "test_load_1");
                    }).Start();

                    break;
                case "N_msg_test_step"://考试场景的详细步骤记录
                    new Task(() =>
                    {
                        S_server_do.fns_PT_stepRecord(t_jsondata, "test_record_1");
                    }).Start();

                    break;
                default:
                    break;
            }
        
        }

    }
}
//}
