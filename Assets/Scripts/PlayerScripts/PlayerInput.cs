using UnityEngine;
//@Author Krystian Sarowski

public class PlayerInput : MonoBehaviour
{
    //Instance of the player controller script
    private PlayerController m_playerController;

    //Start is called before the first frame update
    void Start()
    {
       m_playerController = GetComponent<PlayerController>();
    }

    //Update is called once per frame
    void Update()
    {
        //If the game is not paused check for player controller related input.
        if(!GameManger.m_gameIsPaused)
        {
            //Take in for which direction the player wants to accelrate.
            float moveOnX = Input.GetAxisRaw("Horizontal");
            float moveOnZ = Input.GetAxisRaw("Vertical");

            //Calcualtion for the horizontal and vertical component of acceleration.
            Vector3 horizComponent = transform.right * moveOnX;
            Vector3 vertComponent = transform.forward * moveOnZ;

            //Calculate the unit acceleration using the components
            Vector3 unitAccel = (horizComponent + vertComponent).normalized;

            m_playerController.UpdateAcceleration(unitAccel);

            if (Input.GetKeyDown("space"))
            {
                m_playerController.Jump();
            }

            m_playerController.Rotate(Input.GetAxisRaw("Mouse X"));
        }
    }
}
