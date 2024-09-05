using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class SingletonTest : MonoBehaviour
    {
        //Ŭ������ �ν��Ͻ� ������ static���� ����
        private static SingletonTest instance;

        public static SingletonTest Instance
        {
            get
            {   
                return instance;
            }
        }

        //����� ���ÿ� instance�� ��ü�� �޾ƿ´�
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;

            //gameObject�� �� ����� �ı��� �ȵȴ�
            //DontDestroyOnLoad(gameObject);
        }

        public int number;
    }
}