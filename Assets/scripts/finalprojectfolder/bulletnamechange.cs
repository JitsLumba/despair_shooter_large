using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bulletnamechange : MonoBehaviour
{
    [SerializeField] private bool elecallow;
    [SerializeField] private Text txtfield;
    private bool canchange = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha2) && canchange && elecallow)
        {
            canchange = false;
            txtfield.text = "Elec";
            txtfield.color = new Color(254.0f, 255, 0, 255);
            StartCoroutine(cd());
        }
        else  if (Input.GetKey(KeyCode.Alpha1) && canchange)
        {
            Debug.Log("Hiey");
            canchange = false;
            txtfield.text = "Break";
            txtfield.color = /*new Color(0, 90, 250, 255); */Color.blue;
            StartCoroutine(cd());
        }
    }
    IEnumerator cd()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Can change");
        canchange = true;
    }
}
