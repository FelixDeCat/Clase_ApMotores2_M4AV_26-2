using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] ButtonByEvent left;
    [SerializeField] ButtonByEvent right;
    [SerializeField] ButtonByEvent up;
    [SerializeField] ButtonByEvent down;

    [SerializeField] InputByStick stick;

    [SerializeField] float speed = 5f;

    //[SerializeField] ButtonByInterface btn;


    Vector3 dir = Vector3.zero;

    void Start()
    {
        //left.AddInteraction(SetInput);
        //right.AddInteraction(SetInput);
        //up.AddInteraction(SetInput);
        //down.AddInteraction(SetInput);



    }

    private void Update()
    {
#if UNITY_ANDROID
        dir.x = stick.Dir.x;
        dir.z = stick.Dir.y;
#else
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
#endif



        // El de siempre
        transform.position = transform.position + dir * speed * Time.deltaTime;
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


    //[SerializeField] Vector2 dir;
    //void SetInput(Vector2 v2)
    //{
    //    dir = v2;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    //left.Dir
    //}


    public void ToqueLaT()
    {
        print("El evento se ejecuto porque toque la T");
    }

    public void OnRecString(string st)
    {
        print(st);
    }
}
