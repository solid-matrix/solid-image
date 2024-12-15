using System.Runtime.InteropServices;
using SolidBase.BitsOp;

namespace SolidImage.TIFF;

public partial class TiffCodec
{
    private readonly Dictionary<ushort, Tuple<string, IEntryValidator?>> _registeredTags = [];

    private readonly Dictionary<ushort, Tuple<string, int>> _registeredTypes = [];

    public TiffCodec()
    {
        RegisterDefaultTypes();
        RegisterDefaultTags();
    }

    public void RegisterType(ushort code, string name, int size)
    {
        if (size != 1 && size != 2 && size != 4 && size != 8 && size != 16)
            throw new NotSupportedException("type size must be 1 | 2 | 4 | 8 | 16");
        if (!_registeredTypes.ContainsKey(code))
            _registeredTypes[code] = new Tuple<string, int>(name, size);
        else
            throw new InvalidOperationException("type conflict with same code");
    }

    public void RegisterTag(ushort code, string name, IEntryValidator? validator = null)
    {
        _registeredTags[code] = new Tuple<string, IEntryValidator?>(name, validator);
    }

    public string? GetTypeName(ushort code)
    {
        return _registeredTypes.GetValueOrDefault(code)?.Item1;
    }

    public int? GetTypeSize(ushort code)
    {
        return _registeredTypes.GetValueOrDefault(code)?.Item2;
    }

    public string? GetTagName(ushort code)
    {
        return _registeredTags.GetValueOrDefault(code)?.Item1;
    }

    public IEntryValidator? GetValidator(ushort code)
    {
        return _registeredTags.GetValueOrDefault(code)?.Item2;
    }

    public Tiff DecodeOnlyDirectories(Stream stream)
    {
        var byteOrder = (ByteOrder)((stream.ReadByte() << 8) | stream.ReadByte());

        var endianReader = new EndianReaderBase(stream, byteOrder switch
        {
            ByteOrder.LittleEndian => IEndianCodec.CreateLittleEndianCodec(),
            ByteOrder.BigEndian => IEndianCodec.CreateBigEndianCodec(),
            _ => throw new NotSupportedException("not supported endian value")
        });

        var tiff = new Tiff
        {
            ByteOrder = byteOrder,
            Identifier = endianReader.ReadUInt16()
        };

        var ifdOffset = endianReader.ReadUInt32();

        while (true)
        {
            var ifd = new ImageFileDirectory();

            stream.Seek(ifdOffset, SeekOrigin.Begin);

            var numOfEntries = endianReader.ReadUInt16();

            for (var i = 0; i < numOfEntries; i++)
            {
                var entry = new DirectoryEntry
                {
                    TagCode = endianReader.ReadUInt16(),
                    TypeCode = endianReader.ReadUInt16(),
                    Count = endianReader.ReadUInt32()
                };
                var valueOrOffset = endianReader.ReadUInt32();

                var typeSize = GetTypeSize(entry.TypeCode) ?? 0;
                if (typeSize == 0)
                {
                    Console.WriteLine($"type [{entry.TypeCode}] not supported, omitted");
                    continue;
                }

                var dataLen = (int)(entry.Count * typeSize);
                entry.Data = new byte[dataLen];
                if (dataLen <= 4)
                {
                    var buffer = new byte[4];
                    MemoryMarshal.Write(buffer, valueOrOffset);
                    Array.Copy(buffer, 0, entry.Data, 0, dataLen);
                }
                else
                {
                    var prev = stream.Position;
                    stream.Seek(valueOrOffset, SeekOrigin.Begin);

                    switch (typeSize)
                    {
                        case 1:
                            stream.ReadExactly(entry.Data, 0, dataLen);
                            break;
                        case 2:
                        {
                            var value = endianReader.ReadUInt16Range((int)entry.Count);
                            IEndianCodec.CreateConsistentEndianCodec().WriteUInt16Range(value, entry.Data);
                            break;
                        }
                        case 4:
                        {
                            var value = endianReader.ReadUInt32Range((int)entry.Count);
                            IEndianCodec.CreateConsistentEndianCodec().WriteUInt32Range(value, entry.Data);
                            break;
                        }
                        case 8:
                        {
                            var value = endianReader.ReadUInt64Range((int)entry.Count);
                            IEndianCodec.CreateConsistentEndianCodec().WriteUInt64Range(value, entry.Data);
                            break;
                        }
                        case 16:
                        {
                            var value = endianReader.ReadUInt128Range((int)entry.Count);
                            IEndianCodec.CreateConsistentEndianCodec().WriteUInt128Range(value, entry.Data);
                            break;
                        }
                    }

                    stream.Seek(prev, SeekOrigin.Begin);
                }

                ifd.EntryMap.Add(entry.TagCode, entry);
            }

            tiff.Subfiles.Add(new TiffSubfile
            {
                ImageFileDirectory = ifd
            });

            var nextOffset = endianReader.ReadUInt32();
            if (nextOffset == 0) break;
            ifdOffset = nextOffset;
        }

        return tiff;
    }

    public Tiff Decode(Stream stream)
    {
        var tiff = DecodeOnlyDirectories(stream);
        // TODO: read and decode data
        return tiff;
    }
}