using UnityEngine;

namespace Generators
{
    public class CircleGenerator2D
    {
        public float[] GenerateGewichtet(float radius, int width, int height)
        {
            var noiseMap = new float[width * height];
            var center = new Vector2Int(width / 2, height / 2);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var index = x * width + y;
                    var pos = new Vector2Int(x, y);
                    var distanceToCenter = (pos - center).magnitude;
                    noiseMap[index] = radius - distanceToCenter;
                }
            }
            return noiseMap;
        }
    }
}