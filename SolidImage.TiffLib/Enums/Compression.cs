namespace SolidImage.TiffLib.Enums;

/// <summary>
/// Compression scheme used on the image data.
/// </summary>
public enum Compression : ushort
{

    Unknown = 0,

    Uncompressed = 1,

    CCITT1D = 2,

    Group3Fax = 3,

    Group4Fax = 4,

    LZW = 5,

    JPEG = 6,

    PackBits = 32773,
}
