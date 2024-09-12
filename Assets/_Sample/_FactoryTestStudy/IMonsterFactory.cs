using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SampleStudy
{
    public interface IMonsterFactory
    {
        public Monster CreateMonster(); // 팩토리 메서드
    }

    public abstract class MonstersFactory<T>
    {
        private List<T> monsters = new List<T>();
        public List<T> Monsters { get { return monsters; } }
        public abstract Monster CreateMonster();
    }


    public class SlimeFactory : MonstersFactory<Slime>
    {
        public int count = 0;
        
        public override Monster CreateMonster()
        {
            //Monsters.Add(new Slime());
            return new Slime();
        }
        public void SlimeCount() => count++;
    }

    public class ZombieFactory : MonstersFactory<Zombie>
    {
        public override Monster CreateMonster()
        {
            return new Zombie();
        }
        public void AddSomething()
        {
            Debug.Log("ADD SOMETHING");
        }
    }
    public class GoblinFactory : IMonsterFactory
    {
        public Monster CreateMonster()
        {
            return new Goblin();
        }
    }
}