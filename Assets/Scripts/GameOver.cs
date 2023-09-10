using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
  

    // Start is called before the first frame update
  

    public void RestarTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
    public void mainmenue()
    {
        SceneManager.LoadScene("MainMenue");
    }
}

