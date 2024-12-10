using SolidImage.Core.BytesCodec;

namespace SolidImage.Core.BytesReader;

public class BaseBytesReader : IBytesReader
{
    protected Stream _stream;

    protected IBytesCodec _codec;

    public BaseBytesReader(Stream stream, IBytesCodec codec)
    {
        _stream = stream;
        _codec = codec;
    }

    public ushort ReadUInt16()
    {
        Span<byte> buffer = stackalloc byte[2];
        _stream.ReadExactly(buffer);
        return _codec.ReadUInt16(buffer);
    }

    public uint ReadUInt32()
    {
        Span<byte> buffer = stackalloc byte[4];
        _stream.ReadExactly(buffer);
        return _codec.ReadUInt32(buffer);
    }

    public ulong ReadUInt64()
    {
        Span<byte> buffer = stackalloc byte[8];
        _stream.ReadExactly(buffer);
        return _codec.ReadUInt64(buffer);
    }

    public short ReadInt16()
    {
        Span<byte> buffer = stackalloc byte[2];
        _stream.ReadExactly(buffer);
        return _codec.ReadInt16(buffer);
    }

    public int ReadInt32()
    {
        Span<byte> buffer = stackalloc byte[4];
        _stream.ReadExactly(buffer);
        return _codec.ReadInt32(buffer);
    }

    public long ReadInt64()
    {
        Span<byte> buffer = stackalloc byte[8];
        _stream.ReadExactly(buffer);
        return _codec.ReadInt64(buffer);
    }

    public float ReadSingle()
    {
        Span<byte> buffer = stackalloc byte[4];
        _stream.ReadExactly(buffer);
        return _codec.ReadSingle(buffer);
    }

    public double ReadDouble()
    {
        Span<byte> buffer = stackalloc byte[8];
        _stream.ReadExactly(buffer);
        return _codec.ReadDouble(buffer);
    }

    public void ReadBytes(Span<byte> buffer) => _stream.ReadExactly(buffer);

    public byte[] ReadBytes(int len)
    {
        var buffer = new byte[len];
        _stream.ReadExactly(buffer);
        return buffer;
    }

    public byte[] ReadBytes(long len)
    {
        var buffer = new byte[len];
        _stream.ReadExactly(buffer);
        return buffer;
    }
}
