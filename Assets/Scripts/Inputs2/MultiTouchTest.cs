using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MultiTouchTest : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textDebug;
    [SerializeField] TextMeshProUGUI textDebugBeganTouch;
    [SerializeField] Image testPhase;
    Touch second;
    string msg = string.Empty;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch first = Input.GetTouch(0);
            if (Input.touchCount > 1)
            {
                second = Input.GetTouch(1);
            }
            

            msg = string.Empty;

            msg += "primer toque position " + first.position;
            msg += "primer toque delta " + first.deltaPosition;
            msg += "Phase: " + first.phase;
            msg += "-----------------------";
            if (Input.touchCount > 1)
            {
                msg += "primer toque position " + second.position;
                msg += "primer toque delta " + second.deltaPosition;
                msg += "Phase: " + second.phase;
            }


            switch (first.phase)
            {
                case TouchPhase.Began:
                    textDebugBeganTouch.text = "Began";
                    break;
                case TouchPhase.Moved:
                    testPhase.color = Color.green;
                    break;
                case TouchPhase.Stationary:
                    testPhase.color = Color.blue;
                    break;
                case TouchPhase.Ended:
                    testPhase.color = Color.white;
                    break;
                case TouchPhase.Canceled:
                    textDebugBeganTouch.text = "Canceled";
                    break;
            }


            textDebug.text = msg;
        }
    }
}
