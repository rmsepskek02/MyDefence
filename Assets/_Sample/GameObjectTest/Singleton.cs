
using UnityEngine.UIElements;

namespace Sample
{
    namespace ObjectTest
    {
        public class Singleton
        {
            private static Singleton instance;

            //�Ӽ� - �б�����
            public static Singleton Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                    return instance;
                }
            }

            //�޼���
            /*public static Singleton Instance()
            {
                if(instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }*/
        }
    }
}