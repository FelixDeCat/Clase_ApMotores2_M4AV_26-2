using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public abstract class UIPanel : MonoBehaviour
{
    bool isOpen = false;

    CanvasGroup group;
    private void Awake()
    {
        group = GetComponent<CanvasGroup>();
    }


    /// <summary>
    /// Acceso externo PUBLICS
    /// </summary>
    public void Open()
    {
        if (!isOpen)
        {
        isOpen = true;
            group.alpha = 1;
            group.blocksRaycasts = true;
            OnOpened();
        }
    }
    public void Close()
    {
        if (isOpen)
        {

        isOpen = false;
            group.alpha = 0;
            group.blocksRaycasts = false;
            OnClosed();
        }
    }


    protected abstract void OnOpened();
    protected abstract void OnClosed();
    protected abstract void OnUpdate();

    private void Update()
    {
        if (!isOpen) return;
        OnUpdate();
    }


}
