using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Player _isometricCharacterController;

    [SerializeField] private Transform _camera;

    [SerializeField] private float _deltaXForCameraPosition;
    [SerializeField] private float _deltaYForCameraPosition;
    [SerializeField] private float _deltaZForCameraPosition;

    public float DeltaPositionX { get; private set; }
    public float DeltaPositionY { get; private set; }
    public float DeltaPositionZ { get; private set; }

    private Vector3 _characterPositionXZ;

    private void LateUpdate()
    {
        DeltaPositionX = _isometricCharacterController.transform.position.x + _deltaXForCameraPosition;
        DeltaPositionY = _isometricCharacterController.transform.position.y + _deltaYForCameraPosition;
        DeltaPositionZ = _isometricCharacterController.transform.position.z + _deltaZForCameraPosition;

        _characterPositionXZ = new Vector3(DeltaPositionX, DeltaPositionY, DeltaPositionZ);
        
        _camera.position = _characterPositionXZ;
    }

}
