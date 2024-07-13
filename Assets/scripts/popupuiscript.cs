using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class popupuiscript : View
{
    [SerializeField] private Text textf;
    private int num = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void settext()
    {
        string txt = "Popup #" + num + "";
        textf.text = txt;
        num++;
    }
    public void hideui()
    {
        this.Hide();
    }
}
