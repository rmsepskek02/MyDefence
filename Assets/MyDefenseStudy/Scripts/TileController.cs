using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    MeshRenderer mesh;
    BuildManager bm;
    // Start is called before the first frame update
    void Start()
    {
        bm = BuildManager.instance;
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ���콺�� ������Ʈ�� ������ �� ȣ��
    void OnMouseEnter()
    {
        Debug.Log("���콺 ����");
        mesh.material.color = Color.green;
    }

    // ���콺�� ������Ʈ���� ������ �� ȣ��
    void OnMouseExit()
    {
        Debug.Log("���콺 �ƿ�");
        mesh.material.color = Color.white;
    }

    // ���콺 Ŭ�� �� ȣ��
    void OnMouseDown()
    {
        Debug.Log("���콺 Ŭ��");
        Instantiate(bm.turret, transform.position, Quaternion.identity);
    }
}
