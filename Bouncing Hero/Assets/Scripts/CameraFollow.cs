using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset, minValues, maxValues;

    private void LateUpdate()
    {
        Vector3 newPos = target.position + offset;

        float boundX = Mathf.Clamp(newPos.x, minValues.x, maxValues.x);
        float boundY = Mathf.Clamp(newPos.y, minValues.y, maxValues.y);
        float boundZ = Mathf.Clamp(newPos.z, minValues.z, maxValues.z);

        newPos = new Vector3(boundX, boundY, boundZ);

        transform.position = newPos;
    }
}
