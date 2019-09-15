using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//@Author Krystian Sarowski

public class MovingPlatform : MonoBehaviour
{
    public Vector3 m_posOne;            //The First position vetctor of the platform.
    public Vector3 m_posTwo;            //The Second position vector of the platform.
    private Vector3 m_velocity;         //The velocity vector used by the platform to move between positions.

    public float m_maxWaitTime;         //The maximum time the platform will not move for between journeys
    public float m_speed;               //The speed at which the platform moves. 
    private float m_waitTime;           //Time left until the platfrom starts moving again.

    //Is the platfrom active. If no it will not move at all.
    public bool m_isActive;
    //Is the player standing on the platfrom. If yes he is moving then with the platform.
    private bool m_isPlayerAttached = false;    
    //Is it the frist frame of the the move cycle. If yes the distance check will be ignored.
    private bool m_firstFrame = true;

    private GameObject m_player;        //The player object.

    //Start is called before the first frame update
    void Start()
    {
        //Find the player object within the scene and store it.
        m_player = GameObject.FindGameObjectWithTag("Player");

        //Create the unit velocity vector for the platform and multiply it by speed.
        m_velocity = (m_posTwo - m_posOne).normalized * m_speed;

        //Move the the platform to the first position so our velocity is correct.
        transform.position = m_posOne;

        m_waitTime = m_maxWaitTime;
    }

    //Update is called once per frame
    void FixedUpdate()
    {
        if(m_isActive)
        {
            if (m_waitTime >= 0.0f)
            {
                m_waitTime -= Time.fixedDeltaTime;

            }

            else
            {
                PreformMovement();
                CheckForDestination();
            }
        }

    }

    public void SetActive(bool t_active)
    {
        m_isActive = t_active;
    }

    void CheckForDestination()
    {
        //Check if our speed is greater than either of the two positions.
        if ((m_speed >= Vector3.Distance(transform.position, m_posOne)) || (m_speed >= Vector3.Distance(transform.position, m_posTwo)))
        {
            if (m_firstFrame)
            {
                m_firstFrame = false;
            }

            else
            {
                m_velocity = -m_velocity;
                m_waitTime = m_maxWaitTime;
                m_firstFrame = true;
            }
        }
    }

    void PreformMovement()
    {
        transform.position += m_velocity;

        if (m_isPlayerAttached)
        {
            m_player.transform.position += m_velocity;
        }
    }

    void OnTriggerEnter(Collider t_colliderInfo)
    {
        if(t_colliderInfo.gameObject == m_player)
        {
            m_isPlayerAttached = true;
        }
    }

    void OnTriggerExit(Collider t_colliderInfo)
    {
        if (t_colliderInfo.gameObject == m_player)
        {
            m_isPlayerAttached = false;
        }
    }
}
