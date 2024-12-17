// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

public delegate void MyDelegate(string msg);

public class MyClass
{
    public event MyDelegate MyEvent;

    public void InvokeEvent(string message)
    {
        MyEvent?.Invoke(message);
    }
}