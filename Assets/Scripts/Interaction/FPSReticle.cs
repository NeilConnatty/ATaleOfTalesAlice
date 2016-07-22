using UnityEngine;

public class FPSReticle : MonoBehaviour
{
    public Camera CameraFacing;
    private Vector3 originalScale;

    // Use this for initialization
    [SerializeField]
    private float distance;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.LookAt(CameraFacing.transform.position);
        transform.position = CameraFacing.transform.position + CameraFacing.transform.rotation * Vector3.forward;
        transform.Rotate(0.0f, 180.0f, 0.0f);

        transform.localScale = originalScale;
    }
}
