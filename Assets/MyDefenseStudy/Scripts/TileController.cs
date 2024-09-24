using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileController : MonoBehaviour
{
    MeshRenderer mesh;
    BuildManager bm;
    public Material hoverMaterial;
    public GameObject createEffect;
    public GameObject destroyEffect;
    private int upgradeStep = 1;
    public int UpgradeStep
    {
        get { return upgradeStep; }
        set
        {
            if (value > 0)        // 조건 추가 (예: 0보다 큰 값만 허용)
            {
                upgradeStep = value;
            }
        }
    }
    public TurretBlueprint turretBlueprint;
    private GameObject targetTile;
    private Material startMaterial;
    public GameObject turretObj;
    // Start is called before the first frame update
    void Start()
    {
        bm = BuildManager.instance;
        mesh = GetComponent<MeshRenderer>();
        startMaterial = mesh.material;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 마우스가 오브젝트에 들어왔을 때 호출
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("UI 요소 위를 클릭했습니다.");
            return;
        }
        if (bm.CannotBuild)
        {
            return;
        }

        mesh.enabled = true;
        mesh.material = hoverMaterial;

        if (turretBlueprint.cost > PlayerStats.Money)
        {
            hoverMaterial.color = Color.red;
        }
        else
        {
            hoverMaterial.color = Color.white;
        }
    }

    // 마우스가 오브젝트에서 나갔을 때 호출
    void OnMouseExit()
    {
        mesh.enabled = false;
        mesh.material = startMaterial;
    }

    // 마우스 클릭 시 호출
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("UI 요소 위를 클릭했습니다.");
            return;
        }

        if (turretObj != null)
        {
            bm.SetTile(gameObject);
            //bm.SetTurretToBuild(turretBlueprint);

            return;
        }

        BuildTurret();
    }

    private void BuildTurret()
    {
        turretBlueprint = bm.GetTurretToBuild();
        if (turretBlueprint == null)
        {
            Debug.Log("터렛을 설치하지 못했습니다.!!");
            return;
        };
        if (PlayerStats.UseMoney(turretBlueprint.cost) == true)
        {
            turretObj = Instantiate(turretBlueprint.turretPrefab, transform.position, Quaternion.identity);
            GameObject _createEffect = Instantiate(createEffect, GetTurretBuildPosition(turretBlueprint.offset), Quaternion.identity);
            Destroy(_createEffect, 2f);
            Debug.Log($"건설하고 남은돈: {PlayerStats.Money}");
        }
    }
    public void UpgradeTurret()
    {
        if(turretBlueprint == null)
        {
            Debug.Log("Upgrade ERR");
            return;
        }

        if (PlayerStats.UseMoney(turretBlueprint.upgradeCost) == true)
        {
            Destroy(turretObj);
            turretObj = Instantiate(turretBlueprint.upgradeTurretPrefab, transform.position, Quaternion.identity);
            upgradeStep++;

            GameObject _createEffect = Instantiate(createEffect, GetTurretBuildPosition(turretBlueprint.offset), Quaternion.identity);
            Destroy(_createEffect, 2f);
        }
    }

    public void SellTurret()
    {
        float sellMoney = turretBlueprint.GetSellCost();
        Destroy(turretObj);
        GameObject _createEffect = Instantiate(destroyEffect, GetTurretBuildPosition(turretBlueprint.offset), Quaternion.identity);
        turretObj = null;
        turretBlueprint = null;
        upgradeStep = 1;
        PlayerStats.AddMoney(sellMoney);
        Destroy(_createEffect, 2f);
    }

    private Vector3 GetTurretBuildPosition(Vector3 offset)
    {
        return transform.position + offset;
    }
}
