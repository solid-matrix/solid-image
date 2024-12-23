namespace SolidImage.TIFF;

public struct Rational
{
    public int Numerator;

    public int Denominator;

    public static explicit operator decimal(Rational u)
    {
        return (decimal)u.Numerator / u.Denominator;
    }

    public static explicit operator float(Rational u)
    {
        return (float)u.Numerator / u.Denominator;
    }

    public static explicit operator double(Rational u)
    {
        return (double)u.Numerator / u.Denominator;
    }
}
