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

    // ���콺�� ������Ʈ�� ������ �� ȣ��
    void OnMouseEnter()
    {
        mesh.material = hoverMaterial;
    }

    // ���콺�� ������Ʈ���� ������ �� ȣ��
    void OnMouseExit()
    {
        mesh.material = startMaterial;
    }

    // ���콺 Ŭ�� �� ȣ��
    void OnMouseDown()
    {
        if (turretObj != null) return;
        turretObj = Instantiate(bm.turret, transform.position, Quaternion.identity);
    }
}
