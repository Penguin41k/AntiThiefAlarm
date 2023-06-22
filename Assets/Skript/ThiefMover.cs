using Unity.VisualScripting;
using UnityEngine;

public class ThiefMover : MonoBehaviour
{
    [SerializeField] private float _speed;
        
    private float _xAxisMoveDirection;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private string _idel = "Idel";
    private string _walk = "Walk";
       
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _xAxisMoveDirection = Input.GetAxis("Horizontal");
        _spriteRenderer.flipX = _xAxisMoveDirection == 0 ? _spriteRenderer.flipX : _xAxisMoveDirection < 0 ;
        
        if (_xAxisMoveDirection != 0)
        {
            transform.Translate(_xAxisMoveDirection*_speed * Time.deltaTime, 0, 0);
            _animator.SetTrigger(_walk);
        }
        else
        {
            _animator.SetTrigger(_idel);
        }
    }
}
