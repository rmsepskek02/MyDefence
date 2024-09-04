using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 70.0f;
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

    // Ÿ������ �̵�
    public void MoveToTarget(GameObject _target)
    {
        // Ÿ������ ����
        Vector3 dir = _target.transform.position - transform.position;
        // �̵�
        //transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        transform.Translate(dir * bulletSpeed * Time.deltaTime, Space.World);
        HitTartget(_target);
    }

    // Ÿ�� Hit
    void HitTartget(GameObject _target)
    {
        // �Ÿ��� ���
        if (Vector3.Distance(_target.transform.position, transform.position) <= 0.5f)
        {
            Debug.Log("HIT");
            // Ÿ�� �ı�
            Destroy(_target);
            // ����Ʈ ����
            GameObject _bulletEffect = Instantiate(bulletEffect, transform.position, Quaternion.identity);
            // ����Ʈ �ı� ����
            Destroy(_bulletEffect, 2f);
            // �Ѿ� �ı�
            Destroy(gameObject);
        }
    }

    // Ʈ���� �浹�� ���۵� �� ȣ��Ǵ� �޼���
    void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� �±װ� "Player"�� ���
        if (other.CompareTag("Enemy"))
        {
            
        }
    }

    // Ʈ���� �浹�� �����Ǵ� ���� ȣ��Ǵ� �޼���
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {

        }
    }

    // Ʈ���� �浹�� ���� �� ȣ��Ǵ� �޼���
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {

        }
    }
}
