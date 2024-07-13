using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpbehavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image healthbar;
    private float hp = 5, maxhp = 5, maxer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updatehealthbar()
    {
        float ration = hp / maxhp;
        healthbar.rectTransform.localScale = new Vector3(ration, 1, 1);
    }
    public void damagecalc()
    {
        hp = hp - 1;
        updatehealthbar();
    }
}
