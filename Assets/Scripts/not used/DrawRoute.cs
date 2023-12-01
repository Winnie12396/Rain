using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRoute : MonoBehaviour
{

    public Transform[] controlPoints;

    private Vector3 gizmosPosition;

    private void OnDrawGizmos()
    {
        for (float t = 0; t <= 1; t += 0.05f)
        {
            gizmosPosition = Mathf.Pow(1 - t, 3) * controlPoints[0].position + 3 * Mathf.Pow(1 - t, 2) * t * controlPoints[1].position + 3 * (1 - t) * Mathf.Pow(t, 2) * controlPoints[2].position + Mathf.Pow(t, 3) * controlPoints[3].position;

            Gizmos.DrawSphere(gizmosPosition, 0.25f);
        }
        for (float t = 0; t <= 1; t += 0.05f)
        {
            gizmosPosition = Mathf.Pow(1 - t, 3) * controlPoints[3].position + 3 * Mathf.Pow(1 - t, 2) * t * controlPoints[4].position + 3 * (1 - t) * Mathf.Pow(t, 2) * controlPoints[5].position + Mathf.Pow(t, 3) * controlPoints[6].position;

            Gizmos.DrawSphere(gizmosPosition, 0.25f);
        }
        for (float t = 0; t <= 1; t += 0.05f)
        {
            gizmosPosition = Mathf.Pow(1 - t, 3) * controlPoints[6].position + 3 * Mathf.Pow(1 - t, 2) * t * controlPoints[7].position + 3 * (1 - t) * Mathf.Pow(t, 2) * controlPoints[8].position + Mathf.Pow(t, 3) * controlPoints[9].position;

            Gizmos.DrawSphere(gizmosPosition, 0.25f);
        }

        //Gizmos.DrawLine(new Vector3(controlPoints[0].position.x, controlPoints[0].position.y, controlPoints[0].position.z), new Vector3(controlPoints[1].position.x, controlPoints[1].position.y, controlPoints[1].position.z));
        //Gizmos.DrawLine(new Vector3(controlPoints[2].position.x, controlPoints[2].position.y, controlPoints[2].position.z), new Vector3(controlPoints[3].position.x, controlPoints[3].position.y, controlPoints[3].position.z));
        //Gizmos.DrawLine(new Vector3(controlPoints[4].position.x, controlPoints[4].position.y, controlPoints[0].position.z), new Vector3(controlPoints[5].position.x, controlPoints[5].position.y, controlPoints[1].position.z));
        //Gizmos.DrawLine(new Vector3(controlPoints[6].position.x, controlPoints[6].position.y, controlPoints[2].position.z), new Vector3(controlPoints[7].position.x, controlPoints[7].position.y, controlPoints[3].position.z));

    }
}
