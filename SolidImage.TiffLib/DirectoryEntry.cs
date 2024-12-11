using System.Runtime.InteropServices;

namespace SolidImage.TiffLib;

public unsafe class DirectoryEntry : IDisposable
{
    public ushort TagCode { get; internal set; }

    public ushort TypeCode { get; internal set; }

    public uint Count { get; internal set; }

    public nint Data { get; internal set; } = default!;

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        Marshal.FreeHGlobal(Data);
    }
}
