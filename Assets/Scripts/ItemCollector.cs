using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;

    [SerializeField] private Text cherriesText;

    private void OnTriggerEnter2D(Collider2D collision)

    {
        Debug.Log("Collision detected");
        if (collision.gameObject.CompareTag("Cherry"))
        {
            cherries++;
            Destroy(collision.gameObject);
            cherriesText.text = "Cherries: " + cherries;

        }
            

    }
}
