using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnEnable()
    {
        Preferences.activeCanvas = gameObject;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
