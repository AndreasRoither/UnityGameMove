using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 100;

    private bool moveLeft = false;
    private bool moveRight = false;

    public float startDelayTime = 0.5f;

    private bool shouldMove = false;

    private void Start()
    {
        Invoke("SetMoveInvoke", startDelayTime);
    }

    // Fixed Update for physics
    private void FixedUpdate () {
        if (!shouldMove)
            return;
   
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

        // check position below ground
        if (rb.position.y < -0.5f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void Update()
    {
        if (!shouldMove)
            return;

        // check for input
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
            moveRight = true;

        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
            moveLeft = true;
    }

    // workaround for invoke
    public void SetMoveInvoke()
    {
        SetShouldMove(true);
    }

    public void SetShouldMove(bool setTo)
    {
        shouldMove = setTo;
    }
}
