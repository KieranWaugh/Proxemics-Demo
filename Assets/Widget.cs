using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Widget : MonoBehaviour
{
    public Action<GameObject> onFocus, onTrigger, onUnFocus;
    [SerializeField] protected GameObject cursor;
    public WidgetType type;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum WidgetType
{
    Button,
    Slider
}
