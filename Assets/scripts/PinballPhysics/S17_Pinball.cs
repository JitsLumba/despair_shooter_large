using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S17_Pinball : APoolable
{
    [SerializeField] private Rigidbody sphereRB;
    private float yForce = 2000.0f;

    private const float Y_BOUNDARY = -7.95f;
    private Vector3 originPos;
    
    // Start is called before the first frame update
    void Awake()
    {
        this.originPos = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.localPosition.y < Y_BOUNDARY)
        {
            this.poolRef.ReleasePoolable(this);
        }
    }

    public override void Initialize()
    {

    }

    public override void OnActivate()
    {
        this.transform.localPosition = this.originPos;
        Vector3 force = new Vector3(Random.Range(-100.0f, 100.0f), yForce, 0.0f);
        this.sphereRB.AddForce(force);
    }

    public override void Release()
    {
        this.sphereRB.velocity = Vector3.zero;
    }
}
