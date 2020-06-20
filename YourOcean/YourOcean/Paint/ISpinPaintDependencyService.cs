using System;
using System.IO;
using System.Threading.Tasks;
namespace YourOcean.Paint
{
    public interface ISpinPaintDependencyService
    {
        Task<bool> SaveBitmap(byte[] bitmapData, string filename);
    }
}
