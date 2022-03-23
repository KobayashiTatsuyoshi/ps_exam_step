using System.Collections;
using UnityEngine;

namespace InterfaceVersion
{
    public class MoveCircleEnemy : EnemyBase
    {
        protected override IEnumerator Move()
        {
            var horizontal = new Vector3(1, 0, 0);
            var vertical = new Vector3(0, 1, 0);
            var originPos = transform.position - horizontal;
            float t = 0f;
            while (true)
            {
                transform.position = originPos + Mathf.Cos(t) * horizontal + Mathf.Sin(t) * vertical;
                t += Time.deltaTime;
                yield return null;
            }
        }
    }
}
