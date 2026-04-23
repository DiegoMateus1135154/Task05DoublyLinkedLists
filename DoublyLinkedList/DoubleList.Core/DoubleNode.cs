namespace DoubleList.Core;

public class DoubleNode<T>
{
    public DoubleNode(T data)
    {
        Prev = null;
        Data = data;
        Next = null;
    }

    public DoubleNode<T>? Prev { get; set; }
    public T Data { get; set; }
    public DoubleNode<T>? Next { get; set; }
}
