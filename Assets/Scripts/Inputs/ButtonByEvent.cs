using UnityEngine;
using System;

public class ButtonByEvent : MonoBehaviour
{

    Vector2 dir;
    public enum DPAD
    {
        up, down, left, right
    }

    /// Opcion 1, que el player levante este DIR ButtonByEvent.Dir
    public Vector2 Dir
    {
        get
        {
            return dir;
        }
    }


    //Opcion 2, inyeccion de Interaccion
    Action<Vector2> callbackDir;
    public void AddInteraction(Action<Vector2> cbkdir)
    {
        callbackDir = cbkdir;
    }

    [SerializeField] DPAD current;

    bool isActive = false;
    public void OnDown()
    {
        print("OnDown");
        isActive = true;

        
    }

    public void OnUp()
    {
        print("OnUp");
        isActive = false;

        callbackDir.Invoke(Vector2.zero);
    }

    private void Update()
    {
        if (!isActive) return;

        dir = Vector2.zero;

        print("Mantengo: " + current.ToString());

        switch (current)
        {
            case DPAD.up:
                dir = Vector2.up;
                break;
            case DPAD.down:
                dir = Vector2.down;
                break;
            case DPAD.left:
                dir = Vector2.left;
                break;
            case DPAD.right:
                dir = Vector2.right;
                break;

        }

        callbackDir.Invoke(dir);

        

    }
}
