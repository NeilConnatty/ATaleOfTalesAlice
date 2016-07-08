using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ArrowRotate : EventTrigger
{
    private Quaternion _targetRotation;
    private Transform _transform;

    void Start ()
    {
        _transform = gameObject.transform;
        _targetRotation = _transform.localRotation;
    }

    public override void OnDrag (PointerEventData eventData)
    {
        Vector3 mousePos = new Vector3 (eventData.position.x, eventData.position.y, 0);
        _targetRotation = Quaternion.LookRotation (Vector3.forward, mousePos - _transform.position);
        _transform.localRotation = _targetRotation;
    }
}
