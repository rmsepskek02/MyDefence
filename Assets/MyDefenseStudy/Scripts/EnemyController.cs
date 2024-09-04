using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    List<Vector3> wpVector;
    List<Transform> wpTr;
    public float moveSpeed = 2.0f;
    int wpIdx = 0;
    // Start is called before the first frame update
    void Start()
    {
        wpVector = WayPointController.wayVectors;
        wpTr = WayPointController.trList;
    }

    // Update is called once per frame
    void Update()
    {
        TranslateObj(wpTr, wpIdx);
    }

    // enemy �̵� �˰���
    void TranslateObj(List<Transform> objTrList, int i)
    {
        // idx ���� List�� index�� �Ѿ�� �ʵ���
        if (wpIdx >= objTrList.Count) wpIdx = objTrList.Count - 1; 

        // WayPoint�� �������� ���� ��� WayPoint�� �̵�
        if (!ArePositionsSimilar(transform.position, objTrList[i].position, 0.5f))
            transform.Translate(wpVector[i] * Time.deltaTime * moveSpeed);

        // �����ߴٸ� ���� ��������Ʈ�� ������ idx ����
        else
            wpIdx++;

        // ���� ����
        if(ArePositionsSimilar(transform.position, objTrList[objTrList.Count - 1].position, 0.5f))
            Destroy(this.gameObject);
    }

    // �� Obj�� ��ġ���� �󸶳� ������� 
    bool ArePositionsSimilar(Vector3 posA, Vector3 posB, float tolerance)
    {
        return Vector3.Distance(posA, posB) <= tolerance;
    }
}
