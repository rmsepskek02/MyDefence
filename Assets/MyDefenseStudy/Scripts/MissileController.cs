using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : BulletController
{
    public string enemyTag = "Enemy";
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(target.transform.position);
    }

    // 타켓 Hit
    protected override void HitTartget(GameObject _target)
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
            Explosion();
            // 이펙트 생성
            GameObject _bulletEffect = Instantiate(bulletEffect, transform.position, Quaternion.identity);
            // 이펙트 파괴 예약
            Destroy(_bulletEffect, 2f);
            // 총알 파괴
            Destroy(gameObject);
            return;
        }
    }

    void Explosion()
    {
        //Hit로 판정
        // 타겟 파괴
        Collider[] hitObj = Physics.OverlapSphere(transform.position, hitRange);
        foreach (Collider obj in hitObj)
        {
            if (obj.gameObject.tag == enemyTag)
                obj.gameObject.GetComponent<EnemyController>().hp -= atk;
        }
    }

    // 기즈모 그리기
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        // 기즈모로 구 그리기
        Gizmos.DrawWireSphere(transform.position, hitRange);
    }
}
