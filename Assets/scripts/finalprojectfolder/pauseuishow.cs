using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseuishow : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject raycastUI, cameraobj;
    private bool cango = false, notpaused = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.P) && notpaused)
        {
            //raycastUI.SetActive(false);
            
            
            
            cango = false;
            Debug.Log("pause");
            notpaused = false;
            //ViewHandler.Instance.Show(ViewNames.pause_screen);
            //cameraobj.SetActive(false);
            //StartCoroutine(pauseinterval());
        }
        else if ((Input.GetKeyDown(KeyCode.P) ) && !(notpaused))
        {
            cameraobj.SetActive(true);
            pauseUI.SetActive(false);
            cango = false;
            Debug.Log("Pauser");
            notpaused = true;
            Time.timeScale = 1.0f;
            //StartCoroutine(pauseinterval());
        }*/
    }
    IEnumerator pauseinterval()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Pausering");

        
    }
}
