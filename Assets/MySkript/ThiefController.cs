using UnityEngine;

public class ThiefController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _xAxis;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
       
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _xAxis = Input.GetAxis("Horizontal");

        if (_xAxis > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_xAxis < 0)
        {
            _spriteRenderer.flipX = true;
        }

        if (_xAxis != 0)
        {
            transform.Translate(_xAxis*_speed * Time.deltaTime, 0, 0);
            _animator.SetTrigger("Walk");
        }
        else
        {
            _animator.SetTrigger("Idel");
        }
    }
}
