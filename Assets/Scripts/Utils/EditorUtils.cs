using UnityEngine;

namespace Utils
{
    public class EditorUtils
    {
        public static void DrawRectGizmos(Rect rect, Color color)
        {
            Gizmos.color = color;

            Gizmos.DrawLine(new Vector3(rect.xMin, rect.yMin), new Vector3(rect.xMin, rect.yMax));
            Gizmos.DrawLine(new Vector3(rect.xMin, rect.yMax),
                new Vector3(rect.xMax, rect.yMax));
            Gizmos.DrawLine(new Vector3(rect.xMax, rect.yMax),
                new Vector3(rect.xMax, rect.yMin));
            Gizmos.DrawLine(new Vector3(rect.xMin, rect.yMin), new Vector3(rect.xMax, rect.yMin));
        }
    }
}