using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject osn;
    public Sprite[] graund;
    public float g;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<50;i++)
            for(int j=0; j<50;j++)
            {
                osn.GetComponent<SpriteRenderer>().sprite = graund[Random.Range(0, graund.Length)];
                Instantiate(osn, new Vector3(i + g, j + g), osn.transform.rotation);

            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
