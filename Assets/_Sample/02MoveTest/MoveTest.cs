using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    //�ʵ�
    float speed = 5.0f; //�ʼ�

    Vector3 targetPosition = new Vector3(7.0f, 1.5f, 8.0f);

    // Start is called before the first frame update
    void Start()
    {
        //���� �پ��ִ� ������Ʈ�� transform ��ü ����
        //this.transform.position = new Vector3(7.0f, 1.5f, 8.0f);
        //this.transform.position = targetPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //�÷����� ��ġ�� ������ ��� �̵�
        //this.transform.position = this.transform.position + new Vector3(0f, 0f, 1f);
        //this.transform.position += new Vector3(1f, 0f, 0f);
        //this.transform.position += Vector3.left;

        //�� : Vector3(0f, 0f, 1f); Vector3.forward
        //�� : Vector3(0f, 0f, -1f); Vector3.back
        //�� : Vector3(-1f, 0f, 0f); Vector3.left
        //�� : Vector3(1f, 0f, 0f); Vector3.right
        //�� : Vector3(0f, 1f, 0f); Vector3.up
        //�Ʒ� : Vector3(0f, -1f, 0f); Vector3.down

        //�ӵ� - �� �������� 1�ʿ� 1 unit ��ŭ �̵�
        //transform.position += Vector3.forward * Time.deltaTime;
        //�ӵ� - �� �������� 1�ʿ� 5 unit ��ŭ �̵�
        //transform.position += Vector3.forward * Time.deltaTime * speed;

        //Translate : transform �̵� �Լ�
        //direction : �̵��� ����
        //Time.deltaTime �̵��� ������ �ð��� ������ �Ÿ��� �̵��ϰ� ���ش�
        //speed : �ӵ� - 1�ʴ� �̵��ϴ� �Ÿ�
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);

        //�̵� ���� ���ϱ�
        // dir : ��ǥ���� - ��������, ��ǥ��ġ - ������ġ
        Vector3 dir = targetPosition - this.transform.position;
        //dir.normalized : ��������, ���̰� 1�� ����, ����ȯ�� ����
        //dir.magnitude : ����, ũ��
        transform.Translate(dir.normalized * Time.deltaTime * speed, Space.Self);

        //Space.Self , Space.World
        //transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self); //���� �� �������� �̵�
        //transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World); //�۷ι� �� �������� �̵�

    }
}


/*

Time.deltaTime
20������ : 0.05��

������ ���� ��ǻ��
//10������ - deltaTime : 0.1��
transform.position += Vector3(0f, 0f, 1f) * Time.deltaTime;  //0.1
transform.position += Vector3(0f, 0f, 1f) * Time.deltaTime;  //0.1
transform.position += Vector3(0f, 0f, 1f) * Time.deltaTime;  //0.1
transform.position += Vector3(0f, 0f, 1f) * Time.deltaTime;  //0.1
transform.position += Vector3(0f, 0f, 1f) * Time.deltaTime;  //0.1
transform.position += Vector3(0f, 0f, 1f) * Time.deltaTime;  //0.1
transform.position += Vector3(0f, 0f, 1f) * Time.deltaTime;  //0.1
transform.position += Vector3(0f, 0f, 1f) * Time.deltaTime;  //0.1
transform.position += Vector3(0f, 0f, 1f) * Time.deltaTime;  //0.1
transform.position += Vector3(0f, 0f, 1f) * Time.deltaTime;  //0.1


������ ���� ��ǻ��
//2������ - deltaTime : 0.5��
transform.position += Vector3(0f, 0f, 1f) * Time.deltaTime; //0.5
transform.position += Vector3(0f, 0f, 1f) * Time.deltaTime; //0.5 















*/