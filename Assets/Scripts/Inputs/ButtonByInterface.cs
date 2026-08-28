using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonByInterface : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Action callback;
    public void AddCallback(Action cbk)
    {
        callback = cbk;
    }

    bool isActive;
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        isActive = true;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        isActive = false;
    }

    void Update()
    {
        if (!isActive) return;

        callback.Invoke(); /// ExecuteDeJuanito
    }
}
