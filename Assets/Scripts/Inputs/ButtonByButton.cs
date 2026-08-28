using UnityEngine;
using UnityEngine.UI;
using System;

public class ButtonByButton : MonoBehaviour
{
    [SerializeField] Button myButton;

    public delegate void MyCustomAction(); // Definicion
    MyCustomAction execute1;
    MyCustomAction execute2;
    MyCustomAction execute3;
    Action execute4;


    void Start()
    {
        // una vez
        myButton.onClick.AddListener(OnExecute );

        //entra a menu, tocas el boton de remover
        myButton.onClick.RemoveListener(OnExecute);

        /// agregamos nueva accion
        myButton.onClick.AddListener(() => print("salta"));
    }

    public void OnExecute()
    {
        print("Ejecuto el Boton");
    }
}
