using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enternamescript : View
{
    [SerializeField] private InputField input;
    [SerializeField] private messagebehavior msgbeh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showcaseui()
    {
        Debug.Log(input.text);
        msgbeh.setwelcome(input.text);
        ViewHandler.Instance.Show(ViewNames.welc_unity);
    }
    
    public void hideui()
    {
        this.Hide();
    }
}
