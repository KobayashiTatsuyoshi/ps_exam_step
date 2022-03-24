using System.Collections;
using UnityEngine;

public class MoveHorizontalEnemy : EnemyBase
{
    protected override IEnumerator Move()
    {
        var originPos = transform.position;
        var left = new Vector3(-1, 0, 0);
        var right = new Vector3(1, 0, 0);
        float t = 0f;
        while (true)
        {
            transform.position = originPos + Vector3.Lerp(left, right, Mathf.Cos(t));
            t += Time.deltaTime;
            yield return null;
        }
    }
}