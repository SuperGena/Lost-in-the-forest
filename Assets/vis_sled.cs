using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vis_sled : MonoBehaviour
{
    public GameObject player;
    public float maxOpacity;
    private Transform tplayer;
    private SpriteRenderer rend;
    public Sprite[] sprite;


    // Start is called before the first frame update
    void Start()
    {
        //maxOpacity = 0;

        rend = GetComponent<SpriteRenderer>();
        tplayer = player.GetComponent<Transform>();

        rend.sprite = sprite[Random.Range(0, sprite.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            float dist = Vector3.Distance(tplayer.position, transform.position);

            if (dist <= 4)
            {
                //maxOpacity [0..1]
                float i = maxOpacity - dist * 25 / 100;
                rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, i);
            }
            else
                rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, 0);
        }
        else
        {
            rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, 0);
        }          
    }
    public void SetMaxOpacity(float a)
    {
        maxOpacity = a;
    }
    public void SetPrevStepColor(Color a)
    {
        rend.color = a;
    }
}
