using UnityEngine;
using UnityEngine.SceneManagement;
//@Author Krystian Sarowski

public class GameManger : MonoBehaviour
{
    //Used to check if the game is currently paused.
    public static bool m_gameIsPaused = false;

    //Pause menu object.
    public GameObject m_pauseMenuUI;

    void Start()
    {
        Resume();
    }

    void Update()
    {
        if(!m_gameIsPaused)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Restart();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (m_gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    //Pauses the game by stoping the time.
    void Pause()
    {
        Cursor.visible = true;
        m_pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        m_gameIsPaused = true;
    }

    //Play the click sound for a UI button.
    public void PlayUIClickSound()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
    }

    //Unpauses the game by starting the time again.
    public void Resume()
    {
        Cursor.visible = false;
        m_pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        m_gameIsPaused = false;
    }

    //Restarts the current level.
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Loads the next scene/level that is in the queue.
    public void CompleteLevel()
    {
        Debug.Log("Level Completed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Returns to the games main menu.
    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
