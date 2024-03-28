using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.gameObject.SetActive(false);
        }

        if (other.TryGetComponent(out Bullet bullet))
        {
            bullet.gameObject.SetActive(false);
        }
    }
}
