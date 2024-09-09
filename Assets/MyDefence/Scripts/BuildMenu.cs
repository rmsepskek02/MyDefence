using UnityEngine;

namespace MyDefence
{
    public class BuildMenu : MonoBehaviour
    {
        #region Variables
        private BuildManager buildManager;
        #endregion

        private void Start()
        {
            //초기화
            buildManager = BuildManager.Instance;
        }


        //기본 터렛 버튼을 클릭시 호출
        public void SelectBasicTurret()
        {
            Debug.Log("기본 터렛을 선택 하였습니다");
            //설치할 터렛에 기본 터렛(프리팹)을 저장
            buildManager.SetTurretToBuild(buildManager.basicTurretPrefab);
        }

        //다른 터렛 버튼 클릭시 호출
        public void SelectAnotherTurret()
        {
            //설치할 터렛에 다른 터렛(프리팹)을 저장
            buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);
        }
    }
}