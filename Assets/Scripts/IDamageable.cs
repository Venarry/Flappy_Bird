using UnityEngine;

public interface IDamageable
{
    public int TeamIndex { get; }
    public void Death();
}
