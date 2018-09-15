using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using DG.Tweening;

public class MoveCamra : MonoBehaviour
{

     static MoveCamra _instance;

     public static MoveCamra Instance
     {
          get
          {
               return _instance;
          }
     }
     /// <summary>
     /// 移动速度
     /// </summary>
     public float moveSpeed = 3;
     private Ray mouseRay;
     private bool mouseChick = true;
     private float firstTime = 0;
     //private bool isOpenCamMove=false;
     private float rotationSpeed = 5F;
     /// <summary>
     /// 最小高度
     /// </summary>
     private float minY = -1000F;
     /// <summary>
     /// 最大高度
     /// </summary>
     private float maxY = 1000F;
     /// <summary>
     /// 移动跟随物体（初始坐标旋转角度为0的空物体）
     /// </summary>
     public GameObject forwardPoint;
     /// <summary>
     /// 绕着旋转的中心点（初始坐标旋转角度为0）
     /// </summary>
     public GameObject target;
     /// <summary>
     /// 是否开启鼠标旋转
     /// </summary>
     private bool isRotating = false;
     /// <summary>
     /// 相机和目标物体的距离
     /// </summary>
     private Vector3 offsetPosition;

     //是否聚焦在建筑上
     bool focusState = false;
     //聚焦建筑物
     Transform focusObj;

     void Awake()
     {
          _instance = this;
     }

     // Use this for initialization
     void Start()
     {

     }


