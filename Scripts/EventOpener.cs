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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableHud()
    {
        hud.SetActive(true);
        
    }

     public void DisableHud()
    {
        if (hud.activeSelf)
        {
            Invoke("DHud", 0.5f);
            
        }
        
    }

    public void DHud()
    {
        hud.SetActive(false);
    }

    public void GetTextInfo(GameObject obj)
    {
        Debug.Log(obj.name);
        
        if (IsNearEnough(obj))
        {
            if (!hud.activeSelf)
            {
            Invoke("EnableHud", 0.5f);
            }
            canvasText = obj.GetComponent<Text>().text;
            Debug.Log(obj.name + " sagt: " + canvasText);
            hud.GetComponentInChildren<Text>().text = canvasText;
        }
    }

    private bool IsNearEnough(GameObject objectToCheck)
    {
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
