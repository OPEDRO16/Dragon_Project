using UnityEngine;

public class AimStateManager : MonoBehaviour
{
    [SerializeField] Transform camFollowPos;
    [SerializeField] float mouseSense = 1f;

    private float xAxis,yAxis;


    private void Start()
    {

    }

    private void Update()
    {
        yAxis += Input.GetAxis("Mouse Y") * mouseSense;
        xAxis += Input.GetAxis("Mouse X") * mouseSense;
        yAxis = Mathf.Clamp(yAxis, -80f, 80f);
    }

    private void LateUpdate()
    {
        if (camFollowPos != null)
        {
            // Apply rotations
            camFollowPos.localEulerAngles = new Vector3(yAxis, camFollowPos.localEulerAngles.y, camFollowPos.localEulerAngles.z);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis, transform.eulerAngles.z);
        }
    }
}
