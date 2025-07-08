using System.Security.Cryptography;
using System.Text;

namespace Portify.API.Controllers;

// Utility for creating deterministic Guids (namespace + name)
public static class GuidUtility
{
    public static readonly Guid UrlNamespace = new Guid("6ba7b811-9dad-11d1-80b4-00c04fd430c8");

    public static Guid Create(Guid namespaceId, string name)
    {
        // Convert namespace UUID to network order (MSB-first).
        byte[]? namespaceBytes = namespaceId.ToByteArray();
        SwapByteOrder(namespaceBytes);

        // Compute hash of namespace ID concatenated with the name.
        byte[]? nameBytes = Encoding.UTF8.GetBytes(name);
        byte[]? hash = SHA1.Create().ComputeHash(Combine(namespaceBytes, nameBytes));

        // Most bytes from hash, set version and variant bits.
        byte[]? newGuid = new byte[16];
        Array.Copy(hash, 0, newGuid, 0, 16);
        newGuid[6] = (byte)((newGuid[6] & 0x0F) | (5 << 4)); // Version 5
        newGuid[8] = (byte)((newGuid[8] & 0x3F) | 0x80); // Variant RFC 4122
        SwapByteOrder(newGuid);
        return new Guid(newGuid);
    }

    private static byte[] Combine(byte[] a, byte[] b)
    {
        byte[]? ret = new byte[a.Length + b.Length];
        Buffer.BlockCopy(a, 0, ret, 0, a.Length);
        Buffer.BlockCopy(b, 0, ret, a.Length, b.Length);
        return ret;
    }

    private static void SwapByteOrder(byte[] guid)
    {
        void Swap(int a, int b)
        { byte t = guid[a]; guid[a] = guid[b]; guid[b] = t; }
        Swap(0, 3);
        Swap(1, 2);
        Swap(4, 5);
        Swap(6, 7);
    }
}
