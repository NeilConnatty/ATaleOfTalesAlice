using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ArrowRotate : EventTrigger
{
    public float XSensitivity = 2f;
	public float YSensitivity = 2f;

    private bool _mouseDown;
    private Quaternion _targetRotation;
    private Transform _transform;

    void Start ()
    {
        _mouseDown = false;
        _transform = gameObject.transform;
        _targetRotation = _transform.localRotation;
    }

    public override void OnPointerDown (PointerEventData eventData)
    {

    }

    public override void OnPointerUp (PointerEventData eventData)
    {

    }

    public override void OnDrag (PointerEventData eventData)
    {
        Vector3 mousePos = new Vector3 (eventData.position.x, eventData.position.y, 0);
        _targetRotation = Quaternion.LookRotation (Vector3.forward, mousePos - _transform.position);
        _transform.localRotation = _targetRotation;
    }
}
