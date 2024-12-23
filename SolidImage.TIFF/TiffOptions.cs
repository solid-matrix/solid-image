namespace SolidImage.TIFF;

public class TiffOptions
{
    public static TiffOptions Default { get; set; } = new TiffOptions();

    private readonly Dictionary<ushort, string> _tags = [];

    private readonly Dictionary<ushort, ITagValidator> _tagValidators = [];

    private readonly Dictionary<ushort, string> _types = [];

    private readonly Dictionary<ushort, int> _typeSizes = [];

    public TiffOptions()
    {
        RegisterDefaultTags();
        RegisterDefaultTypes();
    }

    private void RegisterDefaultTags()
    {
        RegisterTag(TiffTags.NewSubfileType, nameof(TiffTags.NewSubfileType));
        RegisterTag(TiffTags.SubfileType, nameof(TiffTags.SubfileType));
        RegisterTag(TiffTags.ImageWidth, nameof(TiffTags.ImageWidth));
        RegisterTag(TiffTags.ImageLength, nameof(TiffTags.ImageLength));
        RegisterTag(TiffTags.BitsPerSample, nameof(TiffTags.BitsPerSample));
        RegisterTag(TiffTags.Compression, nameof(TiffTags.Compression));
        RegisterTag(TiffTags.Photometric, nameof(TiffTags.Photometric));
        RegisterTag(TiffTags.Threshholding, nameof(TiffTags.Threshholding));
        RegisterTag(TiffTags.CellWidth, nameof(TiffTags.CellWidth));
        RegisterTag(TiffTags.CellLength, nameof(TiffTags.CellLength));
        RegisterTag(TiffTags.FillOrder, nameof(TiffTags.FillOrder));
        RegisterTag(TiffTags.DocumentName, nameof(TiffTags.DocumentName));
        RegisterTag(TiffTags.ImageDescription, nameof(TiffTags.ImageDescription));
        RegisterTag(TiffTags.Make, nameof(TiffTags.Make));
        RegisterTag(TiffTags.Model, nameof(TiffTags.Model));
        RegisterTag(TiffTags.StripOffsets, nameof(TiffTags.StripOffsets));
        RegisterTag(TiffTags.Orientation, nameof(TiffTags.Orientation));
        RegisterTag(TiffTags.SamplesPerPixel, nameof(TiffTags.SamplesPerPixel));
        RegisterTag(TiffTags.RowsPerStrip, nameof(TiffTags.RowsPerStrip));
        RegisterTag(TiffTags.StripByteCounts, nameof(TiffTags.StripByteCounts));
        RegisterTag(TiffTags.MinSampleValue, nameof(TiffTags.MinSampleValue));
        RegisterTag(TiffTags.MaxSampleValue, nameof(TiffTags.MaxSampleValue));
        RegisterTag(TiffTags.XResolution, nameof(TiffTags.XResolution));
        RegisterTag(TiffTags.YResolution, nameof(TiffTags.YResolution));
        RegisterTag(TiffTags.PlanarConfiguration, nameof(TiffTags.PlanarConfiguration));
        RegisterTag(TiffTags.PageName, nameof(TiffTags.PageName));
        RegisterTag(TiffTags.XPosition, nameof(TiffTags.XPosition));
        RegisterTag(TiffTags.YPosition, nameof(TiffTags.YPosition));
        RegisterTag(TiffTags.FreeOffsets, nameof(TiffTags.FreeOffsets));
        RegisterTag(TiffTags.FreeByteCounts, nameof(TiffTags.FreeByteCounts));
        RegisterTag(TiffTags.GrayResponseUnit, nameof(TiffTags.GrayResponseUnit));
        RegisterTag(TiffTags.GrayResponseCurve, nameof(TiffTags.GrayResponseCurve));
        RegisterTag(TiffTags.T4Options, nameof(TiffTags.T4Options));
        RegisterTag(TiffTags.T6Options, nameof(TiffTags.T6Options));
        RegisterTag(TiffTags.ResolutionUnit, nameof(TiffTags.ResolutionUnit));
        RegisterTag(TiffTags.PageNumber, nameof(TiffTags.PageNumber));
        RegisterTag(TiffTags.TransferFunction, nameof(TiffTags.TransferFunction));
        RegisterTag(TiffTags.Software, nameof(TiffTags.Software));
        RegisterTag(TiffTags.DateTime, nameof(TiffTags.DateTime));
        RegisterTag(TiffTags.Artist, nameof(TiffTags.Artist));
        RegisterTag(TiffTags.HostComputer, nameof(TiffTags.HostComputer));
        RegisterTag(TiffTags.Predictor, nameof(TiffTags.Predictor));
        RegisterTag(TiffTags.WhitePoint, nameof(TiffTags.WhitePoint));
        RegisterTag(TiffTags.PrimaryChromaticities, nameof(TiffTags.PrimaryChromaticities));
        RegisterTag(TiffTags.ColorMap, nameof(TiffTags.ColorMap));
        RegisterTag(TiffTags.HalftoneHints, nameof(TiffTags.HalftoneHints));
        RegisterTag(TiffTags.TileWidth, nameof(TiffTags.TileWidth));
        RegisterTag(TiffTags.TileLength, nameof(TiffTags.TileLength));
        RegisterTag(TiffTags.TileOffsets, nameof(TiffTags.TileOffsets));
        RegisterTag(TiffTags.TileByteCounts, nameof(TiffTags.TileByteCounts));
        RegisterTag(TiffTags.InkSet, nameof(TiffTags.InkSet));
        RegisterTag(TiffTags.InkNames, nameof(TiffTags.InkNames));
        RegisterTag(TiffTags.NumberOfInks, nameof(TiffTags.NumberOfInks));
        RegisterTag(TiffTags.DotRange, nameof(TiffTags.DotRange));
        RegisterTag(TiffTags.TargetPrinter, nameof(TiffTags.TargetPrinter));
        RegisterTag(TiffTags.ExtraSamples, nameof(TiffTags.ExtraSamples));
        RegisterTag(TiffTags.SampleFormat, nameof(TiffTags.SampleFormat));
        RegisterTag(TiffTags.SMinSampleValue, nameof(TiffTags.SMinSampleValue));
        RegisterTag(TiffTags.SMaxSampleValue, nameof(TiffTags.SMaxSampleValue));
        RegisterTag(TiffTags.TransferRange, nameof(TiffTags.TransferRange));
        RegisterTag(TiffTags.JPEGProc, nameof(TiffTags.JPEGProc));
        RegisterTag(TiffTags.JPEGInterchangeFormat, nameof(TiffTags.JPEGInterchangeFormat));
        RegisterTag(TiffTags.JPEGInterchangeFormatLngth, nameof(TiffTags.JPEGInterchangeFormatLngth));
        RegisterTag(TiffTags.JPEGRestartInterval, nameof(TiffTags.JPEGRestartInterval));
        RegisterTag(TiffTags.JPEGLosslessPredictors, nameof(TiffTags.JPEGLosslessPredictors));
        RegisterTag(TiffTags.JPEGPointTransforms, nameof(TiffTags.JPEGPointTransforms));
        RegisterTag(TiffTags.JPEGQTables, nameof(TiffTags.JPEGQTables));
        RegisterTag(TiffTags.JPEGDCTables, nameof(TiffTags.JPEGDCTables));
        RegisterTag(TiffTags.JPEGACTables, nameof(TiffTags.JPEGACTables));
        RegisterTag(TiffTags.YCbCrCoefficients, nameof(TiffTags.YCbCrCoefficients));
        RegisterTag(TiffTags.YCbCrSubSampling, nameof(TiffTags.YCbCrSubSampling));
        RegisterTag(TiffTags.YCbCrPositioning, nameof(TiffTags.YCbCrPositioning));
        RegisterTag(TiffTags.ReferenceBlackWhite, nameof(TiffTags.ReferenceBlackWhite));
        RegisterTag(TiffTags.Copyright, nameof(TiffTags.Copyright));
    }

