using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Beed ti add UnityEngine.UI when usign ui elements like text 

public class ItemCollector : MonoBehaviour
{
    //key the the varibales in the class variable so it stays there the entire level 
    private int fireElemental = 0;

    [SerializeField] private Text elementalText;

    //Ontrigger method because we are trying to overwrite on trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FireElemental"))
        {
            Destroy(collision.gameObject);
            fireElemental++;
            elementalText.text = "Elementals: " + fireElemental;
        }
    }
}
