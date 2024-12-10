namespace SolidImage.Core.BytesCodec;

public interface IBytesCodec
{
    ushort ReadUInt16(ReadOnlySpan<byte> source);
    uint ReadUInt32(ReadOnlySpan<byte> source);
    ulong ReadUInt64(ReadOnlySpan<byte> source);
    short ReadInt16(ReadOnlySpan<byte> source);
    int ReadInt32(ReadOnlySpan<byte> source);
    long ReadInt64(ReadOnlySpan<byte> source);
    float ReadSingle(ReadOnlySpan<byte> source);
    double ReadDouble(ReadOnlySpan<byte> source);
    void WriteUInt16(Span<byte> destination, ushort value);
    void WriteUInt32(Span<byte> destination, uint value);
    void WriteUInt64(Span<byte> destination, ulong value);
    void WriteInt16(Span<byte> destination, short value);
    void WriteInt32(Span<byte> destination, int value);
    void WriteInt64(Span<byte> destination, long value);
    void WriteSingle(Span<byte> destination, float value);
    void WriteDouble(Span<byte> destination, double value);
}
