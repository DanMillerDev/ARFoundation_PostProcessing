using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARCameraManager))]
public class CameraFocusManager : MonoBehaviour
{
    ARCameraManager m_CameraManager;
    XRCameraIntrinsics m_CameraIntrinsics;
    float m_CurrentFocalValueX;
    float m_CachedFocalValueX;
    int m_FrameCounter;
    float m_SettledTimer;

    const float k_TimerLimit = 0.25f;
    const float k_ValuePadding = 16.0f;
    const int k_FrameLimit = 10;

    public event Action cameraNotInFocus;
    public event Action cameraInFocus;

    void Awake()
    {
        m_CameraManager = GetComponent<ARCameraManager>();
    }

    void Update()
    {
        // get camera intrinsics
        if (m_CameraManager.TryGetIntrinsics(out m_CameraIntrinsics))
        {
            m_CurrentFocalValueX = m_CameraIntrinsics.focalLength.x;

            m_FrameCounter++;

            // cache value every 10 frames
            if (m_FrameCounter == k_FrameLimit)
            {
                m_FrameCounter = 0;
                m_CachedFocalValueX = m_CameraIntrinsics.focalLength.x;
            }

            // value is changing, send not focus events
            if (m_CachedFocalValueX != m_CurrentFocalValueX)
            {
                if (m_CachedFocalValueX >= m_CurrentFocalValueX + k_ValuePadding || m_CachedFocalValueX <= m_CurrentFocalValueX - k_ValuePadding)
                {
                    m_SettledTimer = 0;
                    if (cameraNotInFocus != null)
                    {
                        cameraNotInFocus();
                    }
                }
            }
            else
            {
                m_SettledTimer += Time.deltaTime;
            }

            // value has settled, send focus events
            if (m_SettledTimer >= k_TimerLimit)
            {
                m_SettledTimer = 0;
                if (cameraInFocus != null)
                {
                    cameraInFocus();
                }
            }
        }

    }
}
