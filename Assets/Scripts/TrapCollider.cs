using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCollider : MonoBehaviour
{

    private GameObject playerobj;
    // Start is called before the first frame update
    void Start()
    {
        playerobj = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)

    {
        
        if (collision.gameObject.CompareTag("Trap"))
        {
            Debug.Log("Trap Collision detected");
            


        }


    }
}
