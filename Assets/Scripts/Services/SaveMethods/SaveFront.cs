using System;
using UnityEngine;
using UnityEngine.UI;

public class SaveFront : MonoBehaviour
{
    [SerializeField] Button btn_save;
    [SerializeField] Button btn_load;

    private void Awake()
    {
        btn_save.onClick.AddListener(OnClick_SAVE);
        btn_load.onClick.AddListener(OnClick_LOAD);
    }

    Action load;
    Action save;
    public void SubscribeToButtons(Action _load, Action _save)
    {
        load = _load;
        save = _save;
    }

    void OnClick_SAVE()
    {
        save.Invoke();
    }
    void OnClick_LOAD()
    {
        load.Invoke();
    }
}
