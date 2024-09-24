using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

namespace MyDefence
{
    public class Tile : MonoBehaviour
    {
        #region Variables
        //타일에 설치된 터렛 게임오브젝트 객체
        private GameObject turret;

        //현재 선택된 터렛 blueprint(prefab, cost, ....)
        public TurretBlueprint blueprint;

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

        //터렛 판매 이펙트 프리팹
        public GameObject sellEffectPrefab;

        //터렛 업그레이드 여부
        public bool IsUpgrade { get; private set; }
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
            IsUpgrade = false;
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
                //Debug.Log("타일에 터렛이 설치되어 있으면 타일 UI 보여주기");
                buildManager.SelectTile(this);
                return;
            }

            if (buildManager.CannotBuild)
            {
                Debug.Log("터렛을 설치하지 못했습니다"); //터렛을 선택하지 않은 상태
                return;
            }

            BuildTurret();
        }

        private void BuildTurret()
        {
            //설치할 터렛의 속성값 가져오기 (터렛 프리팹, 건설비용, 업그레이드 프리팹, 업그레이드 비용.....)
            blueprint = buildManager.GetTurretToBuild();

            //돈을 지불한다 100, 250
            //Debug.Log($"터렛 건설비용: {blueprint.cost}");
            if (PlayerStats.UseMoney(blueprint.cost))
            {
                //터렛 건설 이펙트
                GameObject effectGo = Instantiate(buildEffectPrefab, GetBuildPosition(), Quaternion.identity);
                Destroy(effectGo, 2f);

                //터렛 건설
                turret = Instantiate(blueprint.turretPrefab, GetBuildPosition(), Quaternion.identity);
                //Debug.Log($"건설하고 남은돈: {PlayerStats.Money}");
            }
        }

        public void UpgradeTurret()
        {
            //설치한 터렛의 속성값 체크
            if (blueprint == null)
            {
                Debug.Log("업그레이드에 실패 했습니다");
                return;
            }

            //Debug.Log("터렛 업그레이드");
            if (PlayerStats.UseMoney(blueprint.upgradeCost))
            {
                //터렛 건설 이펙트
                GameObject effectGo = Instantiate(buildEffectPrefab, GetBuildPosition(), Quaternion.identity);
                Destroy(effectGo, 2f);

                //기존 터렛 킬
                Destroy(turret);

                //업그레이드 여부
                IsUpgrade = true;

                //터렛 건설
                turret = Instantiate(blueprint.turretUpgradePrefab, GetBuildPosition(), Quaternion.identity);
            }
        }

        public void SellTurret()
        {
            //판매가격 저장
            int sellMoney = blueprint.GetSellCost();            

            //터렛을 킬
            Destroy(turret);

            //판매 이펙트
            GameObject effectGo = Instantiate(sellEffectPrefab, GetBuildPosition(), Quaternion.identity);
            Destroy(effectGo, 2f);

            //건설 관련 속성 초기화            
            turret = null;
            blueprint = null;
            IsUpgrade = false;

            //판매가격 벌기
            PlayerStats.AddMoney(sellMoney);
        }

        //터렛 설치 위치
        public Vector3 GetBuildPosition()
        {
            return this.transform.position + blueprint.offset;
        }

        private void OnMouseExit()
        {
            rend.enabled = false;
            //rend.material.color = startColor;
            rend.material = startMaterial;
        }
    }
}