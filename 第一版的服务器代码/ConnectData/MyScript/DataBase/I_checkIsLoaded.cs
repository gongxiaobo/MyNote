using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 记录账号已经登陆
/// 检查是否一个账号多次登陆
/// </summary>
interface I_checkIsLoaded
{
    /// <summary>
    /// 把登陆的学员加入到集合中
    /// true: 加入成功
    /// </summary>
    /// <param name="_studentID">学号</param>
    bool fni_addIn(string _macID, string _studentID);
    /// <summary>
    /// 检查是否该学号已经登陆
    /// true :已经登陆，或者传入学号有误
    /// </summary>
    /// <param name="_studentID">学号</param>
    /// <returns></returns>
    bool fni_check(string _studentID);
    /// <summary>
    /// 通过机器的编号ID ,清除这个ID 下的登陆学号
    /// </summary>
    /// <param name="_macID"></param>
    void fni_remove(string _macID);
    /// <summary>
    /// 清理所有的登陆信息
    /// </summary>
    void fni_clear();
}

