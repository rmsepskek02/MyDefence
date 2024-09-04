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

    // 마우스가 오브젝트에 들어왔을 때 호출
    void OnMouseEnter()
    {
        Debug.Log("마우스 엔터");
        mesh.material.color = Color.green;
    }

    // 마우스가 오브젝트에서 나갔을 때 호출
    void OnMouseExit()
    {
        Debug.Log("마우스 아웃");
        mesh.material.color = Color.white;
    }

    // 마우스 클릭 시 호출
    void OnMouseDown()
    {
        Debug.Log("마우스 클릭");
        Instantiate(bm.turret, transform.position, Quaternion.identity);
    }
}
