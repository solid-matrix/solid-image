namespace SolidImage.Tiff.Format.Enums;

public enum SubfileType : uint
{
    Default = 0,

    /// <summary>
    /// If the image is a reduced-resoluton version of another image in this TIFF file;
    /// </summary>
    IsSubPreview = 0x01,

    /// <summary>
    /// If the image is a single page of a multi-page image.
    /// </summary>
    IsSubPage = 0x02,

    /// <summary>
    /// If the image defines a transparency mask for another image in this TIFF file.
    /// </summary>
    IsSubMask = 0x04,
}
