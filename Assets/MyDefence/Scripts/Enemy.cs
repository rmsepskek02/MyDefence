using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyDefence
{
    //Enemy�� �����ϴ� Ŭ����
    public class Enemy : MonoBehaviour
    {
        //�ʵ�
        #region Variable
        private float speed = 5f;   //�̵� �ӵ�
        private Transform target;   //�̵��� ��ǥ����        

        private int wayPointIndex = 0;  //wayPoints �迭�� �����ϴ� �ε���

        //private bool isPaid = false;
        //public Transform startPoint;
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            //�ʱ�ȭ
            //Debug.Log("Enemy start");
            //isPaid = false;

            //��ġ�� ������������ �ʱ�ȭ
            //transform.position = startPoint.position;

            //ù��° ��ǥ���� ����
            wayPointIndex = 0;
            target = WayPoints.points[wayPointIndex];
        }

        // Update is called once per frame
        void Update()
        {
            /*if (isPaid)
            {
                return;
            }*/

            //�̵� :����(dir), Time.deltatiem, speed
            Vector3 dir = target.position - this.transform.position;
            transform.Translate(dir.normalized * Time.deltaTime * speed);

            //��������
            float distance = Vector3.Distance(transform.position, target.position);
            if(distance < 0.2f)
            {
                SetNextTarget();
            }
        }

        //���� ��ǥ ���� ����
        void SetNextTarget()
        {
            if(wayPointIndex == WayPoints.points.Length - 1)
            {
                //Debug.Log("���� ����");
                //���� ������Ʈ kill
                Destroy(this.gameObject);
                //
                //Debug.Log("����");
                //isPaid = true;

                return;
            }

            wayPointIndex++;
            target = WayPoints.points[wayPointIndex];
        }
    }
}
