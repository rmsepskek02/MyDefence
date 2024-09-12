using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SampleStudy
{

    public class FactoryTest : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            // 슬라임 생성 => 슬라임 공격
            // 좀비 생성 => 좀비 공격
            //Monster slime = CreateMonster(MonsterType.M_Silme);
            //slime.Attack();
            //Monster zombie = CreateMonster(MonsterType.M_Zombie);
            //zombie.Attack();

            //MonsterFactory monsterFactory = new MonsterFactory();
            //Monster slime = monsterFactory.CreateMonster(MonsterType.M_Silme);
            //slime.Attack();
            //Monster zombie = monsterFactory.CreateMonster(MonsterType.M_Zombie);
            //zombie.Attack();

            SlimeFactory slimeFactory = new SlimeFactory();
            Monster slime = slimeFactory.CreateMonster();
            List<Slime> _s = slimeFactory.Monsters;
            int a = _s[0].hp;
            slime.Attack();

            ZombieFactory zombieFactory = new ZombieFactory();
            Monster zombie = zombieFactory.CreateMonster();
            List<Zombie> _z = zombieFactory.Monsters;
            //int b = _z[0].
            zombieFactory.AddSomething();
            zombie.Attack();
        }

        // Update is called once per frame
        void Update()
        {

        }

        // 매개변수로 MonsterType을 받아서 타입에 맞게 몬스터를 생성하고 Monster를 반환하는 함수
        //private Monster CreateMonster(MonsterType mType)
        //{
        //    switch (mType)
        //    {
        //        case MonsterType.M_Silme:
        //            return new Slime();
        //        case MonsterType.M_Zombie:
        //            return new Zombie();
        //    }
        //    return null;
        //}
    }
}
