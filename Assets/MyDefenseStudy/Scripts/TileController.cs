using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        mesh.material = hoverMaterial;
    }

    // 마우스가 오브젝트에서 나갔을 때 호출
    void OnMouseExit()
    {
        mesh.material = startMaterial;
    }

    // 마우스 클릭 시 호출
    void OnMouseDown()
    {
        if (turretObj != null) return;
        turretObj = Instantiate(bm.turret, transform.position, Quaternion.identity);
    }
}
