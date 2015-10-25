using System;

class Node
{
    public Node(int value)
    {
        this.Value = value;
    }

    public int Value { get; set; }
    public int Distance { get; set; }

    public override bool Equals(object obj)
    {
        var other = (Node)obj;
        if(!(other is Node))
        {
            throw new InvalidOperationException();
        }

        return this.Value.Equals(other.Value);
    }

    public override int GetHashCode()
    {
        return this.Value.GetHashCode();
    }
}
