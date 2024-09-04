using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class RotateTest : MonoBehaviour
    {
        //�ʵ�
        //float x = 0f;

        //ȸ�� �ӵ�
        public float turnSpeed = 5f;

        //Ÿ��
        public Transform target;


        // Start is called before the first frame update
        void Start()
        {
            //y�� ȸ��
            //this.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            //x�� ȸ��
            //this.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            //z�� ȸ��
            //this.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }

        // Update is called once per frame
        void Update()
        {
            //x -= 1;
            //this.transform.rotation = Quaternion.Euler(0f, x, 0f);
            //this.transform.rotation = Quaternion.Euler(x, 0f, 0f);
            //this.transform.rotation = Quaternion.Euler(0, 0f, x);

            //Rotate
            //this.transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed); // 0, turnSpeed, 0
            //this.transform.Rotate(Vector3.right * Time.deltaTime * turnSpeed); // 0, turnSpeed, 0
            //this.transform.Rotate(Vector3.forward * Time.deltaTime * turnSpeed); // 0, turnSpeed, 0

            //RotateAround - ������ ����
            //transform.RotateAround(target.position, Vector3.up, 20 * Time.deltaTime);

            //Ÿ���� �ٶ󺸴� ȸ���� ���ϱ�
            //���ⱸ�ϱ�
            Vector3 dir = target.position - transform.position;
            //���� ���ͷ� ���� ȸ���� ������
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            //transform.rotation = lookRotation; //�ѹ��� �̵�

            //���� : transform.rotation
            //���� : lookRotation
            Quaternion qRotation = Quaternion.Lerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime);
            //qRotation���� Eulerangle �� ������
            Vector3 eRotation = qRotation.eulerAngles;
            //y�� ���� ����
            transform.rotation = Quaternion.Euler(0f, eRotation.y, 0f);

            //transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime);

        }
    }
}


/*
Lerp(a, b, t)
a=0, b=10
c = Lerp(a, b, 0.1) // 1
c = Lerp(a, b, 0.2) // 2
c = Lerp(a, b, 0.3) // 3
....
c = Lerp(a, b, 0.8) // 8
c = Lerp(a, b, 0.9) // 9
c = Lerp(a, b, 1) // 10

//
a=0, b=10
a = Lerp(0, 10, 0.1) // 1
a = Lerp(a=1, 10, 0.1) // 1.9
a = Lerp(a=1.9, 10, 0.1) // 2.71
*/