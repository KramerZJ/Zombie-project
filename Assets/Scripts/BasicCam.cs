using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCam : MonoBehaviour
{
    [SerializeField] private float sensX = 100f, sensY = 100f;

    [SerializeField] private Transform BodyOrientation;

    private float xRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX= Input.GetAxisRaw("Mouse X")* Time.deltaTime*sensX;
        float mouseY= Input.GetAxisRaw("Mouse Y")* Time.deltaTime*sensY;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        BodyOrientation.Rotate(Vector3.up * mouseX);
    }
}
