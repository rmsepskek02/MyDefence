using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTest : MonoBehaviour
{
    float x = 0;
    float y = 0;
    float z = 0;
    float turnSpeed = 5f;

    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        //y�� ȸ��
        //transform.rotation = Quaternion.Euler(0, 90f, 0);
        //x�� ȸ��
        //transform.rotation = Quaternion.Euler(90f, 0, 0);
        //z�� ȸ��
        //transform.rotation = Quaternion.Euler(0, 0, 90f);
    }

    // Update is called once per frame
    void Update()
    {
        x += 1;
        y += 1;
        z += 1;

        //transform.rotation = Quaternion.Euler(x, y, z);
        //transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
        //transform.Rotate(Vector3.right * turnSpeed * Time.deltaTime);
        //transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);

        //RotateAround - ������ ����
        //transform.RotateAround(target.transform.position, Vector3.up ,20 * Time.deltaTime);
        
        // Ÿ���� �ٶ󺸴� ����
        Vector3 dir = target.transform.position - transform.position;
        // ���⺤�ͷκ��� ȸ���� �޾ƿ���
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        // ���� : transform.rotation
        // ���� : lookRotation
        Quaternion qRotation = Quaternion.Lerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime);
        // qRotation���� Eulerangle �� ��������
        Vector3 tPosition = qRotation.eulerAngles;
        // y�� ���� ����
        transform.rotation = Quaternion.Euler(0f, tPosition.y,0f);
    }
}

/*
Lerp(a,b,t)
a=0,b=0
c = Lerp(a,b,0.1) // 1
c = Lerp(a,b,0.2) // 2
c = Lerp(a,b,0.3) // 3
c = Lerp(a,b,0.4) // 4 
c = Lerp(a,b,0.5) // 5
c = Lerp(a,b,0.6) // 6
c = Lerp(a,b,0.7) // 7
c = Lerp(a,b,0.8) // 8
c = Lerp(a,b,0.9) // 9

a=0, b=0
a = Lerp (a,b, 0.1) // 1
a = Lerp (a=1,b, 0.1) // 1.9
a = Lerp (a=1.9,b, 0.1) // 2.71
 */