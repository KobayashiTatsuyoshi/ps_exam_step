using System.Collections;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IBulletHitable
{
    [SerializeField] float shotSpan;
    public BulletPool pool;

    public void Setup()
    {
        StartCoroutine(SpanShot());
        StartCoroutine(Move());
    }

    protected abstract IEnumerator Move();

    private IEnumerator SpanShot()
    {
        while (true)
        {
            yield return new WaitForSeconds(shotSpan);

            float euler = Random.Range(-180, 180);
            Vector2 dir = Quaternion.Euler(0, 0, euler) * Vector2.up;

            var bullet = pool.Create();
            bullet.Setup(BulletType.Enemy, transform.position, dir);
        }
    }

    /// <summary>
    /// IBulletHitableの実装
    /// </summary>
    /// <param name="bullet"></param>
    public void OnHit(Bullet bullet)
    {
        if (bullet.Type == BulletType.Enemy) return;
        Destroy(gameObject);
        bullet.Destroy();
    }
}