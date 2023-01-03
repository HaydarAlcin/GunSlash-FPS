using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    private void Start()
    {
        GetComponent<AudioSource>().Play();
    }
    public void StartButton() {

        SceneManager.LoadScene("MainLevel");
   }

    public void RestartButton()
    {

        SceneManager.LoadScene("MainLevel");
    }

    public void HomeButton()
    {

        SceneManager.LoadScene("MainMenu");
    }
}
