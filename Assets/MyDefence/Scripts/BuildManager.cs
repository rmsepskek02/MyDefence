using UnityEngine;

namespace MyDefence
{
    //�ͷ� �Ǽ��� �����ϴ� Ŭ����
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

        //Ÿ�Ͽ� ��ġ�� �ͷ�
        private GameObject turretToBuild;
        public GameObject basicTurretPrefab;

        private void Start()
        {
            //�ʱ�ȭ
            turretToBuild = basicTurretPrefab;
        }

        public GameObject GetTurretToBuild()
        {
            return turretToBuild;
        }
    }
}