using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamerController : TrurretController
{
    private LineRenderer lineRenderer;
    GameObject tempGo;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

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
        if (target == null) return;
        lineRenderer.SetPosition(0, firePoint.transform.position);  // 첫 번째 점
        lineRenderer.SetPosition(1, target.transform.position);  // 두 번째 점
    }
}
