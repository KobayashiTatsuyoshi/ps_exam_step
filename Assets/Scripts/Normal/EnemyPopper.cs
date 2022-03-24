using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenericsSample.Normal
{
    public class EnemyPopper : MonoBehaviour
    {
        [SerializeField] MoveCircleEnemy circleEnemyPrefab;
        [SerializeField] MoveHorizontalEnemy horizontalEnemyPrefab;
        [SerializeField] Rect bounds;

        private void Start()
        {
            StartCoroutine(PopHorizontal(horizontalEnemyPrefab, 1f));
            StartCoroutine(PopCircle(circleEnemyPrefab, 1.5f));
        }

        IEnumerator PopHorizontal(MoveHorizontalEnemy prefab, float span)
        {
            while (true)
            {
                yield return new WaitForSeconds(span);

                var pos = Vector2.Lerp(bounds.min, bounds.max, Random.Range(0f, 1f));

                var enemy = Instantiate(prefab);
                enemy.transform.position = pos;
                enemy.transform.parent = transform;
                enemy.Setup();
            }
        }

        IEnumerator PopCircle(MoveCircleEnemy prefab, float span)
        {
            while (true)
            {
                yield return new WaitForSeconds(span);

                var pos = Vector2.Lerp(bounds.min, bounds.max, Random.Range(0f, 1f));

                var enemy = Instantiate(prefab);
                enemy.transform.position = pos;
                enemy.transform.parent = transform;
                enemy.Setup();
            }
        }
    }
}
