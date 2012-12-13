using System.Drawing;

namespace MonoState
{
    public class MonoStateConfiguration : IConfiguration
    {
        static MonoStateConfiguration()
        {
            hasLocalDatabase = false;
            productName = "producto";
            favoriteColor = Color.Blue;
            userName = "El chavo del 8";

        }

        #region Implementation of IConfiguration

        private static readonly bool hasLocalDatabase;

        private static readonly string productName;

        private static Color favoriteColor;

        private static string userName;

        public bool HasLocalDatabase
        {
            get { return hasLocalDatabase; }
        }

        public string ProductName
        {
            get { return productName; }
        }

        public Color FavoriteColor
        {
            get { return favoriteColor; }
            set { favoriteColor = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        #endregion
    }
}
