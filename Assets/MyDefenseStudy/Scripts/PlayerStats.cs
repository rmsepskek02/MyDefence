using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class PlayerStats : MonoBehaviour
{
    #region
    private static float money;
    public static float Money
    {
        get { return money; }
    }
    [SerializeField] private float startMoney = 400;

    private static int life;
    public static int Life
    {
        get { return life; }
    }
    [SerializeField] private int startLife = 10;
    private static int round;
    public static int Round
    {
        get { return round; }
    }
    [SerializeField] private int startRound = 0;
    private static int wave;
    public static int Wave
    {
        get { return wave; }
    }
    [SerializeField] private int startWave = 0;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        money = startMoney;
        life = startLife;
        round = startRound;
        wave = startWave;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static bool UseMoney(float cost)
    {
        if (money >= cost)
        {
            money -= cost;
            return true;
        }
        return false;
    }
    public static void AddMoney(float cost)
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
    public static void IncreaseRound()
    {
        round++;
    }
    public static void SetWave(int _wave)
    {
        wave += _wave;
    }
    public static void DecreaseWave()
    {
        wave--;
    }
}
