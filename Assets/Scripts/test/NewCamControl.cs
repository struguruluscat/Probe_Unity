using UnityEngine;

public class NewCamControl : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform posTarget;

    public float distance = 12.0f;
    public float targetHeight = 5f;

    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float rotateSpeed = 200.0f;


    private void FixedUpdate()
    {
        CameraMovement();
        CameraRotation();
    }


    private void CameraMovement()
    {
        float step = moveSpeed * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(target.rotation.eulerAngles);
        Vector3 vTargetOffset;
        vTargetOffset = new Vector3(0, target.localPosition.y - targetHeight, 0);
        Vector3 position = target.transform.position - (rotation * Vector3.forward * distance + vTargetOffset);
        transform.position = Vector3.Lerp(transform.position, position, step);
    }


    private void CameraRotation()
    {
        float desiredRot = rotateSpeed * Time.deltaTime;
        Quaternion nextRotation = Quaternion.Slerp(transform.rotation, target.rotation, desiredRot);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, nextRotation, desiredRot);
    }
}