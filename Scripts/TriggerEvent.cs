using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{

    private IEnumerator coroutine;
    public Light l1;
    public GameObject wall;

    public Lighting lighting;
    public AudioSource wind;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(tag);
        if (tag == "Lightning")
        {
             lighting.LightingBolt();
        } else if (tag == "Thunder")
        {
            lighting.Thunder();
        }
        // wind.Play();
        // LightingBolt();
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("STAY");
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("EXIT");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LightingBolt()
    {
        Debug.Log("BLIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIITZ");
        coroutine = WaitAndPrint(0.05f);
        StartCoroutine(coroutine);
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {

        yield return new WaitForSeconds(Random.Range(0.5f, 2.0f));

        l1.intensity = 2;
        wall.SetActive(true);

        yield return new WaitForSeconds(Random.Range(0.01f, 0.15f));

        bool boo = true;
        while (boo)
        {
            yield return new WaitForSeconds(waitTime);
            l1.intensity -= 0.1f;
            if (l1.intensity < 1.5f)
            {
                wall.SetActive(false);
            }
            if (l1.intensity <= 0.001f)
            {
                boo = false;
                l1.intensity = 0;
                wall.SetActive(false);
            }
            print("WaitAndPrint " + Time.time);
        }
    }
}
