using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrurretController : MonoBehaviour
{
    // ����� ���� ����
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

    // Enemy ��� ã��
    GameObject[] FindEnemy()
    {
        GameObject[] _enemyList;
        _enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        return _enemyList;
    }

    // ���� ����� ������Ʈ ã��
    GameObject CheckMinDistance(GameObject[] goList)
    {
        // �ּ� �Ÿ��� ������ ������ ���� ����� ������Ʈ
        float minDistance = Mathf.Infinity;
        GameObject _closestObject = null;

        // Ư�� ������Ʈ�� �� ������Ʈ ���� �Ÿ��� ���
        foreach (GameObject obj in goList)
        {
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
        // Ÿ���� ��ġ���� ���� ��ġ������ ���� ���͸� ���
        Vector3 direction = target.transform.position - transform.position;
        // Ÿ���� �ٶ󺸴� ȸ���� ���
        Quaternion targetRotation = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 90, 0);
        // ���� ȸ������ Ÿ�� ȸ������ �ε巴�� ȸ��
        Transform rotateTransform = gameObject.transform.GetChild(0).transform;
        rotateTransform.rotation = Quaternion.Lerp(rotateTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    // ����� �׸���
    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        // ������ �� �׸���
        Gizmos.DrawSphere(transform.position, gizmoRadius);
    }

}