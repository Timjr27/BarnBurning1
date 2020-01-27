using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lighting : MonoBehaviour
{

    private IEnumerator coroutine;


    public Light l1;
    public GameObject wall;
    public GameObject lTrigger;
    public GameObject woman;
    public GameObject barn;
    public GameObject physicWoman;
    public GameObject chairWoman;
    public GameObject fire;

    private float lightDecrease = 0.1f;

    public AudioSource lighter;
    public AudioSource expl;


    // Start is called before the first frame update
    void Start()
    {
        wall.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        /*
        if (c.isTrigger)
        if (Input.GetKeyDown("space")){
            LightingBolt();
        }*/

        if (Input.GetKeyDown("k") || Input.GetButtonDown("Fire1"))
        {
            Explosion();    
        }
    }

    public void Explosion()
    {
        coroutine = WaitAndExplode();
        StartCoroutine(coroutine);
    }

    private IEnumerator WaitAndExplode()
    {
        lighter.Play();
        if (Vector3.Distance(lTrigger.transform.position, barn.transform.position) < 15)
        {
            yield return new WaitForSeconds(4f);
            expl.Play();
            yield return new WaitForSeconds(0.5f);

            fire.SetActive(true);
            yield return new WaitForSeconds(3.5f);

            barn.SetActive(false);
            chairWoman.SetActive(true);
            yield return new WaitForSeconds(1f);

            barn.SetActive(true);
            chairWoman.SetActive(false);
            yield return new WaitForSeconds(4f);

            barn.SetActive(false);
            chairWoman.SetActive(true);
            yield return new WaitForSeconds(4f);

            barn.SetActive(true);
            chairWoman.SetActive(false);
        }

    }


    public void LightingBolt()
    {
        Debug.Log("BLIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIITZ");
        coroutine = WaitAndPrint(0.05f);
        StartCoroutine(coroutine);
    }

    public void Thunder()
    {
        Debug.Log("DONNER");
        coroutine = WaitAndThunder(0.05f);
        StartCoroutine(coroutine);
    }

    private IEnumerator WaitAndThunder(float waitTime)
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 5.0f));

        GetComponent<AudioSource>().Play();
        physicWoman.SetActive(true);

        yield return new WaitForSecondsRealtime(0.25f);
        physicWoman.SetActive(false);

    }

    private IEnumerator WaitAndPrint(float waitTime)
    {

        yield return new WaitForSeconds(Random.Range(0.5f, 2.0f));

        l1.intensity = 2;
        
        wall.SetActive(true);
        woman.SetActive(true);
        yield return new WaitForSeconds(Random.Range(0.01f,0.15f));

        bool boo = true;

        this.GetComponent<AudioSource>().Play();
        while (boo)
        {
            yield return new WaitForSeconds(waitTime);
            l1.intensity -= lightDecrease;
            if (l1.intensity < 1.5f)
            {
                wall.SetActive(false);
                lightDecrease = 0.05f;
                woman.SetActive(false);
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
