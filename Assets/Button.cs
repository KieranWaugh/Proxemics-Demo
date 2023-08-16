using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Button : Widget
{
    
    public bool inFocus = false;

    private void Start()
    {
        base.type = WidgetType.Button;

        if (Preferences.proxemic)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        

    }

    private void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cursor")) 
        {
            onFocus?.Invoke(gameObject);
            inFocus = true;
            gameObject.GetComponentInChildren<Outline>().enabled = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Cursor"))
        {
            onUnFocus?.Invoke(gameObject);
            inFocus = false;
            gameObject.GetComponentInChildren<Outline>().enabled = false;
        }
        
    }

    


}
