using System.Drawing;

namespace MonoState
{
    public interface IConfiguration
    {
        bool HasLocalDatabase { get; }

        string ProductName { get; }

        Color FavoriteColor { get; set; }

        string UserName { get; set; }
    }
}