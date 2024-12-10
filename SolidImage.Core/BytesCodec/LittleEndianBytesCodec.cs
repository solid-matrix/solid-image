using System.Buffers.Binary;

namespace SolidImage.Core.BytesCodec;

public class LittleEndianBytesCodec : IBytesCodec
{
    public ushort ReadUInt16(ReadOnlySpan<byte> source) => BinaryPrimitives.ReadUInt16LittleEndian(source);
    public uint ReadUInt32(ReadOnlySpan<byte> source) => BinaryPrimitives.ReadUInt32LittleEndian(source);
    public ulong ReadUInt64(ReadOnlySpan<byte> source) => BinaryPrimitives.ReadUInt64LittleEndian(source);
    public short ReadInt16(ReadOnlySpan<byte> source) => BinaryPrimitives.ReadInt16LittleEndian(source);
    public int ReadInt32(ReadOnlySpan<byte> source) => BinaryPrimitives.ReadInt32LittleEndian(source);
    public long ReadInt64(ReadOnlySpan<byte> source) => BinaryPrimitives.ReadInt64LittleEndian(source);
    public float ReadSingle(ReadOnlySpan<byte> source) => BinaryPrimitives.ReadSingleLittleEndian(source);
    public double ReadDouble(ReadOnlySpan<byte> source) => BinaryPrimitives.ReadDoubleLittleEndian(source);
    public void WriteUInt16(Span<byte> destination, ushort value) => BinaryPrimitives.WriteUInt16LittleEndian(destination, value);
    public void WriteUInt32(Span<byte> destination, uint value) => BinaryPrimitives.WriteUInt32LittleEndian(destination, value);
    public void WriteUInt64(Span<byte> destination, ulong value) => BinaryPrimitives.WriteUInt64LittleEndian(destination, value);
    public void WriteInt16(Span<byte> destination, short value) => BinaryPrimitives.WriteInt16LittleEndian(destination, value);
    public void WriteInt32(Span<byte> destination, int value) => BinaryPrimitives.WriteInt32LittleEndian(destination, value);
    public void WriteInt64(Span<byte> destination, long value) => BinaryPrimitives.WriteInt64LittleEndian(destination, value);
    public void WriteSingle(Span<byte> destination, float value) => BinaryPrimitives.WriteSingleLittleEndian(destination, value);
    public void WriteDouble(Span<byte> destination, double value) => BinaryPrimitives.WriteDoubleLittleEndian(destination, value);
}
