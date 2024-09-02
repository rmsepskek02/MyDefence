using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrurretController : MonoBehaviour
{
    // 기즈모 색상 설정
    public Color gizmoColor;
    public float gizmoRadius = 15.0f;
    public GameObject[] enemyList;
    GameObject closestObject = null;
    public float rotationSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyList = FindEnemy();
        closestObject = CheckMinDistance(enemyList);
        TurnObject(closestObject);
    }

    // Enemy 모두 찾기
    GameObject[] FindEnemy()
    {
        GameObject[] _enemyList;
        _enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        return _enemyList;
    }

    // 가장 가까운 오브젝트 찾기
    GameObject CheckMinDistance(GameObject[] goList)
    {
        // 최소 거리를 저장할 변수와 가장 가까운 오브젝트
        float minDistance = Mathf.Infinity;
        GameObject _closestObject = null;

        // 특정 오브젝트와 각 오브젝트 간의 거리를 계산
        foreach (GameObject obj in goList)
        {
            float distance = Vector3.Distance(obj.transform.position, transform.position);

            // 현재 거리가 최소 거리보다 작다면, 갱신
            if (distance < minDistance)
            {
                minDistance = distance;
                _closestObject = obj;
            }
        }

        return _closestObject;
    }

    // 오브젝트 목표물을 바라보며 회전하기
    void TurnObject(GameObject target)
    {
        // 타겟의 위치에서 현재 위치까지의 방향 벡터를 계산
        Vector3 direction = target.transform.position - transform.position;
        // 타겟을 바라보는 회전을 계산
        Quaternion targetRotation = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 90, 0);
        // 현재 회전에서 타겟 회전까지 부드럽게 회전
        Transform rotateTransform = gameObject.transform.GetChild(0).transform;
        rotateTransform.rotation = Quaternion.Lerp(rotateTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    // 기즈모 그리기
    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        // 기즈모로 구 그리기
        Gizmos.DrawSphere(transform.position, gizmoRadius);
    }

}