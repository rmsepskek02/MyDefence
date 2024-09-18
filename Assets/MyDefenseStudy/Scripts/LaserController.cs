using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : BulletController
{
    private LineRenderer lineRenderer;
    public Transform firePoint;
    
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        
        // 선의 너비 설정 (시작, 끝 너비)
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) { Destroy(gameObject); return; }
        MoveToTarget(target);
    }

    protected override void MoveToTarget(GameObject _target)
    {
        // 라인의 각 점의 좌표 설정
        lineRenderer.SetPosition(0, firePoint.transform.position);  // 첫 번째 점
        lineRenderer.SetPosition(1, _target.transform.position);  // 두 번째 점
    }
}
