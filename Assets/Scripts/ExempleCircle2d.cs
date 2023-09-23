using Generators;
using UnityEngine;

public class ExempleCircle2d : MonoBehaviour
{
    [SerializeField] private float circleRadius = 10f;
    [SerializeField] private Vector2Int size = new Vector2Int(100, 100);
    private float[] _noiseMap;
    void Awake()
    {
        var generator = new CircleGenerator2D();
        _noiseMap = generator.GenerateGewichtet(circleRadius, size.x, size.y);
    }

    private void OnDrawGizmos()
    {
        if (_noiseMap == null) return;
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                var index = x * size.x + y;
                var pos = new Vector3(x, y, 0f);
                Gizmos.color = Color.Lerp(Color.white, Color.red, _noiseMap[index] > 0f ? 1f : 0f);
                Gizmos.DrawCube(pos, Vector3.one * 0.5f);
            }
        }
    }
}
