using UnityEngine;
//@Author Krystian Sarowski

public class LevelManager03 : MonoBehaviour
{
    public Rigidbody m_rbPlank;         //Rigidbody of the plank used to reach the button.
    public Rigidbody m_rbButton;        //Rigidbody of the button that enables block01.
    public Rigidbody m_rbStepBlock02;   //Rigidbody of the medium step block.
    public Rigidbody m_rbStepBlock03;   //Rigidbody of the large step block.

    public GameObject m_stepBlock01;    //The small step block.

    public PlayerGrowth m_sizeInfo;     //Player growth script used to check the number of food collected.

    bool m_stepBlocked01 = true;        
    bool m_stepBlocked02 = true;
    bool m_stepBlocked03 = true;
    bool m_bridgeLocked = true;

    //Start is called before the first frame update
    void Start()
    {
        //Lock the movemnt of these objects so that the player can not interact.
        m_rbPlank.constraints = RigidbodyConstraints.FreezeAll;
        m_rbStepBlock02.constraints = RigidbodyConstraints.FreezeAll;
        m_rbStepBlock03.constraints = RigidbodyConstraints.FreezeAll;

        m_stepBlock01.SetActive(false);
    }

    //Update is called once per frame
    void Update()
    {
        //Check if the button is pressed.
        if (m_rbButton.position.y <= 2.1f)
        {
            if (m_stepBlocked01 == true)
            {
                //Unlock the small block for the player by seting it active in the scene.
                m_stepBlock01.SetActive(true);
                m_stepBlocked01 = false;
            }
        }

        if (m_sizeInfo.GetFoodCollected() == 8)
        {
            if (m_stepBlocked02 == true)
            {
                //Unlocks the medium block with frozen rotation to make it easier to push around.
                m_rbStepBlock02.constraints = RigidbodyConstraints.FreezeRotation;
                m_stepBlocked02 = false;
            }
        }

        if (m_sizeInfo.GetFoodCollected() == 14)
        {
            if (m_bridgeLocked == true)
            {
                //Unlocks the plank to the player with limited movement so it does not fall of the map.
                m_rbPlank.constraints = RigidbodyConstraints.FreezePositionZ |
                    RigidbodyConstraints.FreezeRotationX |
                    RigidbodyConstraints.FreezeRotationY;
                m_bridgeLocked = false;
            }
        }

        if (m_sizeInfo.GetFoodCollected() == 15)
        {
            if (m_stepBlocked03 == true)
            {
                //Unlocks the large block with frozen rotation to make it easier to push around.
                m_rbStepBlock03.constraints = RigidbodyConstraints.FreezeRotation;
                m_stepBlocked03 = false;
            }
        }
    }
}
