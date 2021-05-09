using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextFadeScript : MonoBehaviour
{
    public Text welcomeText;
    public Text subText;
    public float fadeSpeed = 5;
    public bool entrance = false;

    // Start is called before the first frame update
    void Start()
    {
        welcomeText.color = Color.green;
        subText.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        ColorChange();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.entrance = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.entrance = false;

        }
    }

    private void ColorChange()
    {
        if (entrance)
        {
            welcomeText.color = Color.Lerp(welcomeText.color, Color.green, fadeSpeed * Time.deltaTime);
            subText.color = Color.Lerp(welcomeText.color, Color.green, fadeSpeed * Time.deltaTime);
        }
        if (!entrance)
        {
            welcomeText.color = Color.Lerp(welcomeText.color, Color.clear, fadeSpeed * Time.deltaTime);
            subText.color = Color.Lerp(welcomeText.color, Color.clear, fadeSpeed * Time.deltaTime);
        }
    }
}
