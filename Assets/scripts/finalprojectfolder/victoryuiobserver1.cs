using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class victoryuiobserver1 : MonoBehaviour
{
    [SerializeField] private victoryviewhandler viw;
    [SerializeField] private GameObject raycastui;
    [SerializeField] private defeat_script defeat_scripter;
    [SerializeField] private int level_call_num;
    void Awake()
    {

        EventBroadcaster.Instance.AddObserver(EventNames.ON_GAME_NOTIF, updateui);
    }
    void onDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_GAME_NOTIF);
    }
    // Start is called before the first frame update
    void Start()
    {
        nextlevelmanager.Initialize();
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
            nextlevelmanager.Instance.main_menu_return();
        }
        else if (quit_confirm) {
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
                    nextlevelmanager.Instance.loadlevel(level_call_num);
                    Debug.Log("Missy");
                    //viw.writeon(enemy, grade);
                    ViewHandler.Instance.Show(ViewNames.victory_ui1);

                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
            }
            
        }
    }
}
