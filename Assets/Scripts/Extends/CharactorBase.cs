using UnityEngine;

namespace ExtendsVersion
{
    public abstract class CharactorBase : MonoBehaviour
    {
        abstract public void OnHit(Bullet bullet);
    }
}