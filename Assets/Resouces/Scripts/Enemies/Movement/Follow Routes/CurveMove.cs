using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveMove : MonoBehaviour
{
    private int NoOfRoute = 0;
    private float Param = 0f;
    private Vector2 pos;
    private float moveSpeed;
    private float acceleration;
    private bool allowCoroutine = true;
    private Transform[] routes;
    void Update()
    {
        moveSpeed = GetComponent<Enemy>().Speed;
        acceleration = GetComponent<Enemy>().Acceleration;
        routes = GetComponentInParent<RouteObjectTransform>().Routes;

        if (allowCoroutine)
        {
            StartCoroutine(FollowRoute(NoOfRoute));
        }
    }

    private IEnumerator FollowRoute(int routeNo)
    {
        allowCoroutine = false;
        Vector2 P0 = routes[routeNo].GetChild(0).position;
        Vector2 P1 = routes[routeNo].GetChild(1).position;
        Vector2 P2 = routes[routeNo].GetChild(2).position;
        Vector2 P3 = routes[routeNo].GetChild(3).position;

        while (Param < 1)
        {
            Param += Time.deltaTime * moveSpeed * acceleration;
            pos = Mathf.Pow(1 - Param, 3) * P0
                + 3 * Mathf.Pow(1 - Param, 2) * Param * P1
                + 3 * (1 - Param) * Mathf.Pow(Param, 2) * P2
                + Mathf.Pow(Param, 3) * P3;
            transform.position = pos;
            yield return new WaitForEndOfFrame();
        }
        Param = 0f;
        NoOfRoute += 1;
        if (NoOfRoute > routes.Length - 1)
        {
            NoOfRoute = 0;
        }
        allowCoroutine = true;

    }
}
