using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace MyDefence
{
    public class LazerBeamer : Turret
    {
        #region Variables
        private LineRenderer lineRenderer;
        #endregion

        private void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        void Update()
        {
            //0.5초마다 타겟 찾기 실행
            if (countdown <= 0f)
            {
                //타이머 실행문
                UpdateTarget();

                //타이머 초기화
                countdown = serachTimer;
            }
            countdown -= Time.deltaTime;

            //타겟을 찾지 못했으면
            if (target == null)
            {
                //레이저를 그리지 않는다
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                }
                return;
            }

            //타겟을 향해 총구를 회전
            LockOn();

            //레이저 쏘기
            Lazer();            
        }

        void Lazer()
        {
            if(lineRenderer.enabled == false)
            {
                lineRenderer.enabled = true;
            }

            //라인렌더러 그리기 - 시작지점, 끝지점 지정
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, target.position);
        }
    }
}