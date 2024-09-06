using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileController : MonoBehaviour
{
    MeshRenderer mesh;
    BuildManager bm;
    public Material hoverMaterial;
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
        if (bm.GetTurretToBuild() == null) return;
        mesh.enabled = true;
        mesh.material = hoverMaterial;
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
        if (turretObj != null) return;
        if (bm.GetTurretToBuild() == null)
        {
            Debug.Log("터렛을 설치하지 못했습니다.!!");
            return;
        };
        turretObj = Instantiate(bm.GetTurretToBuild(), transform.position, Quaternion.identity);
    }
}
