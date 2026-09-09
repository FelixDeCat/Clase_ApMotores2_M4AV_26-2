using UnityEngine;
using UnityEngine.UI;

public class NativeInput : MonoBehaviour
{

    [SerializeField] Image testEscape;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            testEscape.color = Color.red;
        }
        else
        {
            testEscape.color = Color.white;
        }
    }
}
