using UnityEngine;

public class BirdAttack : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private BirdMover _birdMover;

    private BulletPool _bulletPool;

    public int TeamIndex { get; private set; }

    public void Init(BulletPool bulletPool, int teamIndex)
    {
        _bulletPool = bulletPool;
        TeamIndex = teamIndex;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Bullet bullet = _bulletPool
                .Spawn(_shootPoint.position, _shootPoint.rotation);

            bullet.SetTeamIndex(TeamIndex);
            bullet.SetAditionalSpeed(_birdMover.VelocityX);
        }
    }
}
