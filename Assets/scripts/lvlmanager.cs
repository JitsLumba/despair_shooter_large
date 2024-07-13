using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Important Class
public class lvlmanager
{
    // Start is called before the first frame update
    //singleton pattern
    private static lvlmanager sharedInstance = null;
    private string currentscene = "snowman";
    private string levelone = "snowman";
    private string leveltwo = "lvl2";
    private lvlmanager()
    {

    }
    public static lvlmanager Instance
    {
        get
        {
            return sharedInstance;
        }
    }
    public static void Initialize()
    {
        if (sharedInstance == null) {
            sharedInstance = new lvlmanager();
        }
        
    }
    public void loadlevel()
    {
        if (this.currentscene == levelone)
        {
            this.currentscene = leveltwo;
        }
        else
        {
            this.currentscene = levelone;
        }
        SceneManager.LoadScene(this.currentscene);

    }
    public void LoadGame()
    {
        this.currentscene = levelone;
        SceneManager.LoadScene(this.currentscene);
    }
}
