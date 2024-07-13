using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ongamenotifobserver : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.ON_GAME_NOTIF, this.updatefields);
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
    void updatefields(Parameters param)
    {
        string samp = param.GetStringExtra("number", "num");
        Debug.Log(samp);
    }
}
