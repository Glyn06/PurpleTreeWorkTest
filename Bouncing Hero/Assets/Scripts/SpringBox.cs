using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBox : MonoBehaviour
{

    [SerializeField] float verticalBounceFactor = 1f;
    [SerializeField] float horizontalBounceFactor = 1f;

    public float ApplyVerticalBounceFactor(float verticalSpeed)
    {
        return verticalSpeed * verticalBounceFactor;
    }

    public float ApplyHorizontallBounceFactor(float horizontalSpeed)
    {
        return horizontalSpeed * horizontalBounceFactor;
    }
}
