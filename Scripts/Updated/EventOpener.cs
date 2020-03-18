using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventOpener : MonoBehaviour
{

    private string canvasText = "Default";

    public Canvas canvas;
    public Transform player;
    public GameObject hud;
    public GameObject pointingObject;
    public GameObject can;
    public GameObject lighter;

    public bool isPointing = false;
    public bool canActive = false;
    public bool gameEnde = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPointing && IsNearEnough(pointingObject))
        {
            GetTextInfo(pointingObject);
        }
    }

    public void EnableHud()
    {
        hud.SetActive(true);
        
    }

     public void DisableHud()
    {
        isPointing = false;
        //if (hud.activeSelf)
        //{
        Invoke("DHud", 0.5f);
            
        //}
        
    }

    public void Points()
    {
        if (isPointing)
        {
            hud.GetComponentInChildren<Text>().text += "\n\n...";
            Debug.Log("SLSLSLSL");
            Invoke("Points", 0.5f);
        }
    }

    public void AddFuel(GameObject toRemove)
    {
        toRemove.SetActive(false);
    }

    public void TakeCanAway(AudioSource canSound)
    {
        canSound.Play();
        can.SetActive(false);
        DHud();
        Invoke("WegZeiger", 2f);
        isPointing = false;
    }

    public void TakeLighterAway(AudioSource lighterSound)
    {
        //lighterSound.Play();
        lighter.SetActive(false);
        DHud();
        // Invoke("WegZeiger", 2f);
        isPointing = false;
    }

    public void WegZeiger()
    {
        hud.SetActive(true);

        canvasText = "Folge dem Pfad...";
        hud.GetComponentInChildren<Text>().text = canvasText;
        Invoke("DHud", 3f);
    }

    public void DHud()
    {
        hud.SetActive(false);
    }

    public void PointingEnter(GameObject obj)
    {
        isPointing = true;
        pointingObject = obj;
    }

    public void GetTextInfo(GameObject obj)
    {
        Debug.Log(obj.name);
        if (!hud.activeSelf && !gameEnde)
        {
        Invoke("EnableHud", 0.5f);
        }
        canvasText = obj.GetComponent<Text>().text;
        Debug.Log(obj.name + " sagt: " + canvasText);
        hud.GetComponentInChildren<Text>().text = canvasText;
        
    }

    public void GameOver()
    {
        gameEnde = true;
    }

    private bool IsNearEnough(GameObject objectToCheck)
    {
        if (objectToCheck == null)
        {
            return false;
        }
        bool check = false;
        if (Vector3.Distance(objectToCheck.transform.position,player.position)<5)
        {
            check = true;
        }
        return check;
                       
    }

    private string readText(GameObject gobj)
    {
        Debug.Log(gobj.GetComponent<Text>().text);

        return gobj.GetComponent<Text>().text;
    }
}
