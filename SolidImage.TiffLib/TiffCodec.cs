using SolidImage.Core.BytesCodec;
using SolidImage.Core.BytesReader;
using System.Runtime.InteropServices;

namespace SolidImage.TiffLib;

public static class TiffCodec
{
    private static readonly Dictionary<ushort, Tuple<string, int>> _typeRegistry = [];

    public static void RegisterType(ushort code, string name, int size)
    {
        if (!_typeRegistry.ContainsKey(code))
            _typeRegistry[code] = new Tuple<string, int>(name, size);
        else
            throw new InvalidOperationException("type conflict with same code");
    }

    public static string GetTypeName(ushort code) => _typeRegistry.GetValueOrDefault(code)?.Item1 ?? $"[{code}]";

    public static int? GetTypeSize(ushort code) => _typeRegistry.GetValueOrDefault(code)?.Item2;

    private static void RegisterDefaultTypes()
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

    private static readonly Dictionary<ushort, Tuple<string, IEntryValidator?>> _tagRegistry = [];

    public static void RegisterTag(ushort code, string name, IEntryValidator? validator = null)
    {
        _tagRegistry[code] = new Tuple<string, IEntryValidator?>(name, validator);
    }

    public static string GetTagName(ushort code) => _tagRegistry.GetValueOrDefault(code)?.Item1 ?? $"[{code}]";

    public static IEntryValidator? GetValidator(ushort code) => _tagRegistry.GetValueOrDefault(code)?.Item2;

    private static void RegisterDefaultTags()
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

    static TiffCodec()
    {
        RegisterDefaultTypes();
        RegisterDefaultTags();
    }

    public static unsafe Tiff Decode(Stream stream)
    {
        var byteOrder = (ByteOrder)(stream.ReadByte() << 8 | stream.ReadByte());

        IBytesCodec bytesCodec = byteOrder switch
        {
            ByteOrder.BigEndian => new BigEndianBytesCodec(),
            ByteOrder.LittleEndian => new LittleEndianBytesCodec(),
            _ => throw new NotSupportedException()
        };

        IBytesReader bytesReader = new BaseBytesReader(stream, bytesCodec);

        var identifier = bytesReader.ReadUInt16();

        var ifdOffset = bytesReader.ReadUInt32();

        var ifds = new List<ImageFileDirectory>();

        while (true)
        {
            stream.Seek(ifdOffset, SeekOrigin.Begin);

            var entryMap = new Dictionary<ushort, DirectoryEntry>();
            var entryCount = bytesReader.ReadUInt16();

            for (int i = 0; i < entryCount; i++)
            {
                var entry = new DirectoryEntry { };

                entry.TagCode = bytesReader.ReadUInt16();

                entry.TypeCode = bytesReader.ReadUInt16();
                var typeByteCount = GetTypeSize(entry.TypeCode) ??
                    throw new NotSupportedException($"unsupport type code = {entry.TypeCode}");

                entry.Count = bytesReader.ReadUInt32();

                var valueOrOffset = bytesReader.ReadBytes(4);

                int totalByteCount = (int)(entry.Count * typeByteCount);

                entry.Data = Marshal.AllocHGlobal(totalByteCount);

                if (totalByteCount <= 4)
                {
                    Marshal.Copy(valueOrOffset, 0, entry.Data, totalByteCount);
                }
                else
                {
                    var tmp = stream.Position;
                    var dataOffset = bytesCodec.ReadUInt32(valueOrOffset);
                    stream.Seek(dataOffset, SeekOrigin.Begin);

                    var dataSpan = new Span<byte>((void*)entry.Data, totalByteCount);

                    if ((BitConverter.IsLittleEndian && byteOrder == ByteOrder.LittleEndian) || (!BitConverter.IsLittleEndian && byteOrder == ByteOrder.BigEndian))
                    {
                        // endian matching
                        bytesReader.ReadBytes(dataSpan);
                    }
                    else
                    {
                        // endian not matching, reverse each byte pack
                        var stack = new Stack<byte>();
                        for (int j = 0; j < entry.Count; j++)
                        {
                            for (int k = 0; k < typeByteCount; k++) stack.Push((byte)stream.ReadByte());
                            for (int k = 0; k < typeByteCount; k++) dataSpan[j * typeByteCount + k] = stack.Pop();
                        }
                    }
                    stream.Seek(tmp, SeekOrigin.Begin);
                }

                entryMap.Add(entry.TagCode, entry);
            }

            ifds.Add(new ImageFileDirectory { EntryMap = entryMap });

            var nextOffset = bytesReader.ReadUInt32();
            if (nextOffset == 0) break;
            ifdOffset = nextOffset;
        }

        return new Tiff()
        {
            ByteOrder = byteOrder,
            Identifier = identifier,
            ImageFileDirectories = ifds
        };
    }
}

