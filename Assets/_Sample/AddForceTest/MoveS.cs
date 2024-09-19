using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sample
{

    public class MoveS : MonoBehaviour
    {
        public Rigidbody rb;
        public float moveSpeed = 1.0f;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        }

    }
}
