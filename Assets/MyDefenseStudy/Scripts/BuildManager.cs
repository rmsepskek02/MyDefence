using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private GameObject turretToBuild;
    public GameObject basicTurretPrefab;
    public GameObject AnotherTurretPrefab;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //turretToBuild = basicTurretPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void OnClickTurret()
    {
        Debug.Log("SELECT TURRET");
        turretToBuild = basicTurretPrefab;
    }
    public void OnClickAnotherTurret()
    {
        Debug.Log("SELECT ANOTHER TURRET");
        turretToBuild = AnotherTurretPrefab;
    }
}
