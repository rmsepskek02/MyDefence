using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sample
{
    namespace ObjectTest
    {
        public class Sigleton
        {
            private static Sigleton instance;

            // 필드
            public static Sigleton Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new Sigleton();
                    }
                    return instance;
                }
            }

            // 메서드
            //public static Sigleton Instance()
            //{
            //    if(instance == null)
            //    {
            //        instance = new Sigleton();
            //    }
            //    return instance;
            //}
        }
    }
}
