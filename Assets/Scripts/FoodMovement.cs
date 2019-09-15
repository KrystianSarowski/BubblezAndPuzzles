using UnityEngine;
//@Author Krystian Sarowski

public class FoodMovement : MonoBehaviour
{
    public float m_maxHoverTime = 1.0f;     //Total time the food moves in one direction for.
    float m_hoverTime = 0;                  //Curent time for which the food has been moving in one direction.
    float m_hoverVel = 0.01f;               //Vertical hover velocity.

    //Vector that is applied to the food rotation every frame.
    public Vector3 m_rotationVect = new Vector3(1.0f, 0.5f, 0.75f);

    //Update is called once per frame
    void FixedUpdate()
    {
        m_hoverTime += Time.fixedDeltaTime;

        if(m_hoverTime >= m_maxHoverTime)
        {
            m_hoverVel = -m_hoverVel;
            m_hoverTime = 0;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y + m_hoverVel, transform.position.z);
        transform.Rotate(m_rotationVect);
    }
}
