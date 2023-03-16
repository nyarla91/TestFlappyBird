using UnityEngine;

namespace Extentions
{
    public static class VectorExtentions
    {
        public static Vector2 RandomPoint(this Bounds bounds)
        {
            Vector2 max = bounds.max;
            Vector2 min = bounds.min;
            return new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
        }
    }
}