using UnityEngine;
using VR = UnityEngine.VR;

/*
 * script controlling the performance settings of GearVR platform
 * unused
 */
public class PerformanceThrottler : MonoBehaviour
{
    void Awake ()
    {
        OVRPlugin.cpuLevel = 3;
        OVRPlugin.gpuLevel = 3;
    }
}
