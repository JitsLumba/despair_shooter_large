using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpobserver : MonoBehaviour
{
    [SerializeField] private Image healthbar;
    
    // Start is called before the first frame update
    void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.ON_GAME_NOTIF, updatehp);
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
    void updatehp(Parameters param)
    {
        
        float hpratio = param.GetFloatExtra("hpnum", 1.0f);
        Debug.Log(hpratio + " hp");
        healthbar.rectTransform.localScale = new Vector3(hpratio, 1, 1);
    }
}
