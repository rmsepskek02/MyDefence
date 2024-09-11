using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    private BuildManager bm;
    public TurretBlueprint basicTurret;
    public TurretBlueprint missileLauncher;
    public TestChild test;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bm = BuildManager.instance;
    }
    public void OnClickTurret()
    {
        Debug.Log("SELECT TURRET");
        bm.SetTurretToBuild(basicTurret);
    }
    public void OnClickMissileLauncher()
    {
        Debug.Log("SELECT ANOTHER TURRET");
        bm.SetTurretToBuild(missileLauncher);
    }
}
