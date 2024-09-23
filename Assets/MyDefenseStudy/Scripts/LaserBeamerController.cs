using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamerController : TurretController
{
    private LineRenderer lineRenderer;
    public float slow;
    public ParticleSystem laserEffect;
    public Light laserLight;
    float atkTime = 0;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        lineRenderer = GetComponent<LineRenderer>();
        atk = turretBp.atk;
        slow = 0.4f;
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
            if (lineRenderer.enabled == true)
            {
                lineRenderer.enabled = false;
                laserLight.enabled = false;
                laserEffect.Pause();
            }
            return;
        }
        if (lineRenderer.enabled == false)
        {
            lineRenderer.enabled = true;
            laserLight.enabled = true;
            laserEffect.Play();
        }
        
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, firePoint.transform.position);  // 첫 번째 점
        lineRenderer.SetPosition(1, target.transform.position);  // 두 번째 점
        SphereCollider sc = target.GetComponent<SphereCollider>();
        float radius = sc.radius;
        Vector3 laserDir = (transform.position - target.transform.position).normalized;
        laserEffect.transform.position = target.transform.position + laserDir * radius;
        laserEffect.gameObject.transform.LookAt(gameObject.transform);

        atkTime += Time.deltaTime;
        Damagable damagable = target.gameObject.GetComponent<Damagable>();
        if (damagable != null)
        {
            damagable.TakeDamage(atk * atkTime);
            atkTime = 0;
        }

        Slowable slowable = target.gameObject.GetComponent<Slowable>();
        if (slowable != null)
        {
            slowable.Slow(slow);
        }
    }
}
