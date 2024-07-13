using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onenemiesleftobserver : MonoBehaviour
{
    [SerializeField] private Text enemiesleft;
    // Start is called before the first frame update
    void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.ON_GAME_NOTIF, updateenemies);
    }
    void onDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_GAME_NOTIF);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void updateenemies(Parameters param)
    {
        Debug.Log("Updated enemies");
        string left = param.GetStringExtra("enemiesleft", "none");
        enemiesleft.text = left;
    }
}
