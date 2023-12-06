using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SelectRandomSprite : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;

    private SpriteRenderer _spriteRenderer;
    
    private void Start()
    {
        int randomIndex = Random.Range(0, _sprites.Length);
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _sprites[randomIndex];
    }
}