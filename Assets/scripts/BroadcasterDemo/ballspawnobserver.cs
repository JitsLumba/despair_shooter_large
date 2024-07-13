using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballspawnobserver : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    private int counter = 0;
    private List<GameObject> ballset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_SPAWN_BALL_CLICKED);
    }
    void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.ON_SPAWN_BALL_CLICKED, this.updatevari);
    }
    
    public void updatevari(Parameters param)
    {
        counter = param.GetIntExtra("number", -1);
    }
    public void SpawnBalls(int count)
    {
        for (int i = 0; i < counter; i++)
        {
            GameObject baller = (GameObject) GameObject.Instantiate(ball);
            Vector3 pos = Vector3.zero;
            baller.transform.localPosition = pos;
            ballset.Add(baller);
        }
    }
}
