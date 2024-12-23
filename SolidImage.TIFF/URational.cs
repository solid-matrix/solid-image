namespace SolidImage.TIFF;

public struct URational
{
    public uint Numerator;

    public uint Denominator;

    public static explicit operator decimal(URational u)
    {
        return (decimal)u.Numerator / u.Denominator;
    }

    public static explicit operator float(URational u)
    {
        return (float)u.Numerator / u.Denominator;
    }

    public static explicit operator double(URational u)
    {
        return (double)u.Numerator / u.Denominator;
    }
}
