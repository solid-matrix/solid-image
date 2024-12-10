using SolidImage.Core.BytesCodec;

namespace SolidImage.Core.BytesReader;

public class BigEndianBytesReader(Stream stream) : BaseBytesReader(stream, new BigEndianBytesCodec()) { }
