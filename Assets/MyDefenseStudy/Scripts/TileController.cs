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
    
    private TurretBlueprint turretBlueprint;
    private Material startMaterial;
    private GameObject turretObj;
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
        turretBlueprint = bm.GetTurretToBuild();
        if (turretBlueprint == null) return;

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
            // 켜져있음
            if (TileUI.tileUI.activeSelf)
            {
                // 다른타일임
                if (TileUI.mapTile != gameObject)
                {
                    TileUI.tileUI.transform.position = transform.position + new Vector3(0, 2f, 1f);
                }
                // 같은타일임
                else
                {
                    TileUI.tileUI.SetActive(false);
                }
            }
            // 꺼져있음
            else
            {
                TileUI.tileUI.SetActive(true);
                TileUI.tileUI.transform.position = transform.position + new Vector3(0, 2f, 1f);
            }
            
            return;
        }

        turretBlueprint = bm.GetTurretToBuild();
        if (turretBlueprint == null)
        {
            Debug.Log("터렛을 설치하지 못했습니다.!!");
            return;
        };

        if (PlayerStats.UseMoney(turretBlueprint.cost) == true)
        {
            turretObj = Instantiate(turretBlueprint.turretPrefab, transform.position, Quaternion.identity);
            GameObject _createEffect = Instantiate(createEffect, transform.position, Quaternion.identity);
            Destroy(_createEffect, 2f);
            Debug.Log($"건설하고 남은돈: {PlayerStats.Money}");
        }
    }
}
