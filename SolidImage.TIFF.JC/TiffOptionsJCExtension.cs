namespace SolidImage.TIFF.JC;

public static class TiffOptionsJCExtension
{
    public static TiffOptions AddJCExtension(this TiffOptions options)
    {
        options.RegisterTag(TiffJCTags.JC1, "JC1");
        options.RegisterTag(TiffJCTags.JC2, "JC2");
        return options;
    }
}
