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
    public GameObject flasher;

    public GameObject hud;

    private float lightDecrease = 0.1f;
    private bool exploded = false;

    public AudioSource lighter;
    public AudioSource expl;

    public AudioSource zitat1;
    public AudioSource zitat2;
    public AudioSource gameOverSound;


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

        /* if (Input.GetKeyDown("k") || Input.GetButtonDown("Fire1"))
        {
            Explosion();    
        }*/
    }

    public void Explosion()
    {
        lighter.Play();

        if (!exploded)
        {
            exploded = true;
            coroutine = WaitAndExplode();
            StartCoroutine(coroutine);
        }

    }

    private IEnumerator WaitAndExplode()
    {
       
        if (Vector3.Distance(lTrigger.transform.position, barn.transform.position) < 50)
        {
           
            yield return new WaitForSeconds(1f);
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
            chairWoman.SetActive(true);

            for (int i = 0; i < 20; i++)
            {
                barn.SetActive(false);
                yield return new WaitForSeconds(4f);
                barn.SetActive(true);
                yield return new WaitForSeconds(4f);
                if (i == 1) zitat1.Play();
                if (i == 5) zitat2.Play();
                if (i == 8) gameOverSound.Play();
                if (i == 10)
                {
                    hud.SetActive(true);
                    hud.GetComponentInChildren<Text>().text = "Thanks for Playing";
                }
                Debug.Log(i);
            }
        }

    }


    public void LightingBolt()
    {
        Debug.Log("BLIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIITZ");
        l1.intensity = 2;

       
        coroutine = WaitAndLight(0.05f);
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
        //yield return new WaitForSeconds(Random.Range(0.5f, 5.0f));

        GetComponent<AudioSource>().Play();
        physicWoman.SetActive(true);

        yield return new WaitForSecondsRealtime(0.25f);
        physicWoman.SetActive(false);

    }

    private IEnumerator WaitAndLight(float waitTime)
    {
        flasher.SetActive(false);
        wall.SetActive(true);
        woman.SetActive(true);
        bool isLightning = true;
        this.GetComponent<AudioSource>().Play();
        while (isLightning)
        {
            yield return new WaitForSeconds(waitTime);


            l1.intensity -= lightDecrease;
            if (l1.intensity < 1.75f)
            {
                wall.SetActive(false);
                flasher.SetActive(true);
            }
            if (l1.intensity < 1.5f)
            {

                flasher.SetActive(true);
                lightDecrease = 0.05f;
                woman.SetActive(false);
            }
            if (l1.intensity <= 0.001f)
            {
                isLightning = false;
                l1.intensity = 0;
                wall.SetActive(false);
            }
           // print("WaitAndPrint " + Time.time);
        }
       // yield return new WaitForSeconds(Random.Range(0.5f, 2.0f));

       
       // yield return new WaitForSeconds(Random.Range(0.01f,0.15f));

        
    }

}
