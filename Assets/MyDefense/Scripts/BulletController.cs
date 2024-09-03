using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 10.0f;
    public GameObject target;
    public GameObject bulletEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
            MoveToTarget(target);
    }

    // 타겟으로 이동
    public void MoveToTarget(GameObject _targetPos)
    {
        // 타겟으로 방향
        Vector3 dir = _targetPos.transform.position - transform.position;
        // 이동
        transform.Translate(dir * bulletSpeed * Time.deltaTime);
        // 거리값 계산
        if(Vector3.Distance(_targetPos.transform.position, transform.position) <= 0.2f)
        {
            Debug.Log("HIT");
            // 타겟 파괴
            Destroy(_targetPos);
            // 이펙트 생성
            GameObject _bulletEffect =Instantiate(bulletEffect, transform.position, Quaternion.identity);
            // 이펙트 활성화
            _bulletEffect.SetActive(true);
            // 이펙트 파괴 예약
            Destroy(_bulletEffect, 2f);
            // 총알 파괴
            Destroy(gameObject);
        }
    }

    // 트리거 충돌이 시작될 때 호출되는 메서드
    void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트의 태그가 "Player"인 경우
        if (other.CompareTag("Enemy"))
        {
            
        }
    }

    // 트리거 충돌이 유지되는 동안 호출되는 메서드
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {

        }
    }

    // 트리거 충돌이 끝날 때 호출되는 메서드
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {

        }
    }
}
