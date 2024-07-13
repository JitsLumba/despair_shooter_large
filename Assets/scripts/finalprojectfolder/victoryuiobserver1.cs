using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class victoryuiobserver1 : MonoBehaviour
{
    [SerializeField] private victoryviewhandler viw;
    [SerializeField] private GameObject raycastui;
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
        bool check = param.GetBoolExtra("win1", false);
        string enemy = param.GetIntExtra("enemiesdestruct", -1) + "";
        string grade = param.GetStringExtra("grader", "Z");
        if (check)
        {
            nextlevelmanager.Instance.loadlevel(2);
            Debug.Log("Missy");
            //viw.writeon(enemy, grade);
            ViewHandler.Instance.Show(ViewNames.victory_ui1);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
