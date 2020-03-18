using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseLook2 : MonoBehaviour
{

    private float xRotation = 0f;
    private float yRotation = 0f;

    public Transform playerBody;
    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Invoke("StartGame", 75f);
    }

    // Update is called once per frame
    void Update()
    {
        /*float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        */
        if (Input.GetKeyDown("k"))
        {
            StartGame();
        }


            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation -= mouseX;
        yRotation = Mathf.Clamp(yRotation, -135f, -45f);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -35f, 60f);

        transform.localRotation = Quaternion.Euler(xRotation, -yRotation, 0f);

        //playerBody.Rotate(Vector3.up * yRotation);

    }


    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
