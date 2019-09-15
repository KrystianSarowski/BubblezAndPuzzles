using UnityEngine;
using UnityEngine.SceneManagement;
//@Author Krystian Sarowski

public class MenuManager : MonoBehaviour
{
    void Start()
    {
        //When the screen launches make the cursor visible.
        Cursor.visible = true;    
    }

    public void PlayGame()
    {
        //Start the next scene which should be level 1.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayClickSound()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
