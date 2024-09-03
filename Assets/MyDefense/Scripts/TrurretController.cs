using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrurretController : MonoBehaviour
{
    // ����� ���� ����
    public Color gizmoColor;
    public float gizmoRadius = 7.0f;
    public GameObject[] enemyList;
    public float rotationSpeed = 5.0f;
    public Transform partToRotate;
    public GameObject bullet;
    public Transform FirePoint;
    public float shootDelay = 1.0f;
    float shootTime = 0;
    float time = 0;
    GameObject closestObject = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        closestObject = CheckMinDistance(enemyList);
        TurnObject(closestObject);
    }

    // Enemy ��� ã��
    GameObject[] FindEnemy()
    {
        Debug.Log("FIND");
        return GameObject.FindGameObjectsWithTag("Enemy");
    }

    // ���� ����� ������Ʈ ã��
    GameObject CheckMinDistance(GameObject[] goList)
    {
        if (time > 0.5f)
        {
            enemyList = FindEnemy();
            time = 0;
        }
        if (goList.Length == 0 || goList == null) return null;
        // �ּ� �Ÿ��� ������ ������ ���� ����� ������Ʈ
        float minDistance = Mathf.Infinity;
        GameObject _closestObject = null;

        // Ư�� ������Ʈ�� �� ������Ʈ ���� �Ÿ��� ���
        foreach (GameObject obj in goList)
        {
            if (obj == null) continue;

            float distance = Vector3.Distance(obj.transform.position, transform.position);

            // ���� �Ÿ��� �ּ� �Ÿ����� �۴ٸ�, ����
            if (distance < minDistance)
            {
                minDistance = distance;
                _closestObject = obj;
            }
        }

        return _closestObject;
    }

    // ������Ʈ ��ǥ���� �ٶ󺸸� ȸ���ϱ�
    void TurnObject(GameObject target)
    {
        if (target == null) return;
        // ��Ÿ� ���
        if (Vector3.Distance(target.transform.position, transform.position) > gizmoRadius) return;

        ShootBullet(target);

        // Ÿ���� ��ġ���� ���� ��ġ������ ���� ���͸� ���
        Vector3 direction = target.transform.position - partToRotate.transform.position;
        // Ÿ���� �ٶ󺸴� ȸ���� ���
        Quaternion targetRotation = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 90, 0);
        // ���� ȸ������ Ÿ�� ȸ������ �ε巴�� ȸ��
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, targetRotation, rotationSpeed * Time.deltaTime).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    // �Ѿ� �߻�
    void ShootBullet (GameObject target)
    {
        shootTime += Time.deltaTime;
        // shootDelay ���� �߻�
        if (shootDelay <= shootTime)
        {
            // �Ѿ� ����
            GameObject _bullet = Instantiate(bullet, FirePoint.transform.position, Quaternion.identity);
            // �Ѿ��� Ÿ�� ����
            _bullet.GetComponent<BulletController>().target = target;
            
            Debug.Log("SHOOT");
            shootTime = 0;
        }
    }
    // ����� �׸���
    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        // ������ �� �׸���
        Gizmos.DrawWireSphere(transform.position, gizmoRadius);
    }

}