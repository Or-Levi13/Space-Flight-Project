using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public Transform targetPoint;

    public float moveSpeed = 8f, rotateSpeed = 3f;

    public Camera mainCam;
    public Camera secondaryCam;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        mainCam.enabled = true;
        secondaryCam.enabled = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, targetPoint.position, moveSpeed * Time.deltaTime) ;
        transform.rotation = Quaternion.Lerp(transform.rotation, targetPoint.rotation, rotateSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.V))
        {
            mainCam.enabled = !mainCam.enabled;
            secondaryCam.enabled = !secondaryCam.enabled;
        }
        
    }
}
