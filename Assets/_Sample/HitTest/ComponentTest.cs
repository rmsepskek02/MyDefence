using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class ComponentTest : MonoBehaviour
    {
        //�ʵ�
        public float moveSpeed = 5f;

        //Ÿ��
        public Transform target;            //Target ���ӿ�����Ʈ�� Transform ��ü�� ����
        public GameObject gTarget;          //Target ���ӿ�����Ʈ ��ü�� ����
        public TargetTest cTarget;          //TargetTest�� ���� ����

        // Start is called before the first frame update
        void Start()
        {
            //���� TargetTest ��ü ����
            //TargetTest tTest = new TargetTest();
            //tTest.b = 30;

            //target ���� ������Ʈ�� Ʈ�������� �پ��ִ� TargetTest�� ��ü�� ����
            //TargetTest tTest = target.GetComponent<TargetTest>();
            //tTest.b = 30;   //public�� �ʵ带 ������ ���
            //Debug.Log(tTest.GetA()); //private a�� public�� �޼���� �����ؼ� ���

            //target ���� ������Ʈ�� �پ��ִ� TargetTest�� ��ü�� ����
            //TargetTest gTest = gTarget.GetComponent<TargetTest>();
            //gTest.b = 50;   //public�� �ʵ带 ������ ���
            //Debug.Log(gTest.GetA()); //private a�� public�� �޼���� �����ؼ� ���

            //Target ���� ������Ʈ�� �پ��ִ� TargetTest�� ��ü�� ���� ����
            cTarget.b = 70;
            Debug.Log(cTarget.GetA());
            //cTarget.transform.GetComponent<>

            //�÷��̾�
            //ComponentTest ��ũ��Ʈ�� �پ��ִ� ���� ������Ʈ�� Ʈ������ ��ü
            //this.transform
            //this.transform.GetComponent<>
            //ComponentTest ��ũ��Ʈ�� �پ��ִ� ���� ������Ʈ ��ü
            //this.gameObject
            //this.gameObject.GetComponent<>
            //this.transform.gameObject
            //this.gameObject.transform
        }

        // Update is called once per frame
        void Update()
        {
            //Ÿ������ �̵�
            // ���� * Time.deltaTime * �ӵ�
            Vector3 dir = target.position - this.transform.position;
            this.transform.Translate(dir.normalized * Time.deltaTime * moveSpeed);
        }
    }
}