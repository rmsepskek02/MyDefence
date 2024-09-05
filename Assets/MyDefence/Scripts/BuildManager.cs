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

        //타일에 설치할 터렛
        private GameObject turretToBuild;
        public GameObject basicTurretPrefab;

        private void Start()
        {
            //초기화
            turretToBuild = basicTurretPrefab;
        }

        public GameObject GetTurretToBuild()
        {
            return turretToBuild;
        }
    }
}