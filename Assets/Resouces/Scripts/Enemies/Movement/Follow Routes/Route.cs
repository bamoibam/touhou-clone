using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    [SerializeField] private Transform[] Points;

    private void OnDrawGizmos()
    {
        Vector2 gizmosPos;
        for (float i = 0; i <= 1; i += 0.1f)
        {
            gizmosPos = Mathf.Pow(1 - i, 3) * Points[0].position
                + 3 * Mathf.Pow(1 - i, 2) * i * Points[1].position
                + 3 * (1 - i) * Mathf.Pow(i, 2) * Points[2].position
                + Mathf.Pow(i, 3) * Points[3].position;

            Gizmos.DrawSphere(gizmosPos, 0.1f);
/*
 * (1-t)^2 P0 + 3(1-t)^2t P1 + 3(1-t)t^2 P2 +t^3 P3
 */
        }
        Gizmos.DrawLine(new Vector2(Points[0].position.x, Points[0].position.y)
            , new Vector2(Points[1].position.x, Points[1].position.y));
        Gizmos.DrawLine(new Vector2(Points[2].position.x, Points[2].position.y),
            new Vector2(Points[3].position.x, Points[3].position.y));    }
}
