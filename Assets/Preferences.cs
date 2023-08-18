using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Preferences
{
    public static InteractionType interactionType;
    public static bool proxemic = true;
    public static GameObject activeCanvas;
    public static List<PointOfInterest> pointsOfInterest;
    public static bool calibrated = false;
    public static Vector3 top, bottom, left, right;


    public static GameObject Closest(List<GameObject> widgets, GameObject cursor)
    {
        GameObject closetsObject = cursor;
        float oldDistance = 9999;
        foreach (GameObject g in widgets)
        {
            Vector3 pos;

            if (g.GetComponent<Widget>().type == WidgetType.Slider)
            {
                pos = g.transform.Find("Handle Slide Area/Handle").position;
            }
            else
            {
                pos = g.transform.position;
            }

            float dist = Vector3.Distance(cursor.transform.position, pos);
            if (dist < oldDistance)
            {
                closetsObject = g;
                oldDistance = dist;
            }

        }

        return closetsObject;
    }

}

public enum InteractionType{
    Debug,
    CDG
}
