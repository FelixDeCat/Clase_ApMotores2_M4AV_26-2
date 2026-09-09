using UnityEngine;
using UnityEngine.EventSystems;

public class InputByStick : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    [SerializeField] CanvasGroup group;

    Vector3 dir = Vector3.zero;
    public Vector3 Dir
    {
        get
        {
            return dir.normalized;
        }
    }

    [Range(0f,1f)]
    [SerializeField] float transparency;

    Vector3 initialPos = Vector3.zero;
    [SerializeField] Transform target;
    [SerializeField] float range = 75f;

    
    void Start()
    {
        initialPos = target.position;

        group.alpha = transparency;
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        group.alpha = 1;

        print("Empieza el Drag");
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        dir = Vector3.ClampMagnitude((Vector3)eventData.position - initialPos, range); 

        target.position = initialPos + dir;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        print("Termina el Drag");

        dir = Vector3.zero;
        target.position = initialPos;
        group.alpha = transparency;

    }
}
