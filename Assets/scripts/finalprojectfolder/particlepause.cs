using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlepause : MonoBehaviour
{
    [SerializeField] private ParticleSystem prt;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(countz());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator countz()
    {
        yield return new WaitForSeconds(1.0f);
        prt.Pause();
    }
}
