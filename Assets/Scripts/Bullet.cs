using System;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject
{
    [SerializeField] float speed;
    public BulletType Type { get; private set; }

    public event Action Disable;

    public void OnActive()
    {
        gameObject.SetActive(true);
    }

    public void OnDisactive()
    {
        gameObject.SetActive(false);
    }

    public void Setup(BulletType type, Vector3 position, Vector3 dir)
    {
        transform.position = position;
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = dir * speed;

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

    public void Destroy()
    {
        Disable();
    }
}

public enum BulletType
{
    Player,
    Enemy
}