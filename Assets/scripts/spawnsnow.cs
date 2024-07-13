using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnsnow : MonoBehaviour
{
    [SerializeField] private GameObject snowmanCopy;
    [SerializeField] private Transform spawnpoint;
    [SerializeField] private List<GameObject> snowlist = new List<GameObject>();

    private float timeStep = 0.0f;
    private float destroystep = 0.0f;
    private float DESTROY_INTERVAL = 5.0f;
    private const float INTERVAL = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.timeStep += Time.deltaTime;
        if (this.timeStep >= INTERVAL)
        {
            this.timeStep = 0.0f;

            GameObject snowman = GameObject.Instantiate<GameObject>(this.snowmanCopy, this.transform);
            snowman.transform.localPosition = this.spawnpoint.localPosition;
            this.snowlist.Add(snowman);
        }
        this.destroystep += Time.deltaTime;
        /*if (this.destroystep >= DESTROY_INTERVAL)
        {
            for (int i= 0; i < this.snowlist.Count; i++)
            {
                GameObject.Destroy(this.snowlist[i]);
            }
            this.snowlist.Clear();
        }*/
    }
}
