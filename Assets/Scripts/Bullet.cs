using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _baseSpeed = 1;
    private float _aditionalSpeed = 0;

    public int OwnerTeamIndex { get; private set; }

    public void SetTeamIndex(int teamIndex)
    {
        OwnerTeamIndex = teamIndex;
    }

    public void SetAditionalSpeed(float value)
    {
        _aditionalSpeed = value;
    }

    private void Update()
    {
        transform.position += 
            (_baseSpeed + _aditionalSpeed) * Time.deltaTime * transform.right;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IDamageable damageable))
        {
            if (OwnerTeamIndex != damageable.TeamIndex)
            {
                damageable.Death();
                gameObject.SetActive(false);
            }
        }
    }
}
