using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sample
{
    public class MapTileManager : MonoBehaviour
    {
        // �ʵ�
        // ������ ������Ʈ
        public GameObject tilePrefab;
        // �θ��� transform
        public Transform parent;

        // Start is called before the first frame update
        void Start()
        {
            //CreateMapTile(3, 6);
            //GenerateRandomMapTile(15);

            Debug.Log("[1]��ŸƮ�ڷ�ƾ �Լ� ȣ��");
            StartCoroutine(GenerateMapTile(10,10));
            Debug.Log("[9]��ŸƮ�ڷ�ƾ �Լ� ���� ����");
        }

        // Update is called once per frame
        void Update()
        {
            //GenerateRandomMapTile(10);
        }

        // row x column �� ���ʷ����� �����
        void CreateMapTile(int row, int column)
        {
            //GameObject go = Instantiate(tilePrefab);
            //go.transform.position = new Vector3(-5.0f, 0f, -8.0f);

            for (var i = 0; i < 2 * row; i += 2)
            {
                for (var j = 0; j < 2 * column; j += 2)
                {
                    Instantiate(tilePrefab, new Vector3(i, 0f, j), Quaternion.identity, parent);
                }
            }
        }

        void GenerateRandomMapTile(int n)
        {
            for(var k= 0; k < n; k++)
            {
                int x = Random.Range(0, 10) * 2;
                int z = Random.Range(0, 10) * 2;
                Instantiate(tilePrefab, new Vector3(x, 0f, z), Quaternion.identity, parent);
            }
        }

        IEnumerator GenerateMapTile(int row, int column)
        {
            Debug.Log("[2]�ڷ�ƾ �Լ� ����");

            int count = 0;
            while(count < 100)
            {
                count++;
                for (var i = 0; i < 2 * row; i += 2)
                {
                    for (var j = 0; j < 2 * column; j += 2)
                    {
                        Instantiate(tilePrefab, new Vector3(i, 0f, j), Quaternion.identity, parent);
                        yield return new WaitForSeconds(0.1f);
                    }
                }
            }

            Debug.Log("[4]�ڷ�ƾ �Լ� ����");
        }
    }
}
