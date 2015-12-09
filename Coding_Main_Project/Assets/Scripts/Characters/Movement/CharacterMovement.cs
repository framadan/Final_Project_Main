using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    Rigidbody rgbody;
    new Collider collider;
    public float gravity = -20f;

    public float movementSpeed = 0.0f;
    public float weight = 0.0f;
    public bool grounded = false;
    public int numberOfRays = 4;
    Vector3 targetVelocity = new Vector3();
    
    public Vector3 Velocity
    {
        get { return rgbody.velocity; } private set { rgbody.velocity = value; } 
    }

    public void Start()
    {
        rgbody = this.gameObject.GetComponent<Rigidbody>();
        this.collider = gameObject.GetComponent<Collider>();
    }

    public void FixedUpdate()
    {
        grounded = GroundCheck();
        if (grounded)
            Move();
        else
            Move(.3f);
        Debug.Log(Velocity);
    }

    public void Move(float percent = 1)
    {
        float direction = Input.GetAxis("Horizontal");
        targetVelocity.x = (direction * movementSpeed/ weight * 2f) * percent;

        if (grounded && Velocity.y <= 0) { targetVelocity = new Vector3(targetVelocity.x, 0); }
        else { targetVelocity.y += gravity * Time.deltaTime; }
        Velocity = Vector3.Lerp(Velocity, targetVelocity, (movementSpeed / weight) * Time.deltaTime);
        
    }

    public bool GroundCheck()
    {
        Bounds bounds = collider.bounds;
        bounds.Expand(0.03f * -1);
        Vector3 startPosition = new Vector3(bounds.min.x, bounds.min.y, bounds.min.z);
        float raySpacing = bounds.size.x / (numberOfRays - 1);

        for (int i = 0; i < numberOfRays; i++)
        {
            RaycastHit hit;
            Debug.DrawRay(startPosition + Vector3.right * raySpacing * i, Vector3.down * .1f, Color.red);
            if (Physics.Raycast(startPosition + Vector3.right * raySpacing * i, Vector3.down, out hit, 0.1f))
            {
                if (hit.collider.tag == "Ground")
                {
                    return true;
                }
            }
        }

        return false;
    }
}
