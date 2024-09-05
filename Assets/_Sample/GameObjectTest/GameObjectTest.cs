using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sample.ObjectTest;

namespace Sample
{
    public class GameObjectTest : MonoBehaviour
    {
        //�ʵ�
        //2)
        public Transform publicTransform;
        public GameObject publicObject;

        //3)
        private GameObject[] tagObjects;
        private GameObject tagObject;

        //4)
        public GameObject prefabObejct;

        //5)
        public Transform parentObject;
        private Transform[] childObjects;


        // Start is called before the first frame update
        void Start()
        {
            //1)
            //this.gameObject
            //this.transform

            //2)
            //publicTransform
            //publicObject

            //3)
            //tagObjects = GameObject.FindGameObjectsWithTag("tagString");
            //tagObject = GameObject.FindGameObjectWithTag("tagString");

            //4)
            //GameObject prefabGo = Instantiate(prefabObejct, this.transform.position, Quaternion.identity);

            //5)
            //childObjects = new Transform[parentObject.childCount];
            //for (int i = 0; i < childObjects.Length; i++)
            //{
            //    childObjects[i] = parentObject.GetChild(i);
            //}

            //6)
            //StaticClass.number = 10;

            //Singleton
            //Singleton singleton = new Singleton();
            //Debug.Log(singleton.ToString());

            var objectA = Singleton.Instance;
            var objectB = Singleton.Instance;
            if (objectA == objectB)
            {
                Debug.Log(objectA);
            }

            //SingletonTest.Instance.number = 10;
        }
    }
}


/*
(���̶�Űâ�� �ִ�)���ӿ�����Ʈ�� gameobject, transform �����ϴ� ���,
gameobject, transform�� ��ü�� �������� ���

1) gameobject�� ��ũ��Ʈ �ҽ��� ������Ʈ�� �߰��Ͽ� ����(this) �����´�
2) ���������� ������Ʈ�� gameobject, transform ��ü(�ν��Ͻ�)�� public �� �ʵ�� ������ ��
����Ƽ ������ ���� �ν����� â���� ���� �巡�� �ؼ� �����´�
3) Find - ����Ƽ���� �����ϴ� API�� �̿��Ͽ� gameobject, transform�� ��ü�� ��ȯ�޾� �����´�
, GameObject.FindGameObjectsWithTag, GameObject.FindGameObjectWithTag
4) prefab ���ӿ�����Ʈ ������ Instantiate �Լ��� ��ȯ������ gameobject�� ��ü�� �����´�
5) �θ� �ڽİ��踦 �̿��ؼ� ���� gameobject�� ��ü�� �����´�
6) static �ʵ�: Ŭ�����̸�.�ʵ��̸�, �̱���

*/
