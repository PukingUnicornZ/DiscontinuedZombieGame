using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{

    public void LaadLevel(string level)
    {
        SceneManager.LoadScene(level);
        Fun.maxhealth = 100;
    }
    public void LaadLevel2(string level)
    {
        SceneManager.LoadScene(level);
        Fun.maxhealth = 50;
    }
    public void LaadLevel4(string level)
    {
        SceneManager.LoadScene(level);
        Fun.maxhealth = 30;
    }
    public static void LaadLevel3(string level)
    {
        SceneManager.LoadScene(level);
    }
    public void LaadLevel5(string level)
    {
        SceneManager.LoadScene(level);
    }
    public void StopSpel()
    {
        Application.Quit();
    }
}