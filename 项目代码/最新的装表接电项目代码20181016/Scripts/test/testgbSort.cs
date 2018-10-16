using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testgbSort : MonoBehaviour {

	// Use this for initialization
	void Start () {
          //int[] t_array = new int[5] { 5, 11, 4, 6, 8 };
          //MergeSortRecursion(t_array, 0, 4);
          int[] t_array = new int[11] {10,9 , 8,7,6,5,4,3,2,1,0};
          //fnp_debug(t_array);
          //MergeSortRecursion(t_array, 0, t_array.Length - 1);
          MergeSortIteration(t_array, t_array.Length);
          //fnp_debug(t_array);
		
	}
     int debugid = 0;
     private static void fnp_debug(int[] t_array)
     {
          
          Debug.Log("<color=red>red:</color>");
     
          for (int i = 0; i < t_array.Length; i++)
          {

               Debug.Log("<color=blue>blue:</color>" + t_array[i]);

          }
     }
	
	// Update is called once per frame
	void Update () {
		
	}

     void Merge(int[] A, int left, int mid, int right)
     {

          //Debug.Log("<color=blue>Merge left = </color>" + left + ";mid=" + mid + ";right=" + right);
          //return;
          int len = right - left + 1;
          int[] temp = new int[len];       // 辅助空间O(n)
          int index = 0;
          int i = left;                   // 前一数组的起始元素
          int j = mid + 1;                // 后一数组的起始元素
          while (i <= mid && j <= right)
          {//比较前一数组和后一数组的值，知道一组数组被比较完毕
               temp[index++] = A[i] <= A[j] ? A[i++] : A[j++];  // 带等号保证归并排序的稳定性
          }
          while (i <= mid)
          {//判断左边数组是否比较完毕
               temp[index++] = A[i++];
          }
          while (j <= right)
          {//判断右边数组是否比较完毕
               temp[index++] = A[j++];
          }
          for (int k = 0; k < len; k++)
          {
               A[left++] = temp[k];
          }
          //fnp_debug(A);


     }
     void MergeSortRecursion(int[] A, int left, int right)    // 递归实现的归并排序(自顶向下)
     {
         if (left == right)    // 当待排序的序列长度为1时，递归开始回溯，进行merge操作
             return;
         int mid = (left + right) / 2;
         MergeSortRecursion(A, left, mid);
         //Debug.Log("<color=red>left = </color>" + left + ";mid=" + mid + ";right=" + right);
         MergeSortRecursion(A, mid + 1, right);
          
         //Debug.Log("<color=blue>left = </color>"+left+";mid="+mid+";right="+right);

         Merge(A, left, mid, right);
     }
     void MergeSortIteration(int[] A, int len)    // 非递归(迭代)实现的归并排序(自底向上)
     {
         int left, mid, right;// 子数组索引,前一个为A[left...mid]，
          //后一个子数组为A[mid+1...right]
         for (int i = 1; i < len; i *= 2)        // 子数组的大小i初始为1，每轮翻倍
         {
             left = 0;
              
             Debug.Log("<color=blue>blue:</color>"+i);
     
             while (left + i < len)              // 后一个子数组存在(需要归并)
             {
                 mid = left + i - 1;
                 right = mid + i < len ? mid + i : len - 1;// 后一个子数组大小可能不够
                 Merge(A, left, mid, right);
                 Debug.Log("<color=red>left = </color>" + left + ";mid=" + mid + ";right=" + right);
                 left = right + 1;               // 前一个子数组索引向后移动
             }
         }
     }


}
