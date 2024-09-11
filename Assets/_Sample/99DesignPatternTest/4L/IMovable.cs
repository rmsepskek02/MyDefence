using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public interface IMovable 
    {
        public float MoveSpeed { get; set; }
        public float Acceleration { get; set; }
        public void GoFoward();
        public void GoBack();
        public void TurnLeft();
        public void TurnRight();
    }
}
