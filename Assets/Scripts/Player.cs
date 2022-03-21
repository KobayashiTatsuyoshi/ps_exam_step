using UnityEngine;

namespace InterfaceVersion
{
    public class Player : MonoBehaviour, IBulletHitable
    {
        [SerializeField] private int hp;
        [SerializeField] Bullet bulletPrefab;
        [SerializeField] InputController inputController;

        private void Start()
        {
            inputController.onPlayerAttack = Shot;
        }

        private void Shot(Vector2 clickPos)
        {
            Vector2 playerPos = transform.position;
            Vector2 distance = clickPos - playerPos;
            var bullet = Instantiate(bulletPrefab);
            bullet.Setup(BulletType.Player, playerPos, distance.normalized);
        }

        private void Update()
        {
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