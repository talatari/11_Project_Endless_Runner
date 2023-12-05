using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _stepSize = 3f;
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

    public void TryMoveUp()
    {
        if (_targetPosition.y < _highBorder)
            SetNextPosition(_stepSize);
    }

    public void TryMoveDown()
    {
        if (_targetPosition.y > _lowBorder)
            SetNextPosition(-1 * _stepSize);
    }

    private void SetNextPosition(float stepSize) => 
        _targetPosition = new Vector3(_targetPosition.x, _targetPosition.y + stepSize, 0);
}