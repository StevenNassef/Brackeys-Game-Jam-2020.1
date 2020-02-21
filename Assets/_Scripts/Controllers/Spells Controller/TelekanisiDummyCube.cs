using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelekanisiDummyCube : MonoBehaviour
{
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color errorColor;
    [SerializeField] private LayerMask mouseMask;
    [SerializeField] private LayerMask detectionMask;

    private Material boxMaterial;
    private Vector3 initialPosition;
    private bool _safe;
    public bool isSafe => _safe;
    private Camera mainCamera;
    void Start()
    {
        boxMaterial = GetComponent<MeshRenderer>().material;
        Debug.Log(boxMaterial.color);
        mainCamera = Camera.main;
    }
    private void OnEnable()
    {
        initialPosition = transform.position;
    }

    private void OnDisable()
    {
        transform.position = initialPosition;
        _safe = false;
    }
    // Update is called once per frame
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(transform.position, transform.localScale * 2);
    }
    void Update()
    {

        if (Physics.CheckBox(transform.position, transform.localScale * 2, transform.localRotation, detectionMask, QueryTriggerInteraction.Ignore))
        {
            _safe = false;
            boxMaterial.SetColor("_BaseColor", errorColor);
            Debug.Log(_safe);
        }
        else
        {
            Debug.Log(_safe);
            _safe = true;
            boxMaterial.SetColor("_BaseColor", selectedColor);
        }
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 50f, Color.red);
        if (Physics.Raycast(ray, out hit, 50f, mouseMask, QueryTriggerInteraction.Ignore))
        {
            Vector3 newPos = hit.point;
            newPos.y = initialPosition.y;
            transform.position = newPos;
        }
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     _safe = false;
    //     boxMaterial.color = errorColor;
    // }

    // private void OnTriggerExit(Collider other)
    // {
    //     _safe = true;
    //     boxMaterial.color = selectedColor;
    // }

    // private void OnTriggerStay(Collider other)
    // {
    //     _safe = false;
    //     boxMaterial.color = errorColor;
    // }
}
