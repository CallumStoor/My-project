using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Image deathScreen;
    private Health health;
    public bool isAlive { get; private set; } = true;


    private void Awake()
    {
        if(GameObject.Find("DeathScreen") != null)
        {
            deathScreen = GameObject.Find("DeathScreen").GetComponent<Image>();
            deathScreen.gameObject.SetActive(false);
        }
        health = GameObject.Find("Player").GetComponent<Health>();
    }
    private void Update()
    {
        if(health.currentHealth <= 0)
        {
            isAlive = false;
            deathScreen.gameObject.SetActive(true);
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
