using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sample
{
    public class MapTileManager : MonoBehaviour
    {
        // 필드
        // 생성할 오브젝트
        public GameObject tilePrefab;
        // 부모의 transform
        public Transform parent;

        // Start is called before the first frame update
        void Start()
        {
            //CreateMapTile(3, 6);
            //GenerateRandomMapTile(15);

            Debug.Log("[1]스타트코루틴 함수 호출");
            StartCoroutine(GenerateMapTile(10,10));
            Debug.Log("[9]스타트코루틴 함수 다음 실행");
        }

        // Update is called once per frame
        void Update()
        {
            //GenerateRandomMapTile(10);
        }

        // row x column 맵 제너레이터 만들기
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
            Debug.Log("[2]코루틴 함수 시작");

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

            Debug.Log("[4]코루틴 함수 종료");
        }
    }
}
