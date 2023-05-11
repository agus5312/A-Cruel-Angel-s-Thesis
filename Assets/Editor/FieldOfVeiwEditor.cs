using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Frogger3))]
public class FieldOfVeiwEditor : Editor
{
    private void OnSceneGUI()
    {
        Frogger3 fov = (Frogger3)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.radius);

        Vector3 viewAngle01 = DirectionFromAngle(fov.transform.eulerAngles.y, -fov.angle / 2);
        Vector3 viewAngle02 = DirectionFromAngle(fov.transform.eulerAngles.y, fov.angle / 2);

        Handles.color = Color.yellow;
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle01 * fov.radius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle02 * fov.radius);

        if (fov.canSeePlayer)
        {
            Handles.color = Color.green;
            Handles.DrawLine(fov.transform.position, fov.playerRef.transform.position);
        }
    }

    Vector3 DirectionFromAngle(float eulerY, float angleInDegreees)
    {
        angleInDegreees += eulerY;

        return new Vector3(Mathf.Sin(angleInDegreees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegreees * Mathf.Deg2Rad));
    }
}
