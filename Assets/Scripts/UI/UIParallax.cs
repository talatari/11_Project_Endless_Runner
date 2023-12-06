using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class UIParallax : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private RawImage _rawImage;
    private float _imageStartPositionX;
    private float _imagePositionX;

    private void Start()
    {
        _rawImage = GetComponent<RawImage>();
        _imageStartPositionX = _rawImage.uvRect.x;
        _imagePositionX = _imageStartPositionX;
    }

    private void Update()
    {
        if (_imagePositionX > 10)
            _imagePositionX = _imageStartPositionX;
        
        _imagePositionX += _speed * Time.deltaTime;
        _rawImage.uvRect = new Rect(_imagePositionX, 0, _rawImage.uvRect.width, _rawImage.uvRect.height);
    }
}