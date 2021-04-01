using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gen_bushes : MonoBehaviour
{
    public Sprite[] examples;
    private SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = examples[Random.Range(0, examples.Length)];
        rend = GetComponent<SpriteRenderer>();
        rend.sortingOrder = (int)(transform.position.y * -100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
