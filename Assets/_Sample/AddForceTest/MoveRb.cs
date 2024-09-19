using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{

    public class MoveRb : MonoBehaviour
    {
        public Rigidbody rb;
        public float moveSpeed = 1.0f;
        public float force = 30.0f;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            //transform.Translate(-Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            rb.AddForce(-Vector3.forward * force, ForceMode.Force);
        }

    }
}

/*
3D 충돌체 (충돌 오브젝트)
정적 충돌체 : 움직이지 않는 충돌체
 - Static : 벽, 건물, 바위

동적 충돌체 : 움직이는 충돌체 - Rigidbdoy (오브젝트 움직임을 물리력으로 제어)
 - Kinematic : 외부에서 오는 물리력을 무시, 운동학, 이동하는 발판, 문
 - Dynamic : 그 외 물리력으로 제외되는 오브젝트

 충돌체크
 : 두 오브젝트 모두 충돌체를 가지고 있어야만 함
 : 그중 하나는 Dynamic 이여야 하고 Dynamic이 이동하는 오브젝트 이어야 한다
 : 이동하는 kinematic은 Dynamic과 충돌체크 된다
 
 2D 충돌체 (충돌 오브젝트)
정적 충돌체 : 움직이지 않는 충돌체
 - Static : 벽, 건물, 바위

동적 충돌체 : 움직이는 충돌체 - Rigidbdoy (오브젝트 움직임을 물리력으로 제어)
 - Static :
 - Kinematic : 외부에서 오는 물리력을 무시, 운동학, 이동하는 발판, 문
 - Dynamic : 그 외 물리력으로 제외되는 오브젝트

 충돌체크
 : 두 오브젝트 모두 충돌체를 가지고 있어야만 함
 : 그중 하나는 Dynamic 이여야 하고 Dynamic이 이동하는 오브젝트 이어야 한다
 : 이동하는 kinematic은 Dynamic과 충돌체크 된다 


// AddForce : ForceMode 4가지
ForceMonde.Force (연속, 질량고려)
 - 바람, 자기력처럼 연속적으로 힘을 주는 것
 - 짧은 시간에 발생하는 힘

ForceMonde.Acceleration (연속, 질량 무시)
 - 지구의 중력
 - 질량에 상관없이 일정한 가속량을 주는 힘

ForceMonde.Impulse (불연속, 질량 고려)
 - 폭발, 타격
 - 순간적으로 작용하는 힘

ForceMonde.VelocityChange (불연속, 질량 무시)
 - 질량을 무시하고 직접적으로 속도의 변화를 주는 힘
 */