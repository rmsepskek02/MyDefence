using UnityEngine;

namespace MyDefence
{
    public class Tile : MonoBehaviour
    {
        #region Variables
        //Ÿ�Ͽ� ��ġ�� �ͷ� ���ӿ�����Ʈ ��ü
        private GameObject turret;

        //������ �ν��Ͻ�
        private Renderer rend;

        //���콺�� ���� ������ Ÿ�� �÷���
        //public Color hoverColor;
        //��Ÿ���� �⺻ Color
        //private Color startColor;

        //���콺�� ���� ������ Ÿ�� ���͸���
        public Material hoverMaterial;
        //��Ÿ���� �⺻ Material
        private Material startMaterial;

        //�ͷ�������
        public GameObject turretPrefab;

        //�ͷ� ��ġ ��ġ ������
        public Vector3 offset;
        #endregion

        private void Start()
        {
            //�ʱ�ȭ
            //rend = this.transform.GetComponent<Renderer>();
            rend = this.GetComponent<Renderer>();
            rend.enabled = false;
            //startColor = rend.material.color;
            startMaterial = rend.material;
        }

        private void OnMouseEnter()
        {            
            rend.enabled = true;
            //rend.material.color = hoverColor;
            rend.material = hoverMaterial;
        }

        private void OnMouseDown()
        {
            if (turret != null)
            {
                Debug.Log("�̹� �ͷ��� ��ġ �Ǿ� �ֽ��ϴ�");
                return;
            }

            Debug.Log("���콺 Ŭ�� - ���⿡ �ͷ� ��ġ");
            turret = Instantiate(BuildManager.Instance.GetTurretToBuild(), this.transform.position + offset, Quaternion.identity);
        }

        private void OnMouseExit()
        {
            rend.enabled = false;
            //rend.material.color = startColor;
            rend.material = startMaterial;
        }
    }
}