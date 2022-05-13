using AppExamen2P.Extensions;
using AppExamen2P.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppExamen2P.Data
{
    public class GasStationDataBase
    {
        // Abrimos conexion con nuestro archivo de SQLite
        static readonly Lazy<SQLiteAsyncConnection> lazyInitalizer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        // Variable para regresar la conexion SQLite
        static SQLiteAsyncConnection DataBase => lazyInitalizer.Value;

        // Variable para idicar si la base de datos esta inicializada
        static bool isInitialized = false;

        // Constructor
        public GasStationDataBase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!isInitialized)
            {
                if (!DataBase.TableMappings.Any(m => m.MappedType.Name == typeof(GasStationModel).Name))
                {
                    await DataBase.CreateTablesAsync(CreateFlags.None, typeof(GasStationModel)).ConfigureAwait(false);
                    isInitialized = true;
                }
            }
        }

        // Metodos CRUD
        public Task<List<GasStationModel>> GetAllGasStationsAsync()
        {
            return DataBase.Table<GasStationModel>().ToListAsync();
        }

        public Task<GasStationModel> GetGasStationAsync(int id)
        {
            return DataBase.Table<GasStationModel>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<List<GasStationModel>> GetGasStationNotDoneAsync()
        {
            return DataBase.QueryAsync<GasStationModel>($"SELECT * FROM [{typeof(GasStationModel).Name}] WHERE [DONE] = 0");
        }

        public Task<List<GasStationModel>> GetGasStationDoneAsync()
        {
            return DataBase.QueryAsync<GasStationModel>($"SELECT * FROM [{typeof(GasStationModel).Name}] WHERE [DONE] = 1");
        }

        public Task<int> SaveGasStationAsync(GasStationModel model)
        {
            if (model.ID == 0)
            {
                // Crear
                return DataBase.InsertAsync(model);
            }
            else
            {
                // Actualizar
                return DataBase.UpdateAsync(model);
            }
        }

        public Task<int> DeleteGasStationAsync(GasStationModel model)
        {
            return DataBase.DeleteAsync(model);
        }
    }
}
