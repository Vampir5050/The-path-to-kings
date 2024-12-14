using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ThirdHeroMovment : MonoBehaviour
{
    public static ThirdHeroMovment Instance { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    [SerializeField] Transform _camera;
    [SerializeField] MovmentCharacters _characters;
    public Animator animator;

    Vector3 _direction;
    Quaternion _look;
    CharacterController _controller;
    Vector3 TargetRotate => _camera.forward * DISTANCE_OFFSET_CAMERA;

    float _vertical, _horizontal;

    readonly string STR_VERTICAL = "Vertical";
    readonly string STR_HORIZONTAL = "Horizontal";

    const float DISTANCE_OFFSET_CAMERA = 5f;

    public bool LockMovement = false;
    public static bool walking;


    void Start()
    {
        _controller = GetComponent<CharacterController>();
        Cursor.visible = _characters.VisibleCursor;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (LockMovement == false)
        {
            Movement();
            if (Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.W))
            {
                animator.SetInteger("State", 1);
                Rotate();
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKeyDown(KeyCode.S))
            {
                animator.SetInteger("State", 2);
                Rotate();
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.A))
            {
                animator.SetInteger("State", 3);
                Rotate();
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.D))
            {

                animator.SetInteger("State", 4);

                Rotate();
            }
            //else if (Input.GetKeyDown(KeyCode.Mouse0))
            //{
            //    animator.SetInteger("State", 5);
            //}
            else
            {
                walking = false;
                SoundManager.Instance.PlayStepsSound();
                animator.SetInteger("State", 0);

            }

        }


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
        walking = true;
        SoundManager.Instance.PlayStepsSound();
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
