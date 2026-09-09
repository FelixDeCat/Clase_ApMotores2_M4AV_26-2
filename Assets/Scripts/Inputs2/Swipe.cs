using TMPro;
using UnityEngine;

public class Swipe : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI swipeTest;

    Touch touch;

    Vector2 initialPOs = Vector2.zero;
    Vector2 current = Vector2.zero;

    float x = 0f; // Delta
    float y = 0f; // Delta


    void Update()
    {
        if (Input.touchCount < 1) return;

        touch = Input.GetTouch(0);


        if (touch.phase == TouchPhase.Began)
        {
            initialPOs = touch.position;
        }

        if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
        {
            current = touch.position;

            x = current.x - initialPOs.x;
            y = current.y - initialPOs.y;

            if (Mathf.Abs(x) == 0 && (Mathf.Abs(y) == 0))
            {
                swipeTest.text = "tap";
            }

            else if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                // horizontal
                if (x > 0)
                {
                    swipeTest.text = "derecha";
                }
                else
                {
                    swipeTest.text = "izquierda";
                }
            }
            else
            {
                //vertical
                if (y > 0)
                {
                    swipeTest.text = "arriba";
                }
                else
                {
                    swipeTest.text = "abajo";
                }
            }
        }
    }
}
