using UnityEngine;

public class RepasoAbstract : MonoBehaviour
{

    UIInventory inventory;
    void Start()
    {
        Arana arana = new Arana(8);


        //inventory obetenido de alguna manera

        inventory.Open();
    }
}

public abstract class Animal
{
    protected int patas = 0;

    public Animal(int patas)
    {
        this.patas = patas;
    }
    public Animal()
    {
        this.patas = 4;
    }
}

public class Arana : Animal
{
    public Arana(int patas) : base(patas)
    {

    }
    public Arana()
    {

    }
}