using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
public class defeat_script : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject defeat_ui;
    [SerializeField] private GameObject raycast_ui;
    [SerializeField] private GameObject camera;
    [SerializeField] private projectilefire proj;
    [SerializeField] private gunscript gun_script;
    [SerializeField] private spawnpause spawn_pause;
    [SerializeField] private string level_restart_name;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void show_defeat_screen_sequence() {
        camera.SetActive(true);
        
        raycast_ui.SetActive(false);
        defeat_ui.SetActive(true);  
        
        spawn_pause.enabled = false;
        proj.enabled = false;
        gun_script.enabled = false;
            
        StartCoroutine(waitforit());
        
    }
    public void restart_game() {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(level_restart_name);
    }
    public void does_not_continue() {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("despairshooterstartscreen");
    }
    IEnumerator waitforit()
    {
        yield return new WaitForSeconds(0.5f);
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;
        Time.timeScale = 0.0f;
        

    }
}
