using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private InteractionManager im;
    [SerializeField] private GameObject home;


    // Start is called before the first frame update
    private void OnEnable()
    {
        im = GetComponentInParent<InteractionManager>();
        Preferences.activeCanvas = gameObject;
    }
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Preferences.proxemic)
        {
            

           
        }
        else
        {
        }checkWidgets();
    }

    private void checkWidgets()
    {
        if(startButton.GetComponent<Button>().inFocus && im.isGesture)
        {
            //home.SetActive(true) ;
            //gameObject.SetActive(false) ;
        }
    }
}
