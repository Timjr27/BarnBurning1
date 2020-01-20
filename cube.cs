using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{

    public float speed;

    public float speedX = 2f;

    public float dirX = 0f;
    // Start is called before the first frame update
    void Start()
    {
        speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        dirX += speedX * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(0f, dirX, 0f);

        transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime*speed, 0f, Input.GetAxis("Vertical") * Time.deltaTime*speed);

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
