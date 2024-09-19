using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTest : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 70.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveForward()
    {
        Vector3 localForce = transform.TransformDirection(Vector3.forward);
        rb.AddForce(localForce * force, ForceMode.Impulse);
    }
}
