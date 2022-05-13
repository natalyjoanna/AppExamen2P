using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AppExamen2P.Data
{
    public static class Constants
    {
        // Se especifica de que forma se abrira el archivo SQLite mediante una constante
        public const SQLite.SQLiteOpenFlags Flags = SQLite.SQLiteOpenFlags.ReadWrite | SQLite.SQLiteOpenFlags.Create | SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                // Ruta donde se guardara el archivo SQLite
                string basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, "AppExamen2P.db3");
            }
        }
    }
}
