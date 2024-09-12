using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    private static int life;
    public static int Life
    {
        get { return life; }
    }
    [SerializeField] private int startLife = 10;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        money = startMoney;
        life = startLife;
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
    public static void AddMoney(int cost)
    {
        money += cost;
    }

    public static void ReduceLife()
    {
        life--;
        if(life <= 0)
        {
            life = 0;
        }
    }
}
