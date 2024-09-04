using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointController : MonoBehaviour
{
    public GameObject startPoint;
    public static List<Vector3> wayVectors;
    public static List<Transform> trList = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        wayVectors = CreateVectors();
        trList = CreateListWayPoint();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // enemy �̵� ��� ���� List
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

    // �ڽĿ�����Ʈ���� Transform List�� ��ȯ
    List<Transform> CreateListWayPoint()
    {
        for (var i = 0; i < transform.childCount; i++)
        {
            trList.Add(transform.GetChild(i));
        }

        return trList;
    }
}
