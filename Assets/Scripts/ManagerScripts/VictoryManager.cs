using UnityEngine;
using UnityEngine.SceneManagement;
//@Author Krystian Sarowski

public class VictoryManager : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true; 
    }

    public void ReturnToMainMenu()
    {
        Debug.Log("Game has closed");
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void PlayClickSound()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
    }
}
