using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeControl : MonoBehaviour
{
    [SerializeField] public ParticleSystem[] smoke;


    [System.Obsolete]
    // Start is called before the first frame update
    void Start()
    {
     
        //smoke[0].startColor = green;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
