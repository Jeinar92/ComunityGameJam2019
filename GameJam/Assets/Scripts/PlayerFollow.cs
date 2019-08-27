
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [Range (0,10)][SerializeField] float smoothSpeed =10f;
    [SerializeField] Vector3 offSet;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offSet;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }

}
