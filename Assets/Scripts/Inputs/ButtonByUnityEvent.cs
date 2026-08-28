using UnityEngine;
using UnityEngine.Events;

public class ButtonByUnityEvent : MonoBehaviour
{
    [SerializeField] UnityEvent onTouchT;
    [SerializeField] UnityEventString onSendParameter;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            onTouchT.Invoke();
        }


        onSendParameter.Invoke("pepito");
    }
}

[System.Serializable]
public class UnityEventString : UnityEvent<string>
{

}
