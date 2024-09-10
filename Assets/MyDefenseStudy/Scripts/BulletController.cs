using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float moveSpeed = 70.0f;
    public float hitRange = 0.5f;
    public GameObject target;
    public GameObject bulletEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
            MoveToTarget(target);
        else
            Destroy(this.gameObject);
    }

    // 타겟으로 이동
    public void MoveToTarget(GameObject _target)
    {
        // 타겟으로 방향
        Vector3 dir = _target.transform.position - transform.position;
        // 이동
        //transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        transform.Translate(dir * moveSpeed * Time.deltaTime, Space.World);
        HitTartget(_target);
    }

    // 타켓 Hit
    protected virtual void HitTartget(GameObject _target)
    {
        // 거리값 계산
        //if (Vector3.Distance(_target.transform.position, transform.position) <= hitRange)
        //{
        //    // 타겟 파괴
        //    Destroy(_target);
        //    // 이펙트 생성
        //    GameObject _bulletEffect = Instantiate(bulletEffect, transform.position, Quaternion.identity);
        //    // 이펙트 파괴 예약
        //    Destroy(_bulletEffect, 2f);
        //    // 총알 파괴
        //    Destroy(gameObject);
        //}
        Vector3 dir = _target.transform.position - transform.position;
        float distanceThisFrame = Time.deltaTime * moveSpeed;
        if (dir.magnitude < distanceThisFrame)
        {
            //Hit로 판정
            // 타겟 파괴
            OnDamaged(_target.transform);
            // 이펙트 생성
            GameObject _bulletEffect = Instantiate(bulletEffect, transform.position, Quaternion.identity);
            // 이펙트 파괴 예약
            Destroy(_bulletEffect, 2f);
            // 총알 파괴
            Destroy(gameObject);
            return;
        }
    }
    void OnDamaged(Transform target)
    {
        Destroy(target.gameObject);
    }
    // 기즈모 그리기
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        // 기즈모로 구 그리기
        Gizmos.DrawWireSphere(transform.position, hitRange);
    }
}
