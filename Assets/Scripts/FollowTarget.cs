using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//@Author Krystian Sarowski

public class FollowTarget : MonoBehaviour
{
    //Target transform the camera should follow.
    public Transform m_target;

    //Vector offset from the position of the target the camera is following.
    public Vector3 m_cameraOffset;

    //Used to check if the camera should look directly at the target.
    public bool m_lookAtTarget = false;

    //Used to check if the camera should rotate around the target.
    public bool m_rotateAroundTarget = true;

    public float m_mouseSensitivity = 2.0f;

    //Default size of the offset magnitude.
    private float m_baseMagnitude;

    //Multiplier that is applied to basic magintude of the offset vector.
    private float m_offsetMultiplier = 1.0f;

    // Use this for initialization
    void Start()
    {
        m_baseMagnitude = m_cameraOffset.magnitude;
    }

    // LateUpdate is called after Update methods
    void LateUpdate()
    {
        if (!GameManger.m_gameIsPaused)
        {
            if (m_rotateAroundTarget)
            {
                Quaternion cameraTurnAngle =
                    Quaternion.AngleAxis(Input.GetAxis("Mouse X") * m_mouseSensitivity, Vector3.up);

                m_cameraOffset = cameraTurnAngle * m_cameraOffset;
            }
        }

        Vector3 newCameraPos = m_target.position + m_cameraOffset;

        transform.position = newCameraPos;

        if (m_lookAtTarget || m_rotateAroundTarget)
        {
            transform.LookAt(m_target.position + Vector3.up);
        }
    }

    public void AdjustOffset()
    {
        m_offsetMultiplier += 0.10f;
        m_cameraOffset = m_cameraOffset.normalized * (m_baseMagnitude * m_offsetMultiplier);
    }
}
