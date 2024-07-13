using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class spawnpause : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject raycastui;
    private bool notpaused = true;
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
            camera.SetActive(true);
                raycastui.SetActive(false);
                notpaused = false;
                ViewHandler.Instance.Show(ViewNames.pause_screen);
            
            proj.enabled = false;
                StartCoroutine(waitforit());
            
            
            
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            raycastui.SetActive(true);
            GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1.0f;
            notpaused = true;
            proj.enabled = true;
            
            Cursor.lockState = CursorLockMode.Locked;
            


        }
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
