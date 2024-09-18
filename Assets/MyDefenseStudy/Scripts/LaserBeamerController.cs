using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamerController : TrurretController
{
    private LineRenderer lineRenderer;
    GameObject tempGo;
    public float slow;
    public bool isSlow;
    float atkTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        atk = 30;
        slow = 0.6f;
        atkTime = 0;
        // 선의 너비 설정 (시작, 끝 너비)
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void ShootBullet(GameObject target)
    {
        if (target == null)
        {
            lineRenderer.positionCount = 0;
            return;
        }
        // 타겟이 바뀌었는지 체크 (현재 타겟과 tempGo 비교)
        if (tempGo != target)
        {
            Debug.Log("Target changed = " + target.gameObject.name);
            tempGo = target;  // 새로운 타겟 저장
            isSlow = false;   // 타겟이 바뀌었으므로 상태 초기화
        }
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, firePoint.transform.position);  // 첫 번째 점
        lineRenderer.SetPosition(1, target.transform.position);  // 두 번째 점
        atkTime += Time.deltaTime;
        Damagable damagable = target.gameObject.GetComponent<Damagable>();
        if (atkTime >= 1.0f)
        {
            if (damagable != null)
            {
                damagable.TakeDamage(atk);
                Debug.Log("isSlow = " + isSlow);
                atkTime = 0;
            }
        }

        if (isSlow == true) return;
        Slowable slowable = target.gameObject.GetComponent<Slowable>();
        isSlow = true;
        if (slowable != null)
        {
            Debug.Log("SLOWABLE");
            slowable.Slow(slow);
        }
    }
}
