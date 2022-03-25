public interface IPooledObject
{
    event System.Action Disable;
    void OnActive();
    void OnDisactive();
}
