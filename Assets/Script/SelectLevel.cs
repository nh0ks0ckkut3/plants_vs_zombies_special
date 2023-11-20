using UnityEngine.SceneManagement;
using UnityEngine;

public class SelectLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public int targetSceneName;
    public void SwitchScene()
    {
        switch (targetSceneName)
        {
            default:
            case 1:
                SceneManager.LoadScene("level_day_roof");
                break;
            case 2:
                SceneManager.LoadScene("level_night_roof");
                break;
            case 3:
                SceneManager.LoadScene("level_ice");
                break;
            case 4:
                SceneManager.LoadScene("level_night_pool");
                break;
            
        }
        
    }
}
