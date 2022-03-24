using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IBulletHitable
{
    public void OnHit(Bullet bullet)
    {
        bullet.Destroy();
    }
}
