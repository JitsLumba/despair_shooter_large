using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesdefeatedobserver : MonoBehaviour
{
    // Start is called before the first frame update
    private int numofenemiesdef;
    void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.ON_GAME_NOTIF, updateparam);
    }
    void OnDestroy()
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
    void updateparam(Parameters param)
    {

    }
}
