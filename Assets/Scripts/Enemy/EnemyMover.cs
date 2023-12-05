using System;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    
    private void Update()
    {
        transform.Translate(Vector3.right * (_moveSpeed * Time.deltaTime));
    }
}