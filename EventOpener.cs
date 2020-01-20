using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventOpener : MonoBehaviour
{

    private string dataPath;
    private string canvasText;

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
            Invoke("DHud", 1.5f);
            
        }
        
    }

    public void DHud()
    {
        hud.SetActive(false);
    }

    public void GetTextInfo(GameObject obj)
    {
        if (!hud.activeSelf)
        {
            Invoke("EnableHud", 0.5f);
        }
        dataPath = obj.name + ".file";
        if(IsNearEnough(obj))
        canvasText = readText(dataPath);
        hud.GetComponentInChildren<Text>().text = canvasText;
        
    }

    private bool IsNearEnough(GameObject objectToCheck)
    {
        bool check = false;
        if (Vector3.Distance(objectToCheck.transform.position,player.position)>10)
        {
            check = true;
        }
        return check;
                       
    }

    private string readText(string dataPath)
    {
        return "Ich bin ein \n riesiger Baum \b LOL";
    }
}
