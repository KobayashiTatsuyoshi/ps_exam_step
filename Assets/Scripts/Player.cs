using UnityEngine;

public class Player : MonoBehaviour, IBulletHitable
{
    [SerializeField] private int hp;
    [SerializeField] BulletPool pool;
    [SerializeField] InputController inputController;

    private void Start()
    {
        inputController.onPlayerAttack += Shot;
        inputController.onPlayerAttack += Vector2Log;
    }

    private void OnDestroy()
    {
        inputController.onPlayerAttack -= Shot;
        inputController.onPlayerAttack -= Vector2Log;
    }

    private void Shot(Vector2 clickPos)
    {
        Vector2 playerPos = transform.position;
        Vector2 distance = clickPos - playerPos;
        var bullet = pool.Create();
        bullet.Setup(BulletType.Player, playerPos, distance.normalized);
    }

    private void Vector2Log(Vector2 pos)
    {
        Debug.Log(pos);
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
            bullet.Destroy();
        }
    }
}