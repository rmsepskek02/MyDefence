using UnityEngine;

namespace SampleStudy
{
    public enum MonsterType
    {
        M_Silme,
        M_Zombie,
        M_Goblin,
    }

    public abstract class Monster
    {
        // 몬스터의 공통기능 정의
        public abstract void Attack();

    }

    public class Slime : Monster
    {
        public int hp;
        public override void Attack()
        {
            Debug.Log("Attack Slime");
        }
    }

    public class Zombie : Monster
    {
        public override void Attack()
        {
            Debug.Log("Attack Zombie");
        }
    }

    public class Goblin : Monster
    {
        public override void Attack()
        {
            Debug.Log("Attack Goblin");
        }
    }
}