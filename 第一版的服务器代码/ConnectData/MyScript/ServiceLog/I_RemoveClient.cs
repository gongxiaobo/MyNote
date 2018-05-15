using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace ConnectData.MyScript
//{
/// <summary>
/// 通过客服端的编号名，删除一个客服端的接口
/// </summary>
interface I_RemoveClient
{
    /// <summary>
    /// 删除一个客服端对象
    /// </summary>
    /// <param name="_clientID"></param>
    void fni_remove(string _clientID);
}
//}
