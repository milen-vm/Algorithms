using System;

class Area : IComparable<Area>
{
    public int StartRow { get; set; }

    public int StartCol { get; set; }

    public int Size { get; set; }

    public Area(int startRow, int startCol, int size)
    {
        this.StartRow = startRow;
        this.StartCol = startCol;
        this.Size = size;
    }

    public override string ToString()
    {
        return string.Format("({0}, {1}), size: {2}", this.StartRow, this.StartCol, this.Size);
    }

    public int CompareTo(Area other)
    {
        int result = this.Size.CompareTo(other.Size) * (-1);
        if (result == 0)
        {
            result = this.StartRow.CompareTo(other.StartRow);
        }

        if (result == 0)
        {
            result = this.StartCol.CompareTo(other.StartCol);
        }

        return result;
    }
}
