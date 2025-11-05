using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Health health;
    public bool isAlive { get; private set; } = true;


    private void Awake()
    {
            health = GameObject.Find("Player").GetComponent<Health>();
    }
    private void Update()
    {
        if(health.currentHealth <= 0)
        {
            isAlive = false;
            Invoke("ReloadLevel", 2);
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            ReloadLevel();
        }
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void EndGame()
    {
        //exit game logic here
    }
    public void Quit()
    {
        Application.Quit();
    }

}
