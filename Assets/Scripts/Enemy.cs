using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IInteractable
{
    private const float ShootCooldown = 1f;

    [SerializeField] private Transform _shootPoint;

    private Coroutine _shootCoroutine;
    private WaitForSeconds _waitForSeconds = new(ShootCooldown);
    private BulletPool _bulletPool;

    public int TeamIndex { get; private set; }

    public void Init(BulletPool bulletPool, int teamIndex)
    {
        _bulletPool = bulletPool;
        TeamIndex = teamIndex;

        if (_shootCoroutine != null)
            StopCoroutine(_shootCoroutine);

        _shootCoroutine = StartCoroutine(Shoot(_waitForSeconds));
    }

    private IEnumerator Shoot(WaitForSeconds waitForSeconds)
    {
        while (enabled)
        {
            Bullet bullet = _bulletPool.Spawn(_shootPoint.position, _shootPoint.rotation);

            bullet.SetTeamIndex(TeamIndex);
            bullet.SetAditionalSpeed(0);

            yield return waitForSeconds;
        }
    }

    public void Death()
    {
        gameObject.SetActive(false);
    }
}
