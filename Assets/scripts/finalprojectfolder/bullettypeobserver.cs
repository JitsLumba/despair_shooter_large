using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bullettypeobserver : MonoBehaviour
{
    [SerializeField] private Text txt;
    // Start is called before the first frame update
    void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.ON_GAME_NOTIF, updatesome);
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
    void updatesome(Parameters param)
    {
        string bulletname = param.GetStringExtra("bullettext", "none");
        float rcolor = param.GetFloatExtra("rcolor", 0.0f), gcolor = param.GetFloatExtra("gcolor", 0.0f), bcolor = param.GetFloatExtra("bcolor", 0.0f), acolor = param.GetFloatExtra("acolor", 0.0f);
        txt.text = bulletname;
        txt.color = new Color(rcolor, gcolor, bcolor, acolor);

    }
}
