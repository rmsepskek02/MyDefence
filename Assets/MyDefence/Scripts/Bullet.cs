using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyDefence
{
    public class Bullet : MonoBehaviour
    {
        //필드
        #region Variable
        //bullet이 이동해서 hit 하는 target
        private Transform target;

        //bullet 이동 속도
        public float moveSpeed = 70f;

        //impact 이펙트
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

            //이동하기
            Vector3 dir = target.position - transform.position;
            float distanceThisFrame = Time.deltaTime * moveSpeed;
            if (dir.magnitude < distanceThisFrame)
            {
                //Hit로 판정
                HitTarget();
                return;
            }
            transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);
        }

        //타겟을 맞춤
        void HitTarget()
        {
            //Hit 처리
            //Hit 효과
            GameObject effectGo = Instantiate(bulletImpactPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);

            //타겟, 탄환 게임오브젝트 kill (Destroy)
            Destroy(target.gameObject);
            Destroy(this.gameObject);
        }
    }
}