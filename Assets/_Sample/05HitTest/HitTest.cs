using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTest : MonoBehaviour
{
    private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private bool CheckPassPosition(Transform target)
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (moveSpeed * Time.deltaTime <= distance)
            return false;
        else
            return true;
    }
}
