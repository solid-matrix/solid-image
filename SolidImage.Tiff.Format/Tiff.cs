using SolidImage.Core.BytesCodec;
using SolidImage.Core.BytesReader;
using SolidImage.Tiff.Format.Enums;

namespace SolidImage.Tiff.Format;

public sealed class Tiff
{
    public ByteOrder ByteOrder { get; internal set; }

    public ushort Identifier { get; internal set; }

    public uint DirectoriesOffset { get; internal set; }

    public List<ImageFileDirectory> ImageFileDirectories { get; internal set; }

    internal IBytesCodec _bytesCodec;

    internal IBytesReader _bytesReader;

    public Tiff(Stream stream)
    {
        ByteOrder = (ByteOrder)(stream.ReadByte() << 8 | stream.ReadByte());

        _bytesCodec = ByteOrder switch
        {
            ByteOrder.BigEndian => new BigEndianBytesCodec(),
            ByteOrder.LittleEndian => new LittleEndianBytesCodec(),
            _ => throw new NotSupportedException()
        };

        _bytesReader = new BaseBytesReader(stream, _bytesCodec);

        Identifier = _bytesReader.ReadUInt16();

        DirectoriesOffset = _bytesReader.ReadUInt32();

        ImageFileDirectories = [];

        uint offset = DirectoriesOffset;

        while (true)
        {
            var directory = new ImageFileDirectory
            {
                Parent = this,
                EntryMap = []
            };

            stream.Seek(offset, SeekOrigin.Begin);

            var entryCount = _bytesReader.ReadUInt16();
            for (int i = 0; i < entryCount; i++)
            {
                var entry = new DirectoryEntry
                {
                    Tag = (TiffTag)_bytesReader.ReadUInt16(),
                    Type = (TiffType)_bytesReader.ReadUInt16(),
                    Count = _bytesReader.ReadUInt32(),
                    ValueOrOffset = _bytesReader.ReadBytes(4)
                };

                directory.EntryMap.Add(entry.Tag, entry);
            }

            var nextOffset = _bytesReader.ReadUInt32();

            foreach (var pair in directory.EntryMap)
            {
                var entry = pair.Value;
                if (entry.ByteCount > 4)
                {
                    var valueOffset = _bytesCodec.ReadUInt32(entry.ValueOrOffset);
                    stream.Seek(valueOffset, SeekOrigin.Begin);
                    entry.PointerValue = _bytesReader.ReadBytes(entry.ByteCount);
                }
            }

            ImageFileDirectories.Add(directory);

            if (nextOffset == 0) break;
            offset = nextOffset;
        }

    }
}
