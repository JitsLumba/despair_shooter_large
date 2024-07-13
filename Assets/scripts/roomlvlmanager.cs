using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class roomlvlmanager
{
    private static roomlvlmanager sharedInstance = null;
    public roomlvlmanager()
    {

    }
    public static roomlvlmanager Instance
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
            sharedInstance = new roomlvlmanager();
        }
    }
    public void nextscene()
    {
        SceneManager.LoadScene("chiakiexecutionroom");
    }
    public void startgame()
    {
        SceneManager.LoadScene("proj");
    }
    public void startscene()
    {
        SceneManager.LoadScene("timeforexecute");
    }
}
