using System.Collections;

using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
public class victoryuiobserver2 : MonoBehaviour
{

    //[SerializeField] private Text enemiesslain, gradetxt;
    
    [SerializeField] private defeat_script defeat_scripter;
    [SerializeField] private GameObject victory_screen;
    [SerializeField] private GameObject camera;
    [SerializeField] private spawnpause spawn_pause;
    [SerializeField] private projectilefire proj;
    [SerializeField] private gunscript gun_script;
    
    void Awake()
    {

        EventBroadcaster.Instance.AddObserver(EventNames.ON_GAME_NOTIF, updateui);
        nextlevelmanager.Initialize();
    }
    void onDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_GAME_NOTIF);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void updateui(Parameters param)
    {
        bool main_menu_confirm = param.GetBoolExtra("wants_to_main_menu", false);
        bool quit_confirm  = param.GetBoolExtra("wants_to_quit", false);
        
        if (main_menu_confirm) {
            Time.timeScale = 1.0f;
            nextlevelmanager.Instance.main_menu_return();
        }
        else if (quit_confirm) {
            Time.timeScale = 1.0f;
            nextlevelmanager.Instance.close_game();
        }
        else {
            bool check = param.GetBoolExtra("win1", false);
            bool player_lost_confirm = param.GetBoolExtra("lose1", false);
            string enemy = param.GetIntExtra("enemiesdestruct", -1) + "";
            string grade = param.GetStringExtra("grader", "Z");
            if (player_lost_confirm) {
                //defeat screen
                defeat_scripter.show_defeat_screen_sequence();
            }
            else {
                if (check)
                {
                    //Victory Screen
                    Debug.Log("VICTORY YAY");
                    camera.SetActive(true);
        
                    
                    victory_screen.SetActive(true);  
        
                    spawn_pause.enabled = false;
                    proj.enabled = false;
                    gun_script.enabled = false;
            
                    StartCoroutine(waitforit());

                    //nextlevelmanager.Instance.loadlevel(level_call_num);
                    Debug.Log("Missy");
                    //viw.writeon(enemy, grade);
                    

                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
            }
            
        }
    }
    IEnumerator waitforit()
    {
        yield return new WaitForSeconds(0.5f);
        proj.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;
        Time.timeScale = 0.0f;
        

    }
}
