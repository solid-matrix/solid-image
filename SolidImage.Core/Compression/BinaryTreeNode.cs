namespace SolidImage.Core.Compression;

public class BinaryTreeNode<T>(T value) where T : class
{
    public T Value { get; set; } = value;

    public BinaryTreeNode<T>? Left { get; set; }

    public BinaryTreeNode<T>? Right { get; set; }
}
