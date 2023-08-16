using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Preferences
{
    public static InteractionType interactionType;
    public static bool proxemic = false;


    public static GameObject Closest(GameObject[] widgets, GameObject cursor)
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
