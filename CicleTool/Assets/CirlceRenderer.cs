using UnityEngine;

[ExecuteInEditMode][RequireComponent(typeof(LineRenderer))]
public class CirlceRenderer : MonoBehaviour
{
    public float Radius{ set => _radius = Mathf.Clamp(value, 0.01f, float.MaxValue); 
        get => _radius ;}

    public uint SegmentCount{set => _segmentCount = (uint)Mathf.Clamp(value, 8, int.MaxValue);
        get => _segmentCount;}
    
    private float _radius;
    private uint _segmentCount;
    

    private LineRenderer _lineRenderer;
    

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.loop = true;
        _lineRenderer.useWorldSpace = false;
        _segmentCount = 8;
        _radius = 5;
    }


    public virtual void UpdateCircle()
    {        
        if (_lineRenderer.positionCount != _segmentCount) 
            _lineRenderer.positionCount = (int)_segmentCount;
        
        for (int i = 0; i < _segmentCount; i++)
        {
            float angle = i * Mathf.PI * 2 / _segmentCount;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * _radius;
            _lineRenderer.SetPosition(i, pos);
        }

        
    }
}