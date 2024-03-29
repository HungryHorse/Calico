using UnityEngine;
using UnityEditor;

namespace FriedSynapse.FlowEnt
{
    public static class CurveExtensions
    {
#if UNITY_EDITOR
        public static void DrawGizmo(this ICurve curve, Color color = default, float width = 1f, float step = 0.001f)
        {
            Vector3[] points = new Vector3[Mathf.CeilToInt(1f / step) + 2];
            float t = 0f;
            int i = 0;
            if (color == default)
            {
                color = Color.white;
            }
            for (; t <= 1f; t += step, i++)
            {
                points[i] = curve.GetPoint(t);
            }
            for (; i < points.Length; i++)
            {
                points[i] = curve.GetPoint(1f);
            }

            Color initialColour = Handles.color;
            Handles.color = color;
            Handles.DrawAAPolyLine(width, points);
            Handles.color = initialColour;
        }
#endif
    }
}