    private void RegisterDefaultTypes()
    {
        RegisterType(TiffTypes.UBYTE, nameof(TiffTypes.UBYTE), 1);
        RegisterType(TiffTypes.ASCII, nameof(TiffTypes.ASCII), 1);
        RegisterType(TiffTypes.UINT16, nameof(TiffTypes.UINT16), 2);
        RegisterType(TiffTypes.UINT32, nameof(TiffTypes.UINT32), 4);
        RegisterType(TiffTypes.URATIONAL, nameof(TiffTypes.URATIONAL), 8);
        RegisterType(TiffTypes.SBYTE, nameof(TiffTypes.SBYTE), 1);
        RegisterType(TiffTypes.UNDEFINED, nameof(TiffTypes.UNDEFINED), 1);
        RegisterType(TiffTypes.SINT16, nameof(TiffTypes.SINT16), 2);
        RegisterType(TiffTypes.SINT32, nameof(TiffTypes.SINT32), 4);
        RegisterType(TiffTypes.SRATIONAL, nameof(TiffTypes.SRATIONAL), 8);
        RegisterType(TiffTypes.FLOAT, nameof(TiffTypes.FLOAT), 4);
        RegisterType(TiffTypes.DOUBLE, nameof(TiffTypes.DOUBLE), 8);
    }

    public TiffOptions RegisterType(ushort code, string name, int size)
    {
        _types[code] = name;
        _typeSizes[code] = size;
        return this;
    }

    public TiffOptions RegisterTag(ushort code, string name)
    {
        _tags[code] = name;
        return this;
    }

    public TiffOptions RegisterTag(ushort code, string name, ITagValidator validator)
    {
        _tags[code] = name;
        _tagValidators[code] = validator;
        return this;
    }

    public bool TryGetTypeName(ushort code, out string name) => _types.TryGetValue(code, out name!);

    public bool TryGetTypeSize(ushort code, out int size) => _typeSizes.TryGetValue(code, out size);

    public bool TryGetTagName(ushort code, out string name) => _tags.TryGetValue(code, out name!);

    public bool TryGetTagValidator(ushort code, out ITagValidator validator) => _tagValidators.TryGetValue(code, out validator!);

}
