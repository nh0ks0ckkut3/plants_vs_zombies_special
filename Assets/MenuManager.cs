using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("NewGame");
    }
    public void CountinueGame()
    {
        SceneManager.LoadScene("Countinue");
    }
    public void Quit()
    {
        Application.Quit();
    }

    
}
