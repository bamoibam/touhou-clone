using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteObjectTransform : MonoBehaviour
{
    [SerializeField] private Transform[] routes;
    public Transform[] Routes
    {
        get
        {
            return routes;
        }
    }
}
