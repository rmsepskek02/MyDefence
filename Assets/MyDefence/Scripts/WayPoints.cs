using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyDefence
{
    //Waypoint���� �����ϴ� Ŭ����
    public class WayPoints : MonoBehaviour
    {
        //�ʵ�
        public static Transform[] points;

        private void Awake()
        {
            points = new Transform[this.transform.childCount];
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = this.transform.GetChild(i);
            }
        }

    }
}