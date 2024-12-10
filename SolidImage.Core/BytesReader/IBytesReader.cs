namespace SolidImage.Core.BytesReader;

public interface IBytesReader
{
    ushort ReadUInt16();

    uint ReadUInt32();

    ulong ReadUInt64();

    short ReadInt16();

    int ReadInt32();

    long ReadInt64();

    float ReadSingle();

    double ReadDouble();

    public void ReadBytes(Span<byte> buffer);

    public byte[] ReadBytes(int len);

    public byte[] ReadBytes(long len);
}
