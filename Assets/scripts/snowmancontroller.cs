using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowmancontroller : MonoBehaviour
{
    private bool forward;
    private bool back;
    private bool left;
    private bool right;
    private bool rotright;
    private bool rotleft;
    private float walk = 0;
    [SerializeField] private float speed;
    [SerializeField] private Transform porttransform;
    // Start is called before the first frame update
    void Start()
    {
        lvlmanager.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        //listen to user input
        if(Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W is pressed");
            this.forward = true;
        }
        else if(Input.GetKeyUp(KeyCode.W))
        {
            this.forward = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("W is pressed");
            this.back = true;
        }
        else if(Input.GetKeyUp(KeyCode.S))
        {
            this.back = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("W is pressed");
            this.left = true;
        }
        else if(Input.GetKeyUp(KeyCode.A))
        {
            this.left = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("W is pressed");
            this.right = true;
        }
        else if(Input.GetKeyUp(KeyCode.D))
        {
            this.right = false;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("W is pressed");
            this.rotright = true;
        }
        else if(Input.GetKeyUp(KeyCode.L))
        {
            this.rotright = false;
        }if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("W is pressed");
            this.rotleft = true;
        }
        else if(Input.GetKeyUp(KeyCode.J))
        {
            this.rotleft = false;
        }
        if(this.forward)
        {
            Vector3 pos = this.transform.localPosition;
            pos.x += (Time.deltaTime * this.speed);
            this.transform.localPosition = pos;
        }
        else if (this.back)
        {
            Vector3 pos = this.transform.localPosition;
            pos.x -= (Time.deltaTime * this.speed);
            this.transform.localPosition = pos;
        }
        else if (this.right)
        {
            Vector3 pos = this.transform.localPosition;
            pos.z += (Time.deltaTime * this.speed);
            this.transform.localPosition = pos;
            
        }
        else if (this.left)
        {
            Vector3 pos = this.transform.localPosition;
            pos.z -= (Time.deltaTime * this.speed);
            this.transform.localPosition = pos;
        }else if (this.rotright)
        {
            /*walk = walk + 1;
            Vector3 to = new Vector3(0, walk, 0);

            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime);*/
            transform.Rotate(0, Time.deltaTime * 5, 0);
        }else if (this.rotleft)
        {
            /*walk = walk + 1;
            Vector3 to = new Vector3(0, walk, 0);

            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime);*/
            transform.Rotate(0, Time.deltaTime * -5, 0);
        }
        Vector3 portalPos = this.porttransform.localPosition;
        Vector3 myPos = this.transform.localPosition;
        Debug.Log("Dist: " + Vector3.Distance(myPos, portalPos));
        if(Vector3.Distance(myPos, portalPos) <= 5.71f)
        {
            Debug.Log("I am in the portal");
            lvlmanager.Instance.loadlevel();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
}
