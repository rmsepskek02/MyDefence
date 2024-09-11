using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public interface IStats
    {
        public int Strength { get; set; }
        public int Dexterrty { get; set; }
        public int Endurance { get; set; }
    }
}
