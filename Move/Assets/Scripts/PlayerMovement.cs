using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 100;

    private bool moveLeft = false;
    private bool moveRight = false;

    // Fixed Update for physics
	void FixedUpdate () {
        // even out frames per second on a better pc with deltaTime
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (moveRight)
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            moveRight = false;
        }
            
        if (moveLeft)
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            moveLeft = false;
        }    
    }

    void Update()
    {
        // check for input
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
            moveRight = true;

        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
            moveLeft = true;
    }
}
