using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CircleEditorWindow : EditorWindow
{ 
    [MenuItem("Circle/CircleEditor")]
    public static void  ShowWindow () {
       GetWindow(typeof(CircleEditorWindow));
    }
    
    void OnGUI () {
        CirlceRenderer circle = Selection.activeGameObject.GetComponent<CirlceRenderer>();

        Rect rect = new Rect(10, 40, 100, 100);
        
        if(!circle) return;
        EditorGUILayout.LabelField("Radius");
        circle.Radius = EditorGUILayout.Slider(circle.Radius, 1, 100);
        EditorGUILayout.LabelField("Segments");
        circle.SegmentCount = (uint)EditorGUILayout.IntSlider((int)circle.SegmentCount, 8, 100);
        circle.UpdateCircle();
    }
}
