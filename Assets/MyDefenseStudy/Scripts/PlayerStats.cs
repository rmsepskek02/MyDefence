using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerStats : MonoBehaviour
{
    #region
    private static int money;
    public static int Money
    {
        get { return money; }
    }
    [SerializeField] private int startMoney = 400;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        money = startMoney;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static bool UseMoney(int cost)
    {
        if (money >= cost)
        {
            money -= cost;
            return true;
        }
        return false;
    }
}
