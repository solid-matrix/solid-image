using SolidImage.Core.BytesCodec;

namespace SolidImage.Core.BytesReader;

public class LittleEndianBytesReader(Stream stream) : BaseBytesReader(stream, new LittleEndianBytesCodec()) { }