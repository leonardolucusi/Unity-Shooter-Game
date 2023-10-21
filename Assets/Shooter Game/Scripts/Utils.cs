using UnityEngine;

public static class Utils
{
    public static Vector3 RandomPositionVector3(float min = 100f, float max = 100f)
    {
        return new Vector3(Random.Range(-min, max), Random.Range(-min, max), 0);
    }
    public static Vector2 RandomPositionVector2(float min = 100f, float max = 100f)
    {
        return new Vector2(Random.Range(-min, max), Random.Range(-min, max));
    }
}
