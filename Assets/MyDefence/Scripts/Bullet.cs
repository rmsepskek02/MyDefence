using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyDefence
{
    public class Bullet : MonoBehaviour
    {
        //�ʵ�
        #region Variable
        //bullet�� �̵��ؼ� hit �ϴ� target
        private Transform target;

        //bullet �̵� �ӵ�
        public float moveSpeed = 70f;

        //impact ����Ʈ
        public GameObject bulletImpactPrefab;
        #endregion

        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(target == null)
            {
                Destroy(this.gameObject);
                return;
            }

            //�̵��ϱ�
            Vector3 dir = target.position - transform.position;
            float distanceThisFrame = Time.deltaTime * moveSpeed;
            if (dir.magnitude < distanceThisFrame)
            {
                //Hit�� ����
                HitTarget();
                return;
            }
            transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);
        }

        //Ÿ���� ����
        void HitTarget()
        {
            //Hit ó��
            //Hit ȿ��
            GameObject effectGo = Instantiate(bulletImpactPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);

            //Ÿ��, źȯ ���ӿ�����Ʈ kill (Destroy)
            Destroy(target.gameObject);
            Destroy(this.gameObject);
        }
    }
}