using System.Buffers.Binary;

namespace SolidImage.Core.BytesCodec;

public class BigEndianBytesCodec : IBytesCodec
{
    public ushort ReadUInt16(ReadOnlySpan<byte> source) => BinaryPrimitives.ReadUInt16BigEndian(source);
    public uint ReadUInt32(ReadOnlySpan<byte> source) => BinaryPrimitives.ReadUInt32BigEndian(source);
    public ulong ReadUInt64(ReadOnlySpan<byte> source) => BinaryPrimitives.ReadUInt64BigEndian(source);
    public short ReadInt16(ReadOnlySpan<byte> source) => BinaryPrimitives.ReadInt16BigEndian(source);
    public int ReadInt32(ReadOnlySpan<byte> source) => BinaryPrimitives.ReadInt32BigEndian(source);
    public long ReadInt64(ReadOnlySpan<byte> source) => BinaryPrimitives.ReadInt64BigEndian(source);
    public float ReadSingle(ReadOnlySpan<byte> source) => BinaryPrimitives.ReadSingleBigEndian(source);
    public double ReadDouble(ReadOnlySpan<byte> source) => BinaryPrimitives.ReadDoubleBigEndian(source);
    public void WriteUInt16(Span<byte> destination, ushort value) => BinaryPrimitives.WriteUInt16BigEndian(destination, value);
    public void WriteUInt32(Span<byte> destination, uint value) => BinaryPrimitives.WriteUInt32BigEndian(destination, value);
    public void WriteUInt64(Span<byte> destination, ulong value) => BinaryPrimitives.WriteUInt64BigEndian(destination, value);
    public void WriteInt16(Span<byte> destination, short value) => BinaryPrimitives.WriteInt16BigEndian(destination, value);
    public void WriteInt32(Span<byte> destination, int value) => BinaryPrimitives.WriteInt32BigEndian(destination, value);
    public void WriteInt64(Span<byte> destination, long value) => BinaryPrimitives.WriteInt64BigEndian(destination, value);
    public void WriteSingle(Span<byte> destination, float value) => BinaryPrimitives.WriteSingleBigEndian(destination, value);
    public void WriteDouble(Span<byte> destination, double value) => BinaryPrimitives.WriteDoubleBigEndian(destination, value);
}
