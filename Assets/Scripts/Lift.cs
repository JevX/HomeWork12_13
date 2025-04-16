using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField] private Transform _platform;

    [SerializeField] private Transform _upPoint;
    [SerializeField] private Transform _downPoint;

    [SerializeField] private float _speed = 0.025f;

    public bool IsGameEnd = false;

    private bool _canLift = false;    

    public void Init()
    {
        _canLift = false;

        IsGameEnd = false;
    }

    private void Update()
    {
        if (IsGameEnd == false)
        {
            if (_canLift)
                ChangePlatformPosition(_upPoint.position, _speed);
            else
                ChangePlatformPosition(_downPoint.position, _speed);
        }
    }

    private void ChangePlatformPosition(Vector3 direction, float speed)
    {
        _platform.position = Vector3.MoveTowards(_platform.position, direction, speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        SwitchMoveStatus(other, true);
    }

    private void OnTriggerExit(Collider other)
    {
        SwitchMoveStatus(other, false);
    }

    private void SwitchMoveStatus(Collider other, bool canMove)
    {
        Player itemCollector = other.GetComponentInChildren<Player>();

        if (itemCollector != null)
            _canLift = canMove;
    }
}
