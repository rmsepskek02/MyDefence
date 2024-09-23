using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject turretPrefab;
    public int cost;
    public int atk;
    public GameObject upgradeTurretPrefab;
    public int upgradeCost;
    public int upgradeAtk;
    public Vector3 offset;
}
