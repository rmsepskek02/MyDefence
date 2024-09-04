using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    //�簢�� �����͸� �����ϴ� ����ü
    public struct BoxData
    {
        public float x;     //box x��ǥ
        public float y;     //box y��ǥ
        public float w;     //box width
        public float h;     //box height
    }

    //�� �����͸� �����ϴ� ����ü
    public struct CircleData
    {
        public float x;     //circle x��ǥ
        public float y;     //circle y��ǥ
        public float r;     //circle ������
    }

    public class HitTest : MonoBehaviour
    {
        //�ʵ�
        //Ÿ��
        public Transform _target;

        //�̵� �ӵ�
        private float moveSpeed = 300;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //�̵�

            //�浹üũ ����
            if(CheckPassPosition(_target))
            {
                //�浹ó��
                Debug.Log("�浹");
            }
        }


        //�Ű������� ���� �ΰ��� box�� �浹�ߴ��� üũ
        //�浹�ϸ� true, �浹���� ������ false
        public bool CheckHitBox(BoxData a, BoxData b)
        {
            //�浹���� �ʴ� 4���� ��ġ ����
            //1
            if((a.x + a.w/2) < (b.x - b.w/2))
                return false;

            //2
            if ((a.x - a.w / 2) > (b.x + b.w / 2))
                return false;

            //3
            if ((a.y + a.h / 2) > (b.y - b.h / 2))
                return false;

            //4
            if ((a.y - a.h / 2) < (b.y + b.h / 2))
                return false;

            //�浹���� �ʴ� 4���� ��ġ�� ������ ��쿡�� �浹 ����
            return true;
        }

        //�Ű������� ���� �ΰ��� circle�� �浹�ߴ��� üũ
        //�浹�ϸ� true, �浹���� ������ false
        public bool CheckHitCircle(CircleData a, CircleData b)
        {
            float distX = a.x - b.x;
            float distY = a.y - b.y;

            float distance = Mathf.Sqrt(distX * distX + distY + distY);

            //�ο��� �Ÿ��� �ο��� �������� �պ��� ������ �浹�̶�� ����
            if(distance <= (a.r + b.r))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Ÿ�ٱ����� �Ÿ��� ���� �Ÿ��ȿ� ������ �浹�̶�� ����
        private bool CheckArrivePosition(Transform target)
        {
            //Ÿ�ٱ����� �Ÿ�
            float distance = Vector3.Distance(this.transform.position, target.position);
            if (distance < 0.5f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Ÿ�ٱ��� �̵��� ���� �Ÿ��� �̹�(��)�����ӿ� �̵��ϴ� �Ÿ����� ������ �浹�̶�� ����
        private bool CheckPassPosition(Transform target)
        {
            //Ÿ�ٱ��� �̵��� ���� �Ÿ�
            float distance = Vector3.Distance(this.transform.position, target.position);
            //�̹�(��) �����ӿ� �̵��ϴ� �Ÿ�
            float distanceThisFrame = Time.deltaTime * moveSpeed;

            if(distance < distanceThisFrame)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}