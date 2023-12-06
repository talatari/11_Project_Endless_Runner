using UnityEngine;

public class FoodMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    
    private void Update() => 
        transform.Translate(Vector3.left * (_moveSpeed * Time.deltaTime));
}