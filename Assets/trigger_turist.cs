using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_turist : MonoBehaviour
{
    private bool dog_near;
    // Start is called before the first frame update
    void Start()
    {
        dog_near = false;
    }

    // Update is called once per frame
    void Update()
    {
  
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "sobaken")
        {
            dog_near = true;
            Debug.Log("SOBAKA PRISHLA!!!!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "sobaken")
        {
            dog_near = false;
            Debug.Log("SOBAKA USHLA!!!!");
        }

    }
}
