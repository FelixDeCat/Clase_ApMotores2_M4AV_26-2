using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] ButtonByEvent left;
    [SerializeField] ButtonByEvent right;
    [SerializeField] ButtonByEvent up;
    [SerializeField] ButtonByEvent down;

    [SerializeField] ButtonByInterface btn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        left.AddInteraction(SetInput);
        right.AddInteraction(SetInput);
        up.AddInteraction(SetInput);
        down.AddInteraction(SetInput);

        btn.AddCallback(OnExecutePepito);
        
    }

    void OnExecute()
    {
        print("Ejecuto el boton por interfaz");
    }
    void OnExecutePepito()
    {
        print("Ejecuto el boton por interfaz, Con PEPITO");
    }

    public void OnExecuteDelPLayer()
    {

    }


    [SerializeField] Vector2 dir;
    void SetInput(Vector2 v2)
    {
        dir = v2;
    }

    // Update is called once per frame
    void Update()
    {
        //left.Dir
    }


    public void ToqueLaT()
    {
        print("El evento se ejecuto porque toque la T");
    }

    public void OnRecString(string st)
    {
        print(st);
    }
}
