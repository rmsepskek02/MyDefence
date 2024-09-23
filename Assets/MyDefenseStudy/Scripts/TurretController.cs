using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    // 기즈모 색상 설정
    public Color gizmoColor;
    public float gizmoRadius = 12.0f;
    public float attackRange = 12.0f;
    public GameObject[] enemyList;
    public float rotationSpeed = 5.0f;
    public Transform partToRotate;
    public GameObject bullet;
    public Transform firePoint;
    public float shootDelay = 4.0f;
    float shootTime = 0;
    float time = 0;
    GameObject closestObject = null;
    public int atk = 0;
    public TurretBlueprint turretBp;
    BuildManager bm;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        bm = BuildManager.instance;
        turretBp = bm.GetTurretToBuild();
        atk = turretBp.atk;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        time += Time.deltaTime;
        closestObject = CheckMinDistance(enemyList);
        TurnObject(closestObject);
    }

    // Enemy 모두 찾기
    GameObject[] FindEnemy()
    {
        return GameObject.FindGameObjectsWithTag("Enemy");
    }

    // 가장 가까운 오브젝트 찾기
    GameObject CheckMinDistance(GameObject[] goList)
    {
        if (time > 2.5f)
        {
            enemyList = FindEnemy();
            time = 0;
        }
        if (goList.Length == 0 || goList == null) return null;
        // 최소 거리를 저장할 변수와 가장 가까운 오브젝트
        float minDistance = Mathf.Infinity;
        GameObject _closestObject = null;

        // 특정 오브젝트와 각 오브젝트 간의 거리를 계산
        foreach (GameObject obj in goList)
        {
            if (obj == null) continue;

            float distance = Vector3.Distance(obj.transform.position, transform.position);

            // 현재 거리가 최소 거리보다 작다면, 갱신
            if (distance < minDistance)
            {
                minDistance = distance;
                _closestObject = obj;
            }
        }
        if (_closestObject == null) return null;
        // 사거리 계산
        if (Vector3.Distance(_closestObject.transform.position, transform.position) > gizmoRadius)
            _closestObject = null;

        return _closestObject;
    }

    // 오브젝트 목표물을 바라보며 회전하기
    void TurnObject(GameObject target)
    {
        if (target == null)
        {
            return;
        }

        // 타겟의 위치에서 현재 위치까지의 방향 벡터를 계산
        Vector3 direction = target.transform.position - partToRotate.transform.position;
        // 타겟을 바라보는 회전을 계산
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        // 현재 회전에서 타겟 회전까지 부드럽게 회전
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, targetRotation, rotationSpeed * Time.deltaTime).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        ShootBullet(target);
    }

    // 총알 발사
    protected virtual void ShootBullet(GameObject target)
    {
        if (target == null) return;

        shootTime += Time.deltaTime;
        // shootDelay 마다 발사
        if (shootDelay <= shootTime)
        {
            // 총알 생성
            GameObject _bullet = Instantiate(bullet, firePoint.transform.position, firePoint.rotation);
            BulletController bc = _bullet.GetComponent<BulletController>();

            // 총알의 타겟 설정
            bc.target = target;
            bc.atk = atk;

            shootTime = 0;
        }
    }
    // 기즈모 그리기
    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        // 기즈모로 구 그리기
        Gizmos.DrawWireSphere(transform.position, gizmoRadius);
    }

}