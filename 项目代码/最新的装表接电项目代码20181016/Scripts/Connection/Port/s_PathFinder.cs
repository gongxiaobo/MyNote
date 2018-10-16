using System.Collections.Generic;
using Assets.Scripts.Connection.PointOnPlane;
namespace Assets.Scripts.Connection.Port
{
     /// <summary>
     /// 对比两点路径，找到是否有可通路径，返回路径序号
     /// </summary>
     public static class s_PathFinder
     {
          /// <summary>
          /// 找到两个接口是否有相交路径，如果有返回路径的编号
          /// </summary>
          /// <param name="_port1"></param>
          /// <param name="_port2"></param>
          /// <param name="_port1ID">接口1的路径编号</param>
          /// <param name="_port2ID">接口2的路径编号</param>
          /// <returns></returns>
          public static bool fns_findPath(AB_PortPath _port1, AB_PortPath _port2, out int _port1ID, out int _port2ID)
          {
               if (_port1.M_PortPath.m_CabinetName!=_port2.M_PortPath.m_CabinetName ||
                    _port1.M_PortPath.m_CabinetName== PointOnPlane.E_CabinetName.e_cabinet0||
                    _port2.M_PortPath.m_CabinetName== PointOnPlane.E_CabinetName.e_cabinet0)
               {//不符合条件
                    _port1ID = -1;
                    _port2ID = -1;
                    return false;
               }
               //只需要判断每条路线最后一个平面是否相交相同
               PortPathData tport1, tport2;
               tport1 = _port1.M_PortPath;
               tport2 = _port2.M_PortPath;
               E_CabinetName tcabinetName = _port1.M_PortPath.m_CabinetName;
               bool t_check = false;
               int t_i = 0, t_j = 0;
               for (int i = 0; i < tport1.m_pathname.Count; i++)
               {
                    E_PlaneName tp1=tport1.m_pathname[i].m_path[tport1.m_pathname[i].m_path.Count - 1];
                    for (int j = 0; j < tport2.m_pathname.Count; j++)
                    {
                         
                         E_PlaneName tp2=tport2.m_pathname[j].m_path[tport2.m_pathname[j].m_path.Count-1];
                         if (tp1 == tp2 || S_PortSettingInfo.Instance.fn_isSamePlane(tcabinetName,tp1, tp2))
                         {//相同的平面，或者相交平面
                              t_i = i;
                              t_j = j;
                              t_check= true;
                              break;
                         }
                        

                    }
                    if (t_check)
                    {
                        break;
                    }
               }
               if (t_check)
               {
                    _port1ID = t_i;
                    _port2ID = t_j;
                    return t_check;
               }

               _port1ID = -1;
               _port2ID = -1;
               return false;
          }
          




     }
}
