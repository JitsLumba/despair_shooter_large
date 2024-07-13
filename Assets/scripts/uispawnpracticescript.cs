using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class uispawnpracticescript : MonoBehaviour
{
    [SerializeField] private Button someButton;
    [SerializeField] private Text someText;
    [SerializeField] private Image image;
    [SerializeField] private InputField inputfield;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            ViewHandler.Instance.Show(ViewNames.outside_screen);
        }*/
        
    }
    public void showAbaskill() {
        Debug.Log("Hello Worldzu");
        ViewHandler.Instance.Show(ViewNames.aba_skill);
    }
    public void showArcskill()
    {
        Debug.Log("Hello Worldzu");
        ViewHandler.Instance.Show(ViewNames.arc_skill);
    }
    public void showDarkWillskill()
    {
        Debug.Log("Hello Worldzu");
        ViewHandler.Instance.Show(ViewNames.darkw_skill);
    }
    
}
