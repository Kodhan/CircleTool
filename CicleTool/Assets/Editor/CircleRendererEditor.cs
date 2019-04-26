using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CirlceRenderer)), CanEditMultipleObjects]
public class CircleRendererEditor : Editor
{
 
    
    public void OnSceneGUI()
    {
        CirlceRenderer circle = (CirlceRenderer)target;

        if(!circle) return;

        float size = HandleUtility.GetHandleSize(circle.transform.position) * 1f;

        EditorGUI.BeginChangeCheck();
        Vector3 handleDirecton = circle.transform.right + circle.transform.forward;
        handleDirecton = Vector3.Normalize(handleDirecton) * 1.2f;
        
        float scale = Handles.ScaleSlider(circle.SegmentCount, circle.transform.position, handleDirecton, circle.transform.rotation, size, 1);
        float radius = Handles.RadiusHandle(circle.transform.rotation, circle.transform.up, circle.Radius);
        
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(circle, "Modify Circle Scale");
            if(scale > 8)
                circle.SegmentCount = (uint)scale;
            
            circle.Radius = radius;
            circle.UpdateCircle();
        }
    }
}