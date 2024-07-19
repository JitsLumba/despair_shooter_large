using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class spawnpause : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject raycastui;
    [SerializeField] private GameObject pause_screen;
    private bool notpaused = true;
    [SerializeField] private gunscript gun_script;
    [SerializeField] private projectilefire proj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !(notpaused))
        {
            
            //Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && notpaused)
        {
            Debug.Log("GO PAUSE");
            
            camera.SetActive(true);
                raycastui.SetActive(false);
                notpaused = false;
                pause_screen.SetActive(true);
                //ViewHandler.Instance.Show(ViewNames.pause_screen);
                gun_script.enabled = false;
                proj.enabled = false;
                StartCoroutine(waitforit());
                
            
            
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            stop_pause_sequence();
            

        }
    }
    public void clicked_continue() {
        ViewHandler.Instance.OnBack();
        stop_pause_sequence();
    }
    public void stop_pause_sequence() {
        Debug.Log("STOP PAUSE");
            raycastui.SetActive(true);
            GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1.0f;
            //
            notpaused = true;
            pause_screen.SetActive(false);
            proj.enabled = true;
            gun_script.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            
    }
    IEnumerator waitforit()
    {
        yield return new WaitForSeconds(0.5f);
        proj.enabled = false;
        GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;
        Time.timeScale = 0.0f;
        

    }
    IEnumerator waitalil()
    {
        yield return new WaitForSeconds(0.25f);
        
    }
}
