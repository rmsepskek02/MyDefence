using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private TurretBlueprint turretToBuild;
    
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

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
    public TurretBlueprint SetTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        return turretToBuild;
    }


}
