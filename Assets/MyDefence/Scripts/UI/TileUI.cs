using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyDefence
{
    public class TileUI : MonoBehaviour
    {
        #region Variables
        private BuildManager buildManager;

        public GameObject tileUI;

        //선택받은 타일
        private Tile targetTile;
        #endregion

        private void Start()
        {
            //초기화
            buildManager = BuildManager.Instance;
        }

        //매개변수로 선택한 타일 정보를 얻어온다
        public void ShowTileUI(Tile tile)
        {
            //선택받은 타일 저장
            targetTile = tile;

            //터렛이 설치된 위치에서 보여준다
            this.transform.position = targetTile.GetBuildPosition();
            tileUI.SetActive(true);
        }

        public void HideTileUI()
        {
            tileUI.SetActive(false);

            //선택받은 타일 초기화
            targetTile = null;
        }

        public void Upgrade()
        {
            targetTile.UpgradeTurret();
            buildManager.DeselectTile();
        }

        public void Sell()
        {
            Debug.Log("Sell Turret");
        }
    }
}
