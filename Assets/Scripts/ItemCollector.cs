using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private Animator anima;

    void Start()
    {
        anima = GetComponent<Animator>();
        anima.SetBool("CherryCollected", false);
    }
    


    private void OnTriggerEnter2D(Collider2D collision)

    {
        Debug.Log("Collision detected");
        if (collision.gameObject.CompareTag("Cherry"))
        {
            anima.SetBool("CherryCollected", true);
            //new WaitForSeconds(0.6f);
            Destroy(collision.gameObject);

        }
            

    }
}
