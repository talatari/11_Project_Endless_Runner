using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _highBorder = 3f;
    [SerializeField] private float _lowBorder = -3f;
    
    private Vector3 _targetPosition;

    private void Start() => 
        _targetPosition = transform.position;

    private void Update()
    {
        if (transform.position != _targetPosition)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
    }

    public void SetTargetUp(float offset)
    {
        if (transform.position.y < _highBorder)
            _targetPosition.y += offset * _moveSpeed;
        else
            _targetPosition.y = _highBorder;
    }

    public void SetTargetDown(float offset)
    {
        if (transform.position.y > _lowBorder)
            _targetPosition.y -= offset * _moveSpeed;
        else
            _targetPosition.y = _lowBorder;
    }
}