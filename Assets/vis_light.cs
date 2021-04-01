using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vis_light : MonoBehaviour
{
    private Light li; 
    // Start is called before the first frame update
    void Start()
    {
        li = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            li.range = 10;
        }
        else li.range = 150;
    }
}
