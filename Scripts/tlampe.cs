using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tlampe : MonoBehaviour
{

    private bool isOn = false;
    public Light light;

    public AudioSource lighter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f")){
            lighter.Play();
            isOn = !isOn;
            light.enabled = isOn;
        }
    }
}
