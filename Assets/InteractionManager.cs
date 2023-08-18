using Leap;
using Leap.Unity;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private LeapServiceProvider _serviceProvider;
    private GestureDetector _gestureDetector;
    [SerializeField] public GameObject cursor;
    public bool isGesture = false;
    private List<GameObject> widgets;
    private GameObject FocusedWidget = null;
    private GameObject activeWidget = null;

    // Start is called before the first frame update

    private void OnEnable()
    {
        _gestureDetector = new GestureDetector();
        _serviceProvider.OnUpdateFrame -= OnUpdateFrame;
        _gestureDetector.OnPinch += onPinch;
        _gestureDetector.OnUnpinch += onUnPinch;
        _gestureDetector.OnPinching += onPinching;

    }

    private void OnDisable()
    {
        _serviceProvider.OnUpdateFrame -= OnUpdateFrame;
        _gestureDetector.OnPinch -= onPinch;
        _gestureDetector.OnPinching -= onPinching;
        _gestureDetector.OnUnpinch -= onUnPinch;
    }

    void Start()
    {
        if (Preferences.proxemic)
        {
            cursor.GetComponent<CircleCollider2D>().enabled = false;
        }

        widgets = getWIdgets();
        
    }

    private void Update()
    {
        if (Preferences.interactionType == InteractionType.Debug)
        {
            cursor.transform.position = Input.mousePosition;
            widgets = getWIdgets();


            if(Preferences.proxemic)
            {
                getProximity();
            }
        }

        if (Input.GetMouseButton(0))
        {
            onPinch(new Hand());
            onPinching(new Hand());
        }
        else
        {
            onUnPinch(new Hand());
        }
    
    }

    // Update is called once per frame
    private void OnUpdateFrame(Frame frame)
    {
        widgets = getWIdgets();
    }

    private void onPinch(Hand hand)
    {
        isGesture = true;
        cursor.GetComponent<RectTransform>().localScale = new Vector3((float)0.3, (float)0.3, 1);

        if(FocusedWidget != null && activeWidget == null)
        {
            FocusedWidget.GetComponent<Widget>().onTrigger?.Invoke(FocusedWidget);
            activeWidget = FocusedWidget;

            if(FocusedWidget.GetComponent<Widget>().type == WidgetType.Button)
            {
                var canv = FocusedWidget.GetComponent<Button>().canvasToInstantiate;
                Preferences.activeCanvas.SetActive(false);
                canv.SetActive(true);
            }
            else
            {
                
                FocusedWidget.GetComponent<Slider_control>().MoveSlider();
            }

            
            
        }
    }

    private void onUnPinch(Hand hand)
    {
        isGesture = false;
        cursor.GetComponent<RectTransform>().localScale = new Vector3((float)0.5, (float)0.5, 1);

        if (activeWidget != null)
        {
            FocusedWidget.GetComponent<Widget>().onUnTrigger?.Invoke(FocusedWidget);
            activeWidget = null;
        }
        

    }

    private void onPinching(Hand hand)
    {

    }

    private List<GameObject> getWIdgets()
    {
        List<GameObject> list = new List<GameObject>();
        foreach (Transform child in gameObject.transform)
        {
            if (child.tag == "UI" && child.gameObject.activeSelf)
            {
                foreach(Transform widget in child.gameObject.transform)
                {
                    if (widget.tag == "Widget" && widget.gameObject.activeSelf)
                    {
                        list.Add(widget.gameObject);
                        
                        widget.gameObject.GetComponent<Widget>().onFocus += onWIdgetFocus;
                        widget.gameObject.GetComponent<Widget>().onUnFocus += onWIdgetUnFocus;
                    }
                }
            }
        }
        return list;
    }

    private void getProximity()
    {
        foreach (GameObject w in widgets)
        {
            w.GetComponent<Widget>().setFocus(false);
        }

        var closest = Preferences.Closest(widgets, cursor);
        closest.GetComponent<Widget>().setFocus(true);
        FocusedWidget = closest;

        
    }

    private void onWIdgetFocus(GameObject b)
    {
       // b.GetComponentInChildren<Outline>().enabled = true;
    }

    private void onWIdgetUnFocus(GameObject b)
    {
        //b.GetComponentInChildren<Outline>().enabled = false ;
    }

    private void onWidgetActivate(GameObject b)
    {

    }


}
