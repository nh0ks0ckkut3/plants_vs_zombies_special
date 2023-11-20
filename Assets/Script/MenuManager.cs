using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private GameObject getObject_chooseplant;
    
    public void NewGame()
    {
        getObject_chooseplant = transform.parent.gameObject;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void CountinueGame()
    {
        getObject_chooseplant = transform.parent.gameObject;
        getObject_chooseplant.SetActive(false);
        Time.timeScale = 1;
    }
    public void Quit()
    {
        getObject_chooseplant = transform.parent.gameObject;
        getObject_chooseplant.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("Welcome");
    }
    public void showMenu()
    {
        getObject_chooseplant = transform.parent.gameObject.transform.Find("pannel_menu").gameObject;
        getObject_chooseplant.SetActive(true);
        Time.timeScale = 0;
    }
    
}
