using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public Camera mouseCamera;
    new Rigidbody rigidbody;

    //fine tuning variables
    public float acceleration = 3;
    public float speed = 2;
    public float turnSpeed = 3;
    public float fireRate = 0.1f;
    public GameObject projectile;
    public enum ShotPattern
    {
        Forward,
        Vertical,
        Horizontal,
        Diagonal,
        COUNT
    }
    public ShotPattern shotPattern;

    //non editable variables
    float secondsTillFire = 0;

	// Use this for initialization
	void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //create a storage variable for input
        Vector3 input = Vector3.zero;

        //gather the input from the keyboard
        if (Input.GetKey(KeyCode.W)) input.z += 1;
        if (Input.GetKey(KeyCode.A)) input.x += -1;
        if (Input.GetKey(KeyCode.S)) input.z += -1;
        if (Input.GetKey(KeyCode.D)) input.x += 1;

        //convert the input to world coordinates
        //so that the player moves in the direction they are facing
        //instead of on the cardinal world directions (x and z)
        input = transform.TransformDirection(input) * speed;

        //combine the norizontal input velocity with the vertical velocity we have
        Vector3 velocity = new Vector3(input.x, rigidbody.velocity.y, input.z);

        //apply the velocity to the player
        rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, velocity, acceleration * Time.deltaTime);

        //disallow the player from getting spun by physics
        rigidbody.maxAngularVelocity = 0;

        //rotate the player using the mouse input instead of physics
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * turnSpeed);

        //count down till we can fire
        secondsTillFire -= Time.deltaTime;
        //check for input and cooldown
        if ((Input.GetMouseButton(0) || Input.GetMouseButton(1)) && secondsTillFire <= 0)
        {
            //reset the countdown
            secondsTillFire = fireRate;

            //create the projectile
            //GameObject created = Instantiate(projectile, transform.position + transform.forward * 2, transform.rotation * Quaternion.Euler(90, 0, 0));

            //launch the projectile
            Vector3 target = Input.mousePosition;
            target.z = mouseCamera.transform.position.y;
            target = mouseCamera.ScreenToWorldPoint(target);
            Shoot(transform.position, (target - transform.position).normalized);
        }
    }
    GameObject Shoot(Vector3 Pos, Vector3 dir)
    {
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, dir);

        GameObject created = Instantiate(projectile, Pos + dir * 2, rot);

        created.GetComponent<Projectile>().direction = dir;

        return gameObject;
    }
}