using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiHatPedalController : MonoBehaviour
{
    public bool onPedalDown;
    public Material defaultMaterial;
    public Material triggeredMaterial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hiHatPedalSwitched()
    {
        onPedalDown = !onPedalDown;
        GetComponent<Renderer>().material = onPedalDown == true ? triggeredMaterial : defaultMaterial;
    }
}
