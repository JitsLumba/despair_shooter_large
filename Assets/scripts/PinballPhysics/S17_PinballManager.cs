using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S17_PinballManager : MonoBehaviour
{
    [SerializeField] private GameObjectPool objectPool;

    private float ticks = 0.0f;
    private float spawnInterval = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        this.objectPool.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.ticks < spawnInterval)
        {
            this.ticks += Time.deltaTime;
        }
        else if(this.objectPool.HasObjectAvailable(1))
        {
            //spawn
            this.ticks = 0.0f;
            this.objectPool.RequestPoolable();

            this.spawnInterval = Random.Range(0.15f, 0.5f);
        }
    }
}
