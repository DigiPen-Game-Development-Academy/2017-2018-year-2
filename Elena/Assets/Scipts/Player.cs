using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    new Rigidbody rigidbody;
    public Transform Enemy;
    
    public float acceleration = 3;
    public float speed = 2;
    public float turnSpeed = 3;
    public float FireRate = 0.1f;
    public GameObject projectile;

    float secondsTillFire = 0;

    int type = 1;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Enemy = FindObjectOfType<Enemy>().transform; 

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) input.z += -1;
        if (Input.GetKey(KeyCode.A)) input.x += 1;
        if (Input.GetKey(KeyCode.S)) input.z += 1;
        if (Input.GetKey(KeyCode.D)) input.x += -1;

        input = transform.TransformDirection(input * speed);

        Vector3 velocity = new Vector3(input.x, rigidbody.velocity.y, input.z);

        rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, velocity, acceleration * Time.deltaTime);

        rigidbody.maxAngularVelocity = 0;

        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * turnSpeed);

        secondsTillFire -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Alpha1))
        {
            type = 1;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            type = 2;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            type = 3;
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            type = 4;
        }
        if (Input.GetMouseButton(0) && secondsTillFire <= 0)
        {
            secondsTillFire = FireRate;
            if (type == 1)
            {
                Shoot(transform.position, -transform.forward);
            }
            if (type == 2)
            {
                Shoot(transform.position, -transform.forward);
                Shoot(transform.position, transform.forward);
            }
            if (type == 3)
            {
                Shoot(transform.position, -transform.right);
                Shoot(transform.position, transform.right);
            }
            if (type == 4)
            {
                Shoot(transform.position, -transform.forward);
                Shoot(transform.position, transform.forward);
                Shoot(transform.position, -transform.right);
                Shoot(transform.position, transform.right);
            }
        }
    }
    GameObject Shoot(Vector3 position, Vector3 direction)
    {
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, direction);

            GameObject created = Instantiate(projectile, position + direction * 2, rotation);

            created.GetComponent<Projectile>().direction = direction;
        
        return gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(this);
        }
    }
}