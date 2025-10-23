using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Health health; 
    public string nextLevel; // Add variables at the top of your scripts


    private void Awake()
    {
            health = GameObject.Find("Player").GetComponent<Health>();
    }
    private void Update()
    {
        if(health.currentHealth <= 0)
        {
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

    public void EndGame()
    {
        StartScene(nextLevel);
    }
    public void Quit()
    {
        Application.Quit();
    }

}
