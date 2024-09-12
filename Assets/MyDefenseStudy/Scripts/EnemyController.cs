using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    List<Vector3> wpVector;
    List<Transform> wpTr;
    public float moveSpeed = 2.0f;
    public int hp;
    public GameObject destroyEffect;
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
        if (hp <= 0)
        {
            PlayerStats.AddMoney(50);
            GameObject _destroyEffect = Instantiate(destroyEffect, transform.position, Quaternion.Euler(-90f, 0f, 0f));

            Destroy(_destroyEffect, 2f);
            Destroy(gameObject);
        }
    }

    // enemy 이동 알고리즘
    void TranslateObj(List<Transform> objTrList, int i)
    {
        // idx 값이 List의 index를 넘어가지 않도록
        if (wpIdx >= objTrList.Count) wpIdx = objTrList.Count - 1;

        // WayPoint에 도착하지 않은 경우 WayPoint로 이동
        if (!ArePositionsSimilar(transform.position, objTrList[i].position, 0.5f))
            transform.Translate(wpVector[i] * Time.deltaTime * moveSpeed);

        // 도착했다면 다음 웨이포인트로 가도록 idx 증가
        else
            wpIdx++;

        // 종점 도착
        if (ArePositionsSimilar(transform.position, objTrList[objTrList.Count - 1].position, 0.5f))
        {
            PlayerStats.ReduceLife();
            Destroy(this.gameObject);
        }
    }

    // 두 Obj의 위치값이 얼마나 비슷한지 
    bool ArePositionsSimilar(Vector3 posA, Vector3 posB, float tolerance)
    {
        return Vector3.Distance(posA, posB) <= tolerance;
    }
}
