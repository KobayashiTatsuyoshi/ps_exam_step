﻿using System.Collections;
using UnityEngine;

namespace InterfaceVersion
{
    public class Enemy : MonoBehaviour, IBulletHitable
    {
        [SerializeField] Bullet bulletPrefab;
        [SerializeField] float shotSpan;

        private void Start()
        {
            StartCoroutine(SpanShot());
        }

        private IEnumerator SpanShot()
        {
            while (true)
            {
                yield return new WaitForSeconds(shotSpan);

                float euler = Random.Range(-180, 180);
                Vector2 dir = Quaternion.Euler(0, 0, euler) * Vector2.up;

                var bullet = Instantiate(bulletPrefab);
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
        }
    }

}