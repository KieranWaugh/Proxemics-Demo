using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Widget : MonoBehaviour
{
    public Action<GameObject> onFocus, onTrigger, onUnFocus, onUnTrigger;
    [SerializeField] protected GameObject cursor;
    public WidgetType type;
    public bool inFocus = false;
    public bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setFocus(bool infocus)
    {
        //print("setting " + gameObject.name + " " + infocus);
        if (infocus)
        {
            
            onFocus?.Invoke(gameObject);
            inFocus = true;
        }
        else
        {
            onUnFocus?.Invoke(gameObject);
            infocus = false;
        }

        gameObject.GetComponentInChildren<Outline>().enabled = infocus;
    }
}

public enum WidgetType
{
    Button,
    Slider
}
