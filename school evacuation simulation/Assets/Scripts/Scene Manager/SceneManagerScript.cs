using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public string sceneName;

    void Start(){
      Cursor.lockState=CursorLockMode.None;
    }
    public void StartGame(string sceneName){
      Time.timeScale = 1;
		  SceneManager.LoadScene(sceneName);
    }
    public static void StaticStartGame(string name){
      Time.timeScale = 1;
		  SceneManager.LoadScene(name);
    }
    public void QuitGame(){
      Time.timeScale = 1;
      Application.Quit();
    }
}
