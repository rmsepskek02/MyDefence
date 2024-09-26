using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpUI : MonoBehaviour
{
    public Image hpBar;
    EnemyController ec;
    // Start is called before the first frame update
    void Start()
    {
        ec = GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.fillAmount = ec.Hp / ec.startHp;
    }
}
