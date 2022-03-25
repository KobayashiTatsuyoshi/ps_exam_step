using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// オブジェクトプール用基底クラス
/// </summary>
/// <typeparam name="T">プールされるコンポーネントのプレハブ</typeparam>
public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour, IPooledObject
{
    [SerializeField] T prefab; // 対象のプレハブ
    private Dictionary<T, bool> instanceActivities = new Dictionary<T, bool>(); // 管理しているインスタンスと待機中かどうか

    /// <summary>
    /// インスタンスを生成またはプールされたオブジェクトを返す。
    /// </summary>
    /// <returns></returns>
    public T Create()
    {
        T target = null;
        foreach(T instance in instanceActivities.Keys)
        {
            bool isActive = instanceActivities[instance];
            if (!isActive)
            {
                target = instance;
                break;
            }
        }

        if (target == null)
        {
            target = Instantiate();
        }
        instanceActivities[target] = true;
        target.OnActive();

        return target;
    }

    // 生成
    private T Instantiate()
    {
        T instance = Instantiate(prefab);
        instanceActivities.Add(instance, false);
        instance.Disable += () =>
        {
            instanceActivities[instance] = false;
            instance.OnDisactive();
        };
        return instance;
    }
}
