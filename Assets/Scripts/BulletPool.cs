using UnityEngine;

public class BulletPool : ObjectPool<Bullet>
{
    private readonly Bullet _prefab = Resources.Load<Bullet>(Paths.Bullet);

    protected override Bullet GetPrefab() =>
        _prefab;
}
