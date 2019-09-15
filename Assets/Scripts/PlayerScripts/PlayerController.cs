using UnityEngine;
//@Author Krystian Sarowski

public class PlayerController : MonoBehaviour
{
    public float m_acceleration = 15.0f;     //The size of the acceleration added when the player moves.    
    public float m_mouseSensitivity = 2.0f;  //The sensitivity of the player rotation when mouse is moved.

    const float m_JUMP_FORCE = 10.0f;        //Upward force that is applied when the player jumps.
    const float m_MAX_SPEED = 10.0f;         //The maximum size of the velocity's magnitude.
    const float m_LOWEST_Y_POS = -100.0f;    //The lowest point which the player can reach before being outside of the map.

    float m_totalBodyRotation;               //The total rotation that is aplied to player transform.

    bool m_isMovementEnabled = true;         //Used to check if the player can move around.

    public LayerMask m_groundLayer;          //Layer from which the player stands on and can jump from.

    public Vector3 m_respawnPoint;           //The position at which the player respawns if he falls out of the map.
    Vector3 m_accelVect = Vector3.zero;      //The accleration vector that is applied to player's velocity.

    Rigidbody m_rb;                          //Rigidbody of the player.       
    Camera m_camera;                         //Camera that follows the player around.

    Vector2 m_groundVelocity;                //The x and z component of player's velocity.

    SphereCollider m_col;                    //Player's collider.

    // Start is called before the first frame update
    void Start()
    {
        m_camera = Camera.main;
        m_rb = GetComponent<Rigidbody>();
        m_col = GetComponent<SphereCollider>();

    }

    public void Rotate(float t_rotation)
    {
        m_totalBodyRotation += m_mouseSensitivity * t_rotation;
        m_rb.transform.eulerAngles = new Vector3(0, m_totalBodyRotation, 0.0f);
    }

    //Applies an upward force to the player if he is on the ground
    public void Jump()
    {
        if (IsGrounded() == true)
        {
            FindObjectOfType<AudioManager>().Play("JumpSound");
            m_rb.AddForce(Vector3.up * m_JUMP_FORCE, ForceMode.VelocityChange);
        }
    }

    //Creates a movement vector using the unit velocity and the speed
    public void UpdateAcceleration(Vector3 t_unitVel)
    {
        m_accelVect = t_unitVel * m_acceleration;
    }

    //Perform movement based on velocity variable
    void PerformMovement()
    {
        if (m_accelVect != Vector3.zero)
        {
            m_rb.velocity += m_accelVect * Time.fixedDeltaTime;
        }
    }

    void FixedUpdate()
    {
        if(m_isMovementEnabled)
        {
            PerformMovement();
            CapVelocity();
        }

        else
        {
            if(IsGrounded())
            {
                m_isMovementEnabled = true;
            }
        }

        if (m_rb.position.y < m_LOWEST_Y_POS)
        {
            Respawn();
        }

    }

    //Check if the horizontal combined x and z velocity has exceeded the maximum speed.
    void CapVelocity()
    {
        m_groundVelocity = new Vector2(m_rb.velocity.x, m_rb.velocity.z);

        if (m_groundVelocity.magnitude > m_MAX_SPEED)
        {
            m_groundVelocity.Normalize();
            m_groundVelocity *= m_MAX_SPEED;

            m_rb.velocity = new Vector3(m_groundVelocity.x, m_rb.velocity.y, m_groundVelocity.y);
        }
    }

    //Respawn the player at respawn position and disable their movemnt until the player hits the ground.
    void Respawn()
    {
        transform.position = m_respawnPoint;
        m_rb.velocity = Vector3.up * m_rb.velocity.y;
        m_isMovementEnabled = false;
    }

    //Check if the player is colldinging with the ground.
    bool IsGrounded()
    {
        return Physics.CheckCapsule(m_col.bounds.center, new Vector3(m_col.bounds.center.x, m_col.bounds.min.y, m_col.bounds.center.z), m_col.radius * 0.9f, m_groundLayer);
    }

}
