using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletType Type { get; private set; }

    public void Setup(BulletType type, Vector3 position, Vector3 dir)
    {
        transform.position = position;
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = dir;

        Type = type;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // GetComponent は interfaceも指定できる。
        // その場合コンポーネントの中で、そのインターフェースが継承されているコンポーネントが取得できる。
        IBulletHitable hitable = collision.gameObject.GetComponent<IBulletHitable>();
        if (hitable != null)
        {
            hitable.OnHit(this);
        }
    }
}

public enum BulletType
{
    Player,
    Enemy
}