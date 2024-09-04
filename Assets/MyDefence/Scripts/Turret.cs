using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyDefence
{
    //�ͷ��� �����ϴ� Ŭ����
    public class Turret : MonoBehaviour
    {
        //�ʵ�
        #region Variable
        private Transform target;       //Ÿ��
        public Transform partToRotate;  //�ͷ� ȸ���� �����ϴ� ������Ʈ

        public float attackRange = 7f;  //���� ����

        //target ã�� Ÿ�̸�
        public float serachTimer = 0.5f;
        private float countdown = 0f;

        //ȸ��
        public float turnSpeed = 10f;
        #endregion


        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            //0.5�ʸ��� Ÿ�� ã�� ����
            if (countdown <= 0f)
            {
                //Ÿ�̸� ���๮
                UpdateTarget();

                //Ÿ�̸� �ʱ�ȭ
                countdown = serachTimer;
            }
            countdown -= Time.deltaTime;

            //Ÿ���� ã�� ��������
            if (target == null)
            {
                return;
            }

            //Ÿ���� ���� �ѱ��� ȸ��
            Vector3 dir = target.position - partToRotate.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, turnSpeed * Time.deltaTime).eulerAngles;
            partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        }

        //������ ������ target ���� ã�´�
        void UpdateTarget()
        {
            //Debug.Log("UpdateTarget=======");
            //"Enemy" �±׸� ���� ������Ʈ�� ��ü ��������
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            //�Ÿ��� ���� ����� �� ã��
            float minDistance = float.MaxValue; //�ּҰŸ�
            GameObject minEnemy = null;         //�ּҰŸ��� �ִ� ��

            foreach (GameObject enemy in enemies)
            {
                float distance = Vector3.Distance(this.transform.position, enemy.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    minEnemy = enemy;
                }
            }

            //���� ����� ���� ���� ���� �ȿ� �ִ��� üũ
            if(minEnemy != null && minDistance < attackRange)
            {
                target = minEnemy.transform;
            }
            else
            {
                target = null;
            }
        }

        //���ݹ��� Ȯ�ο� ����� �׸���
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, attackRange);
        }
    }
}