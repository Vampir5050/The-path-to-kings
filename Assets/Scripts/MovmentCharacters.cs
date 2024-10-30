using UnityEngine;

[CreateAssetMenu(fileName ="Characteristics", menuName = "Movement/MovmentCharacters",order =1)]
public class MovmentCharacters : ScriptableObject
{
    [SerializeField] bool _visibleCursor = false;
    [SerializeField] float _movementSpeed = 1f, _angularSpeed = 1f, _gravity = 15f;
  
    public bool VisibleCursor => _visibleCursor;

    public float MovementSpeed => _movementSpeed;
    public float AngularSpeed => _angularSpeed;
    public float Gravity => _gravity;
}