     // Update is called once per frame
     void Update()
     {
          if (!IsTouchedUI())
          {
               MouseMove();
               KeyMove();
          }

     }
     void LateUpdate()
     {
          if (transform.parent != null)
          {
               transform.parent = null;
               forwardPoint.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
          }
          ///限制移动高度和低度
          transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minY, maxY + 6f), transform.position.z);
     }
     private void KeyMove()
     {
          if (Input.GetKeyDown(KeyCode.Space))
          {
               ///复位到初始位置和角度

          }
          if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
          {
               moveSpeed = 2;
               rotationSpeed = 2F;
          }
          else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
          {
               moveSpeed = 5f;
               rotationSpeed = 5F;
          }
          //判定是否按住了ctrl，如果按住了，则使用最大移动速度，否则使用正常移动速度
          if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
          {
               moveSpeed = 15;
          }
          else if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl))
          {
               moveSpeed = 5;
          }
          if (Input.GetKeyDown(KeyCode.W))
          {
               MoveCmer(Vector3.forward, KeyCode.W);
          }
          else if (Input.GetKeyDown(KeyCode.S))
          {
               MoveCmer(Vector3.back, KeyCode.S);
          }
          if (Input.GetKeyDown(KeyCode.A))
          {
               MoveCmer(Vector3.left, KeyCode.A);
          }
          else if (Input.GetKeyDown(KeyCode.D))
          {
               MoveCmer(Vector3.right, KeyCode.D);
          }
          else if (Input.GetKey(KeyCode.Q))
          {
               RotCamera(5);
          }
          else if (Input.GetKey(KeyCode.E))
          {
               RotCamera(-5);
          }
          else if (Input.GetKeyDown(KeyCode.UpArrow))
          {
               MoveCmer(Vector3.up, KeyCode.UpArrow);
          }
          else if (Input.GetKeyDown(KeyCode.DownArrow))
          {
               MoveCmer(Vector3.down, KeyCode.DownArrow);
          }
          else if (Input.GetKey(KeyCode.LeftArrow))
          {
               CameraRotation(Vector3.down);
          }
          else if (Input.GetKey(KeyCode.RightArrow))
          {
               CameraRotation(Vector3.up);
          }
     }
     /// <summary>
     /// 旋转相机
     /// </summary>
     private void RotateView()
     {
          //鼠标右键按下可以旋转视野
          if (Input.GetMouseButtonDown(1))
          {
               Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
               RaycastHit hit;
               if (Physics.Raycast(ray, out hit) && focusState == false)
               {
                    target.transform.position = hit.point;
               }
               else
               {
                    target.transform.position = focusObj.position;
               }
               isRotating = true;
          }
          if (Input.GetMouseButtonUp(1))
               isRotating = false;

          if (isRotating)
          {
               Vector3 originalPosition = transform.position;
               Quaternion originalRotation = transform.rotation;
               transform.RotateAround(target.transform.position, target.transform.up, rotationSpeed * Input.GetAxis("Mouse X"));
               transform.RotateAround(target.transform.position, transform.right, -rotationSpeed * Input.GetAxis("Mouse Y"));
               float x = transform.eulerAngles.x;
               //旋转的范围为
               if (x > 80 && x < 330)
               {
                    transform.position = originalPosition;
                    transform.rotation = originalRotation;
               }
          }
          offsetPosition = transform.position - target.transform.position;
     }

     public void CameraRotation(Vector3 direction)
     {
          transform.Rotate(direction * rotationSpeed, Space.World);
     }
     /// <summary>
     /// 移动相机开启携程
     /// </summary>
     /// <param name="v"></param>
     /// <param name="key"></param>
     private void MoveCmer(Vector3 v, KeyCode key)
     {
          StartCoroutine(TurnRound(v, key));
     }
     /// <summary>
     /// 移动相机
     /// </summary>
     /// <param name="v">方向</param>
     /// <param name="key">按键</param>
     /// <returns></returns>
     private IEnumerator TurnRound(Vector3 v, KeyCode key)
     {
          bool isPress = true;
          while (isPress && Input.GetKey(key))
          {
               Move(v);
               yield return new WaitForFixedUpdate();
               if (Input.GetKeyUp(key))
               {
                    isPress = false;
               }
          }
     }
     /// <summary>
     /// 移动相机通过子父物体关系移动
     /// </summary>
     /// <param name="direction"></param>
     private void Move(Vector3 direction)
     {
          transform.parent = forwardPoint.transform;
          forwardPoint.transform.Translate(direction * moveSpeed);
     }
     /// <summary>
     /// 限制相机上下旋转角度
     /// </summary>
     /// <param name="speed"></param>
     private void RotCamera(float speed)
     {
          transform.localEulerAngles -= new Vector3(rotationSpeed / speed, 0, 0);
          if (transform.localEulerAngles.x > 85)
               transform.localEulerAngles = new Vector3(85, transform.eulerAngles.y, transform.eulerAngles.z);
          if (transform.localEulerAngles.x < 10)
               transform.localEulerAngles = new Vector3(10, transform.eulerAngles.y, transform.eulerAngles.z);
     }
     /// <summary>
     /// 鼠标控制
     /// </summary>
     void MouseMove()
     {
          if (!Input.GetMouseButtonDown(2))
          {
               if (Input.GetAxis("Mouse ScrollWheel") != 0)
               {
                    transform.Translate(Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * moveSpeed * Ray(transform) * 0.1f);
                    //Debug.Log("速度："+moveSpeed * Ray(transform) * 0.1f);
               }
          }
          if (Input.GetMouseButton(0) && focusState == false)
          {
               transform.parent = forwardPoint.transform;
               forwardPoint.transform.Translate(-Input.GetAxis("Mouse X") * Ray(transform) * 0.02f * moveSpeed, 0, -Input.GetAxis("Mouse Y") * Ray(transform) * 0.02f * moveSpeed);
          }
          if (Input.GetMouseButtonDown(0))//
          {
               mouseRay = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);//从摄像机向鼠标点击的位置发射条射线
               RaycastHit hit;
               //双击左键定位
               if (Physics.Raycast(mouseRay, out hit))//当射线碰撞到对象时
               {
                    if (Time.time - firstTime > 0.3f)
                    {
                         mouseChick = true;
                    }
                    if (mouseChick)
                    {
                         firstTime = Time.time;
                    }
                    else
                    {
                         if (Time.time - firstTime <= 0.3f)
                         {
                              if (Vector3.Distance(transform.position, hit.point) >= 5)
                              {
                                   //双击定位到物体附近
                                   if (hit.collider.tag == "house")
                                   {
                                        StartCoroutine(FrontTowardPoint(hit.collider.transform.parent.parent.parent));
                                   }
                                   else
                                   {
                                        transform.DOMove(GetBetweenPoint(hit.point, transform.position, 40), 1);
                                   }
                              }
                         }
                    }
                    mouseChick = !mouseChick;
               }
          }
          RotateView();
     }
     /// <summary>
     /// 返回两点之间distance距离的点
     /// </summary>
     /// <param name="start">开始的点</param>
     /// <param name="end">终点</param>
     /// <param name="distance">距离</param>
     /// <returns></returns>
     private Vector3 GetBetweenPoint(Vector3 start, Vector3 end, float distance)
     {
          Vector3 normal = (end - start).normalized;
          return normal * distance + start;
     }
     /// <summary>
     /// 朝向建筑的点
     /// </summary>
     /// <returns></returns>
     IEnumerator FrontTowardPoint(Transform TargetPoint)
     {
          focusObj = TargetPoint;
          focusState = true;
          Sequence mySequence = DOTween.Sequence();
          mySequence.Append(transform.DOMove(TargetPoint.position + new Vector3(0, 10, 10), 1f));
          mySequence.Append(transform.DOLookAt(TargetPoint.position, 0.7f));
          yield return new WaitForSeconds(1.7f);
          //开始实例化UI界面
          print("开始实例化UI界面");
     }
     /// <summary>
     /// 判断相机和前方焦点的距离
     /// </summary>
     /// <param name="point"></param>
     /// <returns>返回距离</returns>
     private float Ray(Transform point)
     {
          Vector3 p = Vector3.zero;
          RaycastHit hit;
          if (Physics.Raycast(point.position, point.forward, out hit))
          {
               p = hit.point;
          }
          float dis = Vector3.Distance(point.transform.position, p);
          if (dis >= 300)
               dis = 300;
          if (dis <= 6)
               dis = 6;
          return dis;
     }

     //是否在UI上
     bool IsTouchedUI()
     {
          bool touchedUI = false;
          if (Application.isMobilePlatform)
          {
               if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
               {
                    touchedUI = true;
               }
          }
          else if (EventSystem.current.IsPointerOverGameObject())
          {
               touchedUI = true;
          }
          return touchedUI;
     }
}
