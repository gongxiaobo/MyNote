
namespace GasPowerGeneration
{
     /// <summary>
     /// 零件的状态
     /// 位置关系
     /// </summary>
     public enum E_ThePartState 
     {
          /// <summary>
          /// z在机器里
          /// </summary>
          e_inMachine=0,
          /// <summary>
          /// 在手上
          /// </summary>
          e_inHand=1,
          /// <summary>
          /// 在地面
          /// </summary>
          e_onGround=2,
          /// <summary>
          /// 在工具上
          /// </summary>
          e_onTool=3,
          /// <summary>
          /// 在移动的轨迹上
          /// </summary>
          e_onMovingPath=4,
 
     }

}