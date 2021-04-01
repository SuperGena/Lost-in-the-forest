using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generation : MonoBehaviour
{
    public Sprite[] examples;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = examples[Random.Range(0, examples.Length)];
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
