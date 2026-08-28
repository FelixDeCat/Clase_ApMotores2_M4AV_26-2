using UnityEngine;

public class RepasoClase2 : MonoBehaviour
{
    IRunneable human;
    IRunneable dog;

    private void Start()
    {
        human = new Human();
        human.Run();

        //Human human2 = new Human();
        //human2.Run();

        dog = new Dog();
        dog.Run();
    }
}

public class Human : IRunneable
{
    void IRunneable.Run()
    {
        Debug.Log("Run");
    }
}
public class Dog : IRunneable
{
    public void Run()
    {
        Debug.Log("Run");
    }
}

public interface IRunneable
{
    void Run();
}