using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newestGen : MonoBehaviour
{
    public GameObject gr;
    public Sprite[] graund;
    //public Sprite[] trees;
    //public Sprite[] sledi;
    public float g;
    public Transform level;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(level);

    for (int i = 0; i < 200; i++)
        for (int j = 0; j < 200; j++)
        {
            gr.GetComponent<SpriteRenderer>().sprite = graund[Random.Range(0, graund.Length)];
            Instantiate(gr, new Vector3(i + g, j + g), gr.transform.rotation).transform.SetParent(level);
        }

        

    /*
        for (int i = 0; i < 50; i++)
            for (int j = 0; j < 50; j++)
            {
                if(Random.Range(0, 25) == 1)
                {
                    tr.GetComponent<SpriteRenderer>().sprite = trees[Random.Range(0, trees.Length)];
                    Instantiate(tr, new Vector3(i + g, j + g), tr.transform.rotation);
                }
                else
                    if(Random.Range(0, 25) == 1)
                {
                    tr.GetComponent<SpriteRenderer>().sprite = sledi[Random.Range(0, sledi.Length)];
                    Instantiate(sl, new Vector3(i + g, j + g), sl.transform.rotation);
                }
              

            }
    */
        SpriteRenderer[] renderers = FindObjectsOfType<SpriteRenderer>();
        foreach (SpriteRenderer renderer in renderers)
        {
            renderer.sortingOrder = (int)(renderer.transform.position.y * -100);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
