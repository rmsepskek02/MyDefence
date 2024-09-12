using UnityEngine;

namespace MyDefence
{
    //터렛 건설을 관리하는 클래스
    public class BuildManager : MonoBehaviour
    {
        #region Singleton
        public static BuildManager instance;
        public static BuildManager Instance
        {
            get { return instance; }
        }

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        #endregion

        #region Variables
        //타일에 설치할 터렛의 정보(프리팹, 가격정보)
        private TurretBlueprint turretToBuild;

        //선택한 터렛이 있는지, 선택하지 안했으면 건설 못한다
        public bool CannotBuild => turretToBuild == null;


        //선택한 터렛을 건설한 비용을 가지고 있는지
        public bool HasBuildMoney
        {
            get
            {
                if (turretToBuild == null)
                    return false;

                return PlayerStats.HasMoney(turretToBuild.cost);
            }
        }
        #endregion

        public TurretBlueprint GetTurretToBuild()
        {
            return turretToBuild;
        }

        //매개변수로 받은 터렛 프리팹을 설치할 터렛에 저장        
        public void SetTurretToBuild(TurretBlueprint turret)
        {
            turretToBuild = turret;
        }

    }
}