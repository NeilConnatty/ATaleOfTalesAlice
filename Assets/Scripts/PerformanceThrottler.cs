using UnityEngine;
using VR = UnityEngine.VR;

public class PerformanceThrottler : MonoBehaviour
{
    void Awake ()
    {
        OVRPlugin.cpuLevel = 3;
        OVRPlugin.gpuLevel = 3;
    }
}
