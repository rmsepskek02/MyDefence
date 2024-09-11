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
        //타일에 설치할 터렛
        private TurretBlueprint turretToBuild;
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