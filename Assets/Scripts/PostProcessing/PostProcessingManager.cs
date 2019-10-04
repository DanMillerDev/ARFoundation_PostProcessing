using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[RequireComponent(typeof(PostProcessVolume))]
public class PostProcessingManager : MonoBehaviour
{
    [SerializeField]
    CameraFocusManager m_CameraFocusManager = default;
        
    PostProcessVolume m_ProcessVolume;
    DepthOfField m_DepthOfField;

    const int k_InFocusLength = 0;
    const int k_OutOfFocusLength = 50;

    void OnEnable()
    {
        m_ProcessVolume = GetComponent<PostProcessVolume>();
        m_ProcessVolume.profile.TryGetSettings(out m_DepthOfField);

        m_CameraFocusManager.cameraInFocus += OnCameraInFocus;
        m_CameraFocusManager.cameraNotInFocus += OnCameraNotInFocus;
    }
    
    void OnDisable()
    {
        m_CameraFocusManager.cameraInFocus -= OnCameraInFocus;
        m_CameraFocusManager.cameraNotInFocus -= OnCameraNotInFocus;
    }

    void OnCameraInFocus()
    {
        if (m_DepthOfField)
        {
            m_DepthOfField.focalLength.value = k_InFocusLength;
        }
    }
    
    void OnCameraNotInFocus()
    {
        if (m_DepthOfField)
        {
            m_DepthOfField.focalLength.value = k_OutOfFocusLength;
        }
        
    }
}
