using UnityEngine;
//@Author Krystian Sarowski

public class PlayerCollision : MonoBehaviour
{

    private void OnTriggerEnter(Collider t_triggerInfo)
    {
        if (t_triggerInfo.tag == "Food")
        {
            GetComponent<PlayerGrowth>().Grow();
            FindObjectOfType<AudioManager>().Play("NomSound");
            Destroy(t_triggerInfo.gameObject);
        }

        else if(t_triggerInfo.tag == "EndPoint")
        {
            FindObjectOfType<GameManger>().CompleteLevel();
        }
    }
}
