using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRoll : MonoBehaviour
{
    public float duration = 2f;
    //float rotationLeft = 180;
    //float rotationRight = -360;
    //float rotationspeed = 200;

    public float barrelRollDuration = 1.0f;
    public bool inBarrelRoll = false;
    private float movementAxis;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (!inBarrelRoll && Input.GetKeyUp(KeyCode.F))
        {
            StartCoroutine("BarrelRolls");
        }
        /*if (Input.GetMouseButton(1))
        {
            Debug.Log("roll Left!");

            //Rotate(duration);
            float rotation = rotationspeed * Time.deltaTime;
            if (rotationLeft > rotation)
            {
                rotationLeft -= rotation;
            }
            else
            {
                rotation = rotationLeft;
                rotationLeft = 0;
            }
            transform.Rotate(0, 0, rotationLeft);
        }
        if (Input.GetMouseButton(2))
        {
            Debug.Log("roll Right!");

            float rotation = rotationspeed * Time.deltaTime;
            if (rotationRight > rotation)
            {
                rotationRight -= rotation;
            }
            else
            {
                rotation = rotationRight;
                rotationRight = 0;
            }
            transform.Rotate(0, 0, rotation);
        }*/
    }
    IEnumerator BarrelRolls()
    {
        inBarrelRoll = true;
        float t = 0.0f;
        Vector3 initialRotation = transform.localRotation.eulerAngles;
        Vector3 goalRotation = initialRotation;
        goalRotation.z += 180.0f;
        Vector3 currentRotation = initialRotation;

        while (t < barrelRollDuration / 2.0f)
        {
            currentRotation.z = Mathf.Lerp(initialRotation.z, goalRotation.z, t / (barrelRollDuration / 2.0f));
            transform.localRotation = Quaternion.Euler(currentRotation);
            t += Time.deltaTime;
            yield return null;
        }
        t = 0;

        initialRotation = transform.localRotation.eulerAngles;
        goalRotation = initialRotation;
        goalRotation.z += 180.0f;
        while (t < barrelRollDuration / 2.0f)
        {
            currentRotation.z = Mathf.Lerp(initialRotation.z, goalRotation.z, t / (barrelRollDuration / 2.0f));
            transform.localRotation = Quaternion.Euler(currentRotation);
            t += Time.deltaTime;
            yield return null;
        }

        inBarrelRoll = false;
        ResetRotation();
    }

    void ResetRotation()
    {
        transform.localRotation = Quaternion.identity;

    }

    IEnumerator Rotate(float duration)
    {
        float startRotation = transform.eulerAngles.y;
        float endRotation = startRotation + 360.0f;
        float t = 0.0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float yRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360.0f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
            yield return null;
        }
    }
}
