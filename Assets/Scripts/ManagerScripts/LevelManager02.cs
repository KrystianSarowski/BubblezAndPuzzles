using UnityEngine;
//@Author Krystian Sarowski

public class LevelManager02 : MonoBehaviour
{
    public PlayerGrowth m_sizeInfo;

    public Rigidbody m_rbCaveObstacle;
    public Rigidbody m_rbButton;

    public MovingPlatform m_elevator;

    bool m_caveLocked = true;
    bool m_buttonLocked = true;

    //Start is called before the first frame update
    void Start()
    {
        m_rbCaveObstacle.constraints = RigidbodyConstraints.FreezeAll;
        m_rbButton.constraints = RigidbodyConstraints.FreezeAll;

        m_elevator.SetActive(false);
    }

    //Update is called once per frame
    void Update()
    {
        if(m_sizeInfo.GetFoodCollected() == 4 )
        {
            if(m_caveLocked == true)
            {
                m_rbCaveObstacle.constraints = RigidbodyConstraints.FreezeRotationY | 
                    RigidbodyConstraints.FreezeRotationZ | 
                    RigidbodyConstraints.FreezePositionX;
                m_caveLocked = false;
            }
        }

        if (m_sizeInfo.GetFoodCollected() == 10)
        {
            if (m_buttonLocked == true)
            {
                m_rbButton.constraints = RigidbodyConstraints.FreezeRotation;
                m_buttonLocked = false;
            }
        }

        if(m_rbButton.position.y <= 2.55)
        {
            m_elevator.SetActive(true);
        }
    }
}
