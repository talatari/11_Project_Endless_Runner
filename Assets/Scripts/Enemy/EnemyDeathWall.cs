using System;
using UnityEngine;

public class EnemyDeathWall : MonoBehaviour
{
    public event Action collisionWallDeath;

    public void Collision() => 
        collisionWallDeath?.Invoke();
}