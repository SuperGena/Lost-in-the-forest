using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gen_trees : MonoBehaviour
{
    public Sprite[] examples;
    private SpriteRenderer rend;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = examples[Random.Range(0, examples.Length)];
        rend = GetComponent<SpriteRenderer>();
        rend.sortingOrder = (int)(transform.position.y * -100);
        // + менять скейл рандомно 1 либо -1 (для отражения по горизонтали + вариативность)
    }

    // Update is called once per frame
    void Update()
    {
        Transform kek = GetComponent<Transform>();
        Transform lol = player.GetComponent<Transform>();

        float x1 = kek.position.x;
        float x2 = lol.position.x;

        float y1 = kek.position.y;
        float y2 = lol.position.y;


        // && transform.position.x <= player.tranform.position.x + 2 && transform.position.x >= player.tranform.position.x - 2
        if (y1 + 1 <= y2 && x1 <= x2+2 && x1 >= x2-2)
        {
            rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, (float)0.5);
        
        }else rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, 1);

    }
}
