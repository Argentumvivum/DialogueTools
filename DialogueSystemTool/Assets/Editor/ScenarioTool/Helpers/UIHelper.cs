using UnityEngine;
using UnityEditor;

public class UIHelper
{
    public static void DrawUILine(Color color, int thickness = 2, int padding = 10)
    {
        Rect rect = EditorGUILayout.GetControlRect(GUILayout.Height(padding + thickness));
        rect.height = thickness;
        rect.y += padding / 2;
        rect.x -= 2;
        rect.width += 6;
        EditorGUI.DrawRect(rect, color);
    }
}
