using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCameraController : MonoBehaviour
{
    public Camera cam;
    public Transform target;
    public float speedX = 2f;
    public float minDistance = 1.5f;
    public float hideDistance =  2f;
    public LayerMask obstacles;
    public LayerMask noPlayer;
    float _maxDistance;
    Vector3 _localPosition;
    LayerMask _camOrigin;

    Vector3 _position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }
    void Start()
    {
        _localPosition = target.InverseTransformPoint(_position);
        _maxDistance = Vector3.Distance(_position, target.position);
        _camOrigin = cam.cullingMask;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _position = target.TransformPoint(_localPosition);
        CameraRotation();
        ObstaclesReact();
        HeroReact();
        _localPosition = target.InverseTransformPoint(_position);

    }

    void CameraRotation()
    {
        float mX = Input.GetAxis("Mouse X");
      
        if (mX != 0)
        {
            transform.RotateAround(target.position, Vector3.up, mX*speedX*Time.deltaTime);
        }
        transform.LookAt(target);
    }

    void ObstaclesReact()
    {
        float distance = Vector3.Distance(_position, target.position);
        RaycastHit hit;
        if (Physics.Raycast(target.position, transform.position - target.position, out hit, _maxDistance, obstacles))
        {
            _position = hit.point;
        }
        else if (distance < _maxDistance && !Physics.Raycast(_position, -transform.forward, 1f, obstacles))
        {
            _position -= transform.forward * .05f;
        }
    }

    void HeroReact()
    {
        float distance = Vector3.Distance(_position, target.position);
        if (distance < hideDistance)
            cam.cullingMask = noPlayer;
        else
            cam.cullingMask = _camOrigin;

    }
}
