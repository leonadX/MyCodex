using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject bullet;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), transform.rotation);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x > 2.5f)
            transform.position = new Vector3(2.5f,transform.position.y, transform.position.z);
        else if(transform.position.x < -2.5f)
            transform.position = new Vector3(-2.5f, transform.position.y, transform.position.z);

        if (Input.GetKey("a") && transform.position.x > -2.5f)
            rb.AddForce(-speed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        else if (Input.GetKey("d") && transform.position.x < 2.5f)
            rb.AddForce(speed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }
}
