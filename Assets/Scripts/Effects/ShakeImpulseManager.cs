using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class ShakeImpulseManager : MonoBehaviour
{
    public CinemachineImpulseSource softImpulse = default;
    public CinemachineImpulseSource mildImpulse = default;
    public CinemachineImpulseSource strongImpulse = default;

    public static ShakeImpulseManager instance = default;

    void Awake()
    {
        instance = this;
    }

    public void FireImpulse(ImpulseStrength impulse) {
        switch (impulse) {
            case ImpulseStrength.softImpulse:
                softImpulse.GenerateImpulse();
                break;
            case ImpulseStrength.mildImpulse:
                mildImpulse.GenerateImpulse();
                break;
            case ImpulseStrength.strongImpulse:
                strongImpulse.GenerateImpulse();
                break;
            default:
                softImpulse.GenerateImpulse();
                break;
        }
    }

}
