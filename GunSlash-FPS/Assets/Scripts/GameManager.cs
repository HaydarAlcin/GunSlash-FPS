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

        SceneManager.LoadScene(1);
   }

    public void RestartButton()
    {

        SceneManager.LoadScene(1);
    }

    public void HomeButton()
    {

        SceneManager.LoadScene(0);
    }
}
