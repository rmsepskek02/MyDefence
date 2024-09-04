using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class MapTileGenerater : MonoBehaviour
    {
        //�ʵ�
        //��Ÿ�� ������
        public GameObject tilePrefab;

        //�����Ǵ� ��Ÿ�ϵ��� �θ� ������Ʈ
        //public Transform parent;

        //��Ÿ�� ���� ���� Ȯ��
        private bool isCreate = false;


        // Start is called before the first frame update
        void Start()
        {
            //[1] Ư���� ��ġ�� �����ϱ�
            //Instantiate(tilePrefab, new Vector3(5f, 0f, 8f), Quaternion.identity);
            //Vector3 position = new Vector3(5f, 0f, 8f);
            //Instantiate(tilePrefab, position, Quaternion.identity);

            //GameObject go = Instantiate(tilePrefab);
            //go.transform.position = new Vector3(5f, 0f, 8f);

            //[2] 10x10 �� Ÿ�� �����ϱ�
            //CreateMapTile();

            //[3] 6x8 �� Ÿ�� �����ϱ� 7x5
            //CreateMapTile(7, 5);

            //[4] ������ġ�� ��Ÿ�� 10�� �����ϱ�
            //GenerateRandomMapTile(10);


            //[5] 1���Ŀ� ��Ÿ���� Ư���� ��ġ�� �����ϱ�
            //Debug.Log("[1]��ŸƮ�ڷ�ƾ �Լ� ȣ��");
            //StartCoroutine(GenerateMapTile());
            //Debug.Log("[9]��ŸƮ�ڷ�ƾ �Լ� ���� ���� ���");

            //[6] 10x10 �� Ÿ�� �����ϴµ� Ÿ�� �ϳ��� ���
            //�ϳ� ��� 0.1�� ������ ���� Ÿ�� ���
            //StartCoroutine(GenearateMapTile2());
        }

        // Update is called once per frame
        void Update()
        {
            if(isCreate == false)
            {
                Debug.Log("[1]��ŸƮ�ڷ�ƾ �Լ� ȣ��");
                StartCoroutine(GenearateMapTile2());

                Debug.Log("[9]��ŸƮ�ڷ�ƾ �Լ� ȣ�� �Ϸ�");
                isCreate = true;
            }
            
        }

        IEnumerator GenerateMapTile()
        {
            Debug.Log("[2]�ڷ�ƾ �Լ� ����");
            //2�� ����
            yield return new WaitForSeconds(2f);

            Debug.Log("[3]2�� ������ ��Ÿ�� ����");
            Vector3 position = new Vector3(5f, 0f, 8f);
            Instantiate(tilePrefab, position, Quaternion.identity);

            //2�� ����
            yield return new WaitForSeconds(2f);

            Debug.Log("[4]2�� ������ ��Ÿ�� ����");
            position = new Vector3(8f, 0f, 5f);
            Instantiate(tilePrefab, position, Quaternion.identity);

            Debug.Log("[5]�ڷ�ƾ �Լ� ����");
        }

        IEnumerator GenearateMapTile2()
        {
            Debug.Log("[2]�ڷ�ƾ �Լ� ����");

            Debug.Log("[3]��Ÿ�� ��� ����");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Vector3 position = new Vector3(i * 2.0f, 0f, -j * 2.0f);
                    Instantiate(tilePrefab, position, Quaternion.identity, this.transform);

                    Debug.Log("[4]0.1�� ����");
                    yield return new WaitForSeconds(0.1f);
                }
            }
        }


        //10x10 �� ���׷����� �����
        void CreateMapTile()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Vector3 position = new Vector3(i * 2.0f, 0f, -j * 2.0f);
                    Instantiate(tilePrefab, position, Quaternion.identity);
                }
            }
        }

        // row x column �� ���׷����� ����� - 78
        void CreateMapTile(int row, int column)
        {
            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    Vector3 position = new Vector3(i * 2.0f, 0f, -j * 2.0f);
                    //Instantiate(tilePrefab, position, Quaternion.identity);
                    //Instantiate(tilePrefab, position, Quaternion.identity, parent);
                    //Instantiate(tilePrefab, position, Quaternion.identity, this.transform);

                    //GameObject go = Instantiate(tilePrefab);
                    GameObject go = Instantiate(tilePrefab, this.transform);
                    go.transform.position = position;
                }
            }
        }

        void GenerateRandomMapTile(int n)
        {
            int i = 0, j = 0;

            for(int k = 0 ;k < n ;k++)
            {
                i = Random.Range(0, 10);
                j = Random.Range(0, 10);
                Vector3 position = new Vector3(i * 2.0f, 0f, -j * 2.0f);

                Instantiate(tilePrefab, position, Quaternion.identity, this.transform);
            }
        }
    }
}