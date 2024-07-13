using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class messagebehavior : View
{
    [SerializeField] private popupuiscript popper;
    private string message = "Welcome to Unity, ";
    [SerializeField] private Text textfield;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setwelcome(string name)
    {
        string fulmsg = message + name;
        textfield.text = fulmsg;
    }
    public void hideui()
    {
        this.Hide();
    }
    public void showpopup()
    {
        popper.settext();
        ViewHandler.Instance.Show(ViewNames.popup_unity);
    }
}
