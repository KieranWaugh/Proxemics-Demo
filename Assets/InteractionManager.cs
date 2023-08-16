using Leap;
using Leap.Unity;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private LeapServiceProvider _serviceProvider;
    private GestureDetector _gestureDetector;
    [SerializeField] public GameObject cursor;
    public bool isGesture = false;

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
    }

    private void Update()
    {
        if (Preferences.interactionType == InteractionType.Debug)
        {
            cursor.transform.position = Input.mousePosition;
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

    }

    private void onPinch(Hand hand)
    {
        isGesture = true;
        cursor.GetComponent<RectTransform>().localScale = new Vector3((float)0.8, (float)0.8, 1);
    }

    private void onUnPinch(Hand hand)
    {
        isGesture = false;
        cursor.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }

    private void onPinching(Hand hand)
    {

    }


}
