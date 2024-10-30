using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ThirdHeroMovment : MonoBehaviour
{
    [SerializeField] Transform _camera;
    [SerializeField] MovmentCharacters _characters;
    Animator animator;

    Vector3 _direction;
    Quaternion _look;
    CharacterController _controller;
    Vector3 TargetRotate => _camera.forward * DISTANCE_OFFSET_CAMERA;

    float _vertical, _horizontal;

    readonly string STR_VERTICAL = "Vertical";
    readonly string STR_HORIZONTAL = "Horizontal";

    const float DISTANCE_OFFSET_CAMERA = 5f;
   
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        Cursor.visible = _characters.VisibleCursor;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetInteger("State", 1);
            Rotate();
        }
        else
            animator.SetInteger("State", 0);
        
    }

    private void Movement()
    {
        if (_controller.isGrounded)
        {
            _horizontal = Input.GetAxis(STR_HORIZONTAL);
            _vertical = Input.GetAxis(STR_VERTICAL);

            _direction = transform.TransformDirection(_horizontal, 0, _vertical).normalized;
        }
        _direction.y -= _characters.Gravity * Time.deltaTime;
        Vector3 dir = _direction * _characters.MovementSpeed * Time.deltaTime;

        _controller.Move(dir);
    }

    void Rotate()
    {
        float mx = Input.GetAxis("Mouse X");
        if (mx != 0)
        {
            transform.Rotate(transform.up * mx * 180 * Time.deltaTime);
        }
        //Vector3 target = TargetRotate;
        //target.y = 0;
        //_look = Quaternion.LookRotation(target);
        //float speed = _characters.AngularSpeed * Time.deltaTime;
        //transform.rotation = Quaternion.RotateTowards(transform.rotation,_look, speed );
    }
}
