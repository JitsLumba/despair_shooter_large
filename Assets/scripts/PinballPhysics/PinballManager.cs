using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballManager : MonoBehaviour {

    [SerializeField] private GameObjectPool pinballPool;

    private float ticks = 0.0f;
    private float spawnInterval = 0.15f;

	// Use this for initialization
	void Start () {
        this.pinballPool.Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		if(this.ticks < spawnInterval) {
            this.ticks += Time.deltaTime;
        }

        else if(this.pinballPool.HasObjectAvailable(1)) {
            //spawn
            this.ticks = 0.0f;
            this.pinballPool.RequestPoolable();

            //randomize next spawn interval
            this.spawnInterval = Random.Range(0.15f, 0.5f);
        }
	}
}
