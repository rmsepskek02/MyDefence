using UnityEngine;
using UnityEngine.EventSystems;

namespace MyDefence
{
    public class Tile : MonoBehaviour
    {
        #region Variables
        //타일에 설치된 터렛 게임오브젝트 객체
        private GameObject turret;

        //현재 선택된 터렛 blueprint(prefab, cost, ....)
        private TurretBlueprint blueprint;

        //빌드매니저 객체
        private BuildManager buildManager;

        //렌더러 인스턴스
        private Renderer rend;

        //마우스가 위에 있을때 타일 컬러값
        //public Color hoverColor;
        //맵타일의 기본 Color
        //private Color startColor;
        public Color notEnoughColor;

        //마우스가 위에 있을때 타일 메터리얼
        public Material hoverMaterial;
        //맵타일의 기본 Material
        private Material startMaterial;

        //터렛 건설 이펙트 프리팹
        public GameObject buildEffectPrefab;

        //터렛 설치 위치 보정값
        public Vector3 offset;
        #endregion

        private void Start()
        {
            //초기화
            buildManager = BuildManager.Instance;

            //rend = this.transform.GetComponent<Renderer>();
            rend = this.GetComponent<Renderer>();
            rend.enabled = false;
            //startColor = rend.material.color;
            startMaterial = rend.material;
        }

        private void OnMouseEnter()
        {
            //마우스 포인터가 UI위에 있으면
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            //터렛을 선택하지 않으면
            if (buildManager.CannotBuild)
            {
                return;
            }

            rend.enabled = true;
            //rend.material.color = hoverColor;
            rend.material = hoverMaterial;

            //선택한 터렛을 건설한 비용을 가지고 있는지 잔고확인
            if (buildManager.HasBuildMoney == false)
            {
                rend.material.color = notEnoughColor;
            }
        }

        private void OnMouseDown()
        {
            //마우스 포인터가 UI위에 있으면
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            if (turret != null)
            {
                Debug.Log("이미 터렛이 설치 되어 있습니다");
                return;
            }

            if (buildManager.CannotBuild)
            {
                Debug.Log("터렛을 설치하지 못했습니다"); //터렛을 선택하지 않은 상태
                return;
            }

            blueprint = buildManager.GetTurretToBuild();

            //돈을 지불한다 100, 250
            //Debug.Log($"터렛 건설비용: {blueprint.cost}");
            if(PlayerStats.UseMoney(blueprint.cost))
            {
                //터렛 건설 이펙트
                GameObject effectGo = Instantiate(buildEffectPrefab, this.transform.position + offset, Quaternion.identity);
                Destroy(effectGo, 2f);

                //터렛 건설
                turret = Instantiate(blueprint.turretPrefab, this.transform.position + offset, Quaternion.identity);
                //Debug.Log($"건설하고 남은돈: {PlayerStats.Money}");
            }
        }

        private void OnMouseExit()
        {
            rend.enabled = false;
            //rend.material.color = startColor;
            rend.material = startMaterial;
        }
    }
}