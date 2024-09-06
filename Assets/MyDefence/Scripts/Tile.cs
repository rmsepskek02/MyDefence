using UnityEngine;

namespace MyDefence
{
    public class Tile : MonoBehaviour
    {
        #region Variables
        //타일에 설치된 터렛 게임오브젝트 객체
        private GameObject turret;

        //렌더러 인스턴스
        private Renderer rend;

        //마우스가 위에 있을때 타일 컬러값
        //public Color hoverColor;
        //맵타일의 기본 Color
        //private Color startColor;

        //마우스가 위에 있을때 타일 메터리얼
        public Material hoverMaterial;
        //맵타일의 기본 Material
        private Material startMaterial;

        //터렛프리팹
        public GameObject turretPrefab;

        //터렛 설치 위치 보정값
        public Vector3 offset;
        #endregion

        private void Start()
        {
            //초기화
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
                Debug.Log("이미 터렛이 설치 되어 있습니다");
                return;
            }

            Debug.Log("마우스 클릭 - 여기에 터렛 설치");
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