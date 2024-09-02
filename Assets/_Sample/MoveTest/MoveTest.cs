using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    Vector3 targetPosition = new Vector3(7.0f, 1.5f, 8.0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(targetPosition * Time.deltaTime);
        this.transform.position += (targetPosition - this.transform.position).normalized * Time.deltaTime;
    }
}
