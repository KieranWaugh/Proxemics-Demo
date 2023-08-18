using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Slider_control : Widget
{
    // Start is called before the first frame update
    public float cPosPrev = 0;
    private float sliderState;
    public Vector3 GestureLocation;
    public bool firstActivate = true;
    void Start()
    {
        type = WidgetType.Slider;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveSlider()
    {
        

        float cPos = cursor.transform.position.y;
        
        if (firstActivate)
        {
            GestureLocation = cursor.transform.localPosition;
            sliderState = sliderState = GameObject.Find("Slider/Handle Slide Area/Handle").GetComponent<RectTransform>().localPosition.y;
            firstActivate = false;
        }

        Slider s = gameObject.GetComponent<Slider>();
        RectTransform handleRectTransform = s.transform.Find("Handle Slide Area/Handle").GetComponent<RectTransform>();
        var HandlePosition = GameObject.Find("Slider/Handle Slide Area/Handle").GetComponent<RectTransform>().localPosition;
        var sliderWidth = s.GetComponent<RectTransform>().sizeDelta.x;
        print(sliderWidth);
        var sliderHeight = s.GetComponent<RectTransform>().sizeDelta.y;
        var sliderStartX = s.GetComponent<RectTransform>().position.x - (sliderWidth / 2);
        var sliderEndX = s.GetComponent<RectTransform>().position.x + (sliderWidth / 2);
        var sliderStartY = s.GetComponent<RectTransform>().position.y - (sliderHeight / 2);
        var sliderEndY = s.GetComponent<RectTransform>().position.y + (sliderHeight / 2);
        
        if (cPosPrev == 0)
        {
            cPosPrev = cursor.GetComponent<RectTransform>().localPosition.x;
        }

        if (!Preferences.proxemic)
        {


            if (!(cursor.transform.localPosition.y < -1 * sliderWidth / 2) && !(cursor.transform.localPosition.y > sliderWidth / 2))
            {
                handleRectTransform.position = new Vector2(cPos, handleRectTransform.position.y);


                float sliderDistance = Vector2.Distance(new Vector2(sliderStartX, sliderStartY), new Vector2(sliderEndX, sliderEndY));
                HandlePosition = GameObject.Find("UI_Slider/Handle Slide Area/Handle").GetComponent<RectTransform>().localPosition;
                float handleDistance = Vector2.Distance(new Vector2(sliderStartX, sliderStartY), HandlePosition);
                float ratio = handleDistance / (sliderDistance);
                float value = Mathf.Lerp(s.minValue, s.maxValue, ratio);
                s.value = value;
            }

        }
        else // Proxemics enabled 
        {
            cPos = cursor.transform.localPosition.y;
            if (cPos != cPosPrev)
            {
                if (GestureLocation.x < cPos)
                {
                    HandlePosition.x = sliderState + Mathf.Abs(cPos - GestureLocation.y);
                }
                else
                {
                    HandlePosition.x = sliderState - Mathf.Abs(cPos - GestureLocation.y);
                }

                if (!(HandlePosition.x < sliderStartX) && !(HandlePosition.x > sliderEndX))
                {
                    handleRectTransform.localPosition = new Vector2(HandlePosition.x, handleRectTransform.localPosition.y);
                    float sliderDistance = Vector2.Distance(new Vector2(sliderStartX, sliderStartY), new Vector2(sliderEndX, sliderEndY));
                    float handleDistance = Vector2.Distance(new Vector2(sliderStartX, sliderStartY), HandlePosition);
                    float ratio = handleDistance / (sliderDistance);
                    float value = Mathf.Lerp(s.minValue, s.maxValue, ratio);
                    s.value = value;
                }

                cPosPrev = cPos;

            }



        }


    }
}
