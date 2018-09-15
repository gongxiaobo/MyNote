using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 检查步骤时查找item类型的状态值
     /// </summary>
     public interface I_CheckValue
     {
          /// <summary>
          /// 通过ID获取状态值
          /// </summary>
          /// <param name="_id"></param>
          /// <returns></returns>
          string fni_checkDate(int _id);
          /// <summary>
          /// 根据值的类型来返回值
          /// </summary>
          /// <param name="_id">item id</param>
          /// <param name="_StateValueType">E_StateValueType</param>
          /// <returns>值</returns>
          string fni_checkDate(int _id, E_StateValueType _StateValueType);

     }

     public interface I_CheckStateValue : I_CheckValue
     {
          /// <summary>
          /// 检查一个item的类型，是查看类型，还是交互类型
          /// </summary>
          /// <param name="_id"></param>
          /// <returns></returns>
          E_ItemType fni_checkItemType(int _id);
          /// <summary>
          /// 检查item 的值类型
          /// </summary>
          /// <param name="_id"></param>
          /// <returns></returns>
          E_valueType fni_checkItemValueType(int _id);
     }

}