using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class PlayerMoveTest : MonoBehaviour
    {
        public GameObject target;
        public GameObject bulletPrefab;
        public GameObject firePoint;
        public float moveSpeed;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Move();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fire();
            }
        }
        void Move()
        {
            transform.LookAt(target.transform);
            if (Input.GetKey(KeyCode.W))
                transform.Translate(transform.forward * Time.deltaTime * moveSpeed, Space.World);
            if (Input.GetKey(KeyCode.S))
                transform.Translate(-transform.forward * Time.deltaTime * moveSpeed, Space.World);
            if (Input.GetKey(KeyCode.A))
                transform.Translate(-transform.right * Time.deltaTime * moveSpeed, Space.World);
            if (Input.GetKey(KeyCode.D))
                transform.Translate(transform.right * Time.deltaTime * moveSpeed, Space.World);
        }

        void Fire()
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
            BulletTest bulletTest = bullet.GetComponent<BulletTest>();
            if(bulletTest != null)
            {
                bulletTest.MoveForward();
            }
            Destroy(bullet, 3f);
        }
    }
}
