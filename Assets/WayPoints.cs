using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public static Transform[] points;


    private void Awake()
    {
        points = new Transform[transform.childCount];// transform הכוונה באבא של הנקודות מי שמחזיק בכל הנקודות
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }

}
