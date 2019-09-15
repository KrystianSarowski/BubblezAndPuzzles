using UnityEngine;
//@Author Krystian Sarowski

public class PlayerGrowth : MonoBehaviour
{
    //Amount by which the size and scale of player changes everytime he grows.
    const float m_GROWTH_FACTOR = 0.25f;

    //The total amount of food that has been collected by the player this level.
    float m_foodCollected = 0;

    //The rigidbody of the player.
    Rigidbody m_rb;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    public void Grow()
    {
        //Change the scale of the player to new scale;
        Vector3 newScale = m_rb.transform.localScale + Vector3.one * m_GROWTH_FACTOR;

        m_rb.transform.localScale = newScale;

        //Increase the mass of the player.
        m_rb.mass = m_rb.mass + m_GROWTH_FACTOR;

        //Adjust the offset on the main camera.
        Camera.main.GetComponent<FollowTarget>().AdjustOffset();

        //Increase the amount of doof that has been colected.
        m_foodCollected++;
    }

    public float GetFoodCollected()
    {
        return m_foodCollected;
    }
}
