using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiologUIController : MonoBehaviour
{

    public Text text;

    float timer = 0;
    float delay;

    public bool isClosing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isClosing && Time.time - timer >= delay)
        {
            gameObject.SetActive(false);
        }
    }

    public void SetDialogUIText(string sendedText, float shutDownDelay)
    {
        text.text = sendedText;
        delay = shutDownDelay;
        timer = delay + Time.time;
        isClosing = true;
    }



}
