using System;

/// <summary>
/// [Base Class] Representing the shape
/// </summary>
class Shape
{
    /// <summary>
    /// Overriden to get the Area
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public virtual int Area()
    {
        throw new NotImplementedException("Area() is not implemented");
    }
} 

/// <summary>
/// [Derived Class] Representing a Rectangle
/// </summary>
class Rectangle : Shape
{
    private int width;
    private int height;

    public int Width
    {
        get { return this.width; }
        set {
            if (value < 0)
                throw new ArgumentException("Width must be greater than or equal to 0");
            
            this.width = value;
        }
    }

    public int Height
    {
        get { return this.height; }
        set {
            if (value < 0)
                throw new ArgumentException("Height must be greater than or equal to 0");
            
           this.height = value;
        }
    }

    public new int Area()
    {
        return this.Width * this.Height;
    }

    public override string ToString()
    {
        return $"[Rectangle] {this.Width} / {this.Height}";
    }
}
