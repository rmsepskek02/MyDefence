using UnityEngine;

namespace MyDefence
{
    //건설할 터렛 선택을 관리하는 클래스
    public class BuildMenu : MonoBehaviour
    {
        #region Variables
        private BuildManager buildManager;

        //기본 터렛 프리팹
        public TurretBlueprint basicTurret;
        //미사일 런처 프리팹
        public TurretBlueprint missileLauncher;
        #endregion

        private void Start()
        {
            //초기화
            buildManager = BuildManager.Instance;
        }


        //기본 터렛 버튼을 클릭시 호출
        public void SelectBasicTurret()
        {
            //설치할 터렛에 기본 터렛(프리팹)을 저장
            buildManager.SetTurretToBuild(basicTurret);
        }

        //미사일 런처 버튼 클릭시 호출
        public void SelectMissileLauncher()
        {
            //설치할 터렛에 다른 터렛(프리팹)을 저장
            buildManager.SetTurretToBuild(missileLauncher);
        }
    }
}