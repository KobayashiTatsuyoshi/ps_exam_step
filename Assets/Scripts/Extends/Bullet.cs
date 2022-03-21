using UnityEngine;

namespace ExtendsVersion
{
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
            CharactorBase charactor = collision.gameObject.GetComponent<CharactorBase>();
            if (charactor != null)
            {
                charactor.OnHit(this);
            }
        }
    }

    public enum BulletType
    {
        Player,
        Enemy
    }
}