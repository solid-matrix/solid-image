namespace SolidImage.Tiff.Format.Enums;

public enum Photometric : ushort
{
    /// <summary>
    /// For bilevel and grayscale images: 0 is imaged as white.
    /// </summary>
    WhiteIsZero = 0,

    /// <summary>
    /// For bilevel and grayscale images: 0 is imaged as black.
    /// </summary>
    BlackIsZero = 1,

    /// <summary>
    /// RGB color model, a color is described as a combination of the three primary colors of light (red, green, and blue) in particular concentrations.
    /// </summary>
    RGB = 2,

    /// <summary>
    /// Palette color model, a color is described with a single component.
    /// The value of the component is used as an index into the red, green and blue curves in the ColorMap field to retrieve an RGB triplet that defines the color.
    /// </summary>
    RGBPalette = 3,

    /// <summary>
    /// used to define an irregularly shaped region of another image in the same TIFF file.
    /// </summary>
    TranssparencyMask = 4,

    /// <summary>
    /// CMYK color model.
    /// </summary>
    CMYK = 5,

    /// <summary>
    /// YCbcr color model.
    /// </summary>
    YCbCr = 6,

    /// <summary>
    /// CIELab color model.
    /// </summary>
    CIELab = 8,
}
