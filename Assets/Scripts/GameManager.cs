using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private SceneButton sceneButton;
    private Health health; 
    public string nextLevel; // Add variables at the top of your scripts


    private void Start()
    {
        sceneButton = GameObject.Find("GameManager").GetComponent<SceneButton>();
        health = GameObject.Find("Player").GetComponent<Health>();
    }
    private void Update()
    {
        if(health.currentHealth <= 0)
        {
            sceneButton.Invoke("ReloadLevel", 2);
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            sceneButton.ReloadLevel();
        }
    
    }
   
    public void EndGame()
    {
        SceneManager.LoadScene(nextLevel);
    }

}
