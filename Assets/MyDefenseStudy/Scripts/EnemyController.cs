using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Damagable
{
    public GameObject destroyEffect;
    [SerializeField] private float hp;
    public float startHp;
    [SerializeField] 
    private int rewardGold;
    // Start is called before the first frame update
    void Start()
    {
        hp = startHp;
    }
    // Update is called once per frame
    void Update()
    {
        Die();
    }

    public void TakeDamaged(float damage)
    {
        hp -= damage;
    }
    void Die()
    {
        if (hp <= 0)
        {
            PlayerStats.AddMoney(rewardGold);
            GameObject _destroyEffect = Instantiate(destroyEffect, transform.position, Quaternion.Euler(-90f, 0f, 0f));

            Destroy(_destroyEffect, 2f);
            Destroy(gameObject);
        }
    }

    public override void TakeDamage(float damage)
    {
        hp -= damage;
    }
    private void OnDestroy()
    {
        PlayerStats.DecreaseWave();
    }
}
