using UnityEngine;

namespace InterfaceVersion
{
    public class Player : MonoBehaviour, IBulletHitable
    {
        [SerializeField] private int hp;
        [SerializeField] Bullet bulletPrefab;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 dir = worldMousePos - transform.position;

                var bullet = Instantiate(bulletPrefab);
                bullet.Setup(BulletType.Player, transform.position, dir.normalized);
            }

            var move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            transform.Translate(move * 0.01f);
        }

        /// <summary>
        /// IBulletHitableの実装
        /// </summary>
        /// <param name="bullet"></param>
        public void OnHit(Bullet bullet)
        {
            if (bullet.Type == BulletType.Player) return;
            hp--;
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(bullet.gameObject);
            }
        }
    }
}