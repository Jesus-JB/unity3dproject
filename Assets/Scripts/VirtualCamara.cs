using UnityEngine;
using Cinemachine;

public class VirtualCamara : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public Transform target;

    [Header("Camera Settings")]
    public float followSpeed = 5f;
    public float lookAheadDistance = 5f;
    
    void Start()
    {
        if (target == null)
        {
            Debug.LogError("No se ha asignado un objetivo a la cámara virtual");
            return;
        }

        if (virtualCamera != null)
        {
            virtualCamera.Follow = target;
            virtualCamera.LookAt = target;

            var transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
            if (transposer != null)
            {
                // Ajusta el offset de la cámara
                transposer.m_FollowOffset = new Vector3(0, 3, -1.5f);
                transposer.m_XDamping = followSpeed;
                transposer.m_YDamping = followSpeed;
                transposer.m_ZDamping = followSpeed;
            }

            var composer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
            if (composer != null)
            {
                composer.m_SoftZoneWidth = 0.5f;
                composer.m_SoftZoneHeight = 0.5f;
                composer.m_DeadZoneWidth = 0.3f;
                composer.m_DeadZoneHeight = 0.3f;
                composer.m_LookaheadTime = 0.5f;
                composer.m_LookaheadSmoothing = 1f;
            }
        }
    }

    public void SetTarget(Transform newTarget)
    {
        if (virtualCamera != null)
        {
            virtualCamera.Follow = newTarget;
            virtualCamera.LookAt = newTarget;
        }
    }

    public void SetCameraOffset(Vector3 offset)
    {
        var transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        if (transposer != null)
        {
            transposer.m_FollowOffset = offset;
        }
    }
}
