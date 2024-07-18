using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class nextlevelmanager 
{
    // Start is called before the first frame update
    private string lvl1 = "animationpractice", lvl2 = "despairshooterlvl2", lvl3 = "despairshooterlvl3alt";
    private static nextlevelmanager sharedInstance = null;
    public static nextlevelmanager Instance
    {
        get
        {
            return sharedInstance;
        }
    }
    public static void Initialize()
    {
        if (sharedInstance == null)
        {
            sharedInstance = new nextlevelmanager();
        }

    }
    public void loadlevel(int lvler)
    {
        if (lvler == 1)
        {
            SceneManager.LoadScene(lvl1);
        }
        else if (lvler == 2)
        {
            SceneManager.LoadScene(lvl2);
        }
        else if (lvler == 3)
        {
            SceneManager.LoadScene(lvl3);
        }

    }
    public void main_menu_return() {
        SceneManager.LoadScene("despairshooterstartscreen");
    }
    public void close_game() {
        Debug.Log("Closing game");
        Application.Quit();
    }
    public void sane(int num)
    {
        Debug.Log("Sake " + num);
    }
}
