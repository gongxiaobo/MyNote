using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public abstract class AB_moveFreeCamera : MonoBehaviour
     {

          // Use this for initialization
          protected virtual void Start()
          {

          }

          // Update is called once per frame
          protected virtual void Update()
          {

          }
          public abstract void fn_forward(float _speed);
          public abstract void fn_back(float _speed);
          public abstract void fn_up(float _speed);
          public abstract void fn_down(float _speed);
          public abstract void fn_left(float _speed);
          public abstract void fn_right(float _speed);

          public abstract void fn_rotateRight(float _rSpeed);
          public abstract void fn_rotateLeft(float _rSpeed);
          public abstract void fn_rotateUp(float _rSpeed);
          public abstract void fn_rotateDown(float _rSpeed);
     } 
}
