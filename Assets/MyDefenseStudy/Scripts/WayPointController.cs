using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointController : MonoBehaviour
{
    public GameObject startPoint;
    public static List<Vector3> wayVectors = new List<Vector3>();
    public static List<Transform> trList = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        wayVectors.Clear();
        trList.Clear();
        wayVectors = CreateVectors();
        trList = CreateListWayPoint();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // enemy 이동 경로 벡터 List
    List<Vector3> CreateVectors()
    {
        List<Vector3> vtList = new List<Vector3>();
        Vector3 direction = transform.GetChild(0).transform.position - startPoint.transform.position;

        vtList.Add(direction.normalized);

        for(var i = 0; i < transform.childCount - 1; i++)
        {
            Transform prev = transform.GetChild(i);
            Transform after = transform.GetChild(i + 1);
            direction = after.position - prev.position;
            vtList.Add(direction.normalized);
        }

        return vtList;
    }

    // 자식오브젝트들의 Transform List를 반환
    List<Transform> CreateListWayPoint()
    {
        for (var i = 0; i < transform.childCount; i++)
        {
            trList.Add(transform.GetChild(i));
        }

        return trList;
    }
}
