using System.Collections;
using UnityEngine;

namespace InterfaceVersion
{
    public class EnemyPopper : MonoBehaviour
    {
        [SerializeField] MoveCircleEnemy circleEnemyPrefab;
        [SerializeField] MoveHorizontalEnemy horizontalEnemyPrefab;
        [SerializeField] Rect bounds;

        private void Start()
        {
            StartCoroutine(Pop<MoveHorizontalEnemy>(horizontalEnemyPrefab, 1f));
            StartCoroutine(Pop<MoveCircleEnemy>(circleEnemyPrefab, 1.5f));
        }

        IEnumerator Pop<T>(T prefab, float span) where T : EnemyBase
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
