using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Banner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject time;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var subTime = DateTime.Now.ToString().Substring(11, 5);
        time.GetComponent< TMP_Text > ().text = subTime;
        
    }
}
