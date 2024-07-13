using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class snowmanrun : MonoBehaviour
{
    [SerializeField] private int snowmannumb;
    private void Awake()
    {
        Debug.Log("I am awaking snowman #" + this.snowmannumb);
    }    
    // Start is called before the first frame update

    void Start()
    {
        lvlmanager.Initialize();
        Debug.Log("I am going snowman #" + this.snowmannumb);   
    }

    // Update is called once per frame
    void Update()
    {
        //your game is like a glorified while loop 
        //while user is not exiting your game
        //execute all updates
        //big no no
        //while(true)
        Debug.Log("I am running snowman #" + this.snowmannumb);
        
    }
}
