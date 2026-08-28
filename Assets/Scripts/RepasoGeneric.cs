using System;
using UnityEngine;
using UnityEngine.UI;

public class RepasoGeneric : MonoBehaviour
{
    
    private void Start()
    {
        ProcesadorDeEnteros procesador1 = new ProcesadorDeEnteros(2,2);
        procesador1.Procesar();
        print(procesador1.Obtener());

        ProcesadorGenerico<string, string> procesador2 = new ProcesadorGenerico<string, string>("Carlo", "Magno", Concatenar2Veces);
        procesador2.Procesar();
        print(procesador2.Obtener());


        ProcesadorGenerico<int, string> procesador3 = new ProcesadorGenerico<int, string>(20, 26, ProcesarEnterosSumados);
        procesador3.Procesar();
        print(procesador3.Obtener());

        ProcessItem<int>(20, 20, ProcessResta);
    }

    void ProcessSuma(int v1, int v2)
    {
        print(v1 + v2);
    }
    void ProcessResta(int v1, int v2)
    {
        print(v1 - v2);
    }

    string Concatenar(string v1, string v2)
    {
        return v1 + v2;
    }
    string Concatenar2Veces(string v1, string v2)
    {
        return v1 + v2 + ":: " + v1 + v2;
    }

    string ProcesarEnterosSumados(int v1, int v2)
    {
        return (v1 + v2).ToString();
    }

    public void ProcessItem<T>(T data1, T data2, Action<T,T> process)
    {
        process(data1, data2);
    }

}

public class ProcesadorDeEnteros
{
    int prim;
    int secn;
    int procesado;
    public ProcesadorDeEnteros(int primerValor, int segundoValor)
    {
        prim = primerValor;
        secn = segundoValor;
    }
    public void Procesar()
    {
        procesado = prim + secn;
    }

    public int Obtener()
    {
        return procesado;
    }
}

public class Colorizer<T> where T : Renderer
{
    public Colorizer()
    {
        
    }

    public void Colorize(T data, Color color)
    {
        data.material.SetColor("_Color", color);
    }
}
public class WalkMachine<T> where T : IRunneable
{

    public void EnableRun(T data)
    {
        data.Run();
    }
}

public class ProcesadorGenerico<T, RESULT>
{
    T prim;
    T secn;
    RESULT procesado;

    Func<T, T, RESULT> processFunc;
    public ProcesadorGenerico(T primerValor, T segundoValor, Func<T,T,RESULT> processor)
    {
        prim = primerValor;
        secn = segundoValor;

        processFunc = processor;
    }
    public void Procesar()
    {
        procesado = processFunc(prim, secn);
    }

    public RESULT Obtener()
    {
        return procesado;
    }
}
