using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class CubeController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //������ �̵�
            //transform.Translate(Vector3.forward * Time.deltaTime);
        }

        // Update is called once per frame
        void Update()
        {
            //������ �̵�
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
    }
}