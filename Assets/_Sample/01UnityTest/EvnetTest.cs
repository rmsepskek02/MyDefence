using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class EvnetTest : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("[1] Awake ����"); //1ȸ�� ����
        }

        private void OnEnable()
        {
            Debug.Log("[7-1] OnEnable ����"); //1ȸ ���� - Ȱ��ȭ �ɶ�
        }

        private void Start()
        {
            Debug.Log("[2] Start ����"); //1ȸ�� ����
        }

        private void FixedUpdate()
        {
            Debug.Log("[3] FixedUpdate ����"); //1�ʿ� 50�� - ����
        }

        private void Update()
        {
            Debug.Log("[4] Update ����"); //�� �����Ӹ��� ȣ��, 1�ʿ� 60�� ȣ��
        }

        private void LateUpdate()
        {
            Debug.Log("[5] LateUpdate ����"); //Update() ���� �ڿ� �ٷ� �ڵ��� ����
        }

        private void OnDisable()
        {
            Debug.Log("[7-1] OnDisable ����"); //1ȸ ���� - ��Ȱ��ȭ �ɶ�
        }

        private void OnDestroy()
        {
            Debug.Log("[6] OnDestroy ����"); //�������
        }

    }
}