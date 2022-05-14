using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consumption_Meter.Data.Interface;
using Consumption_Meter.Model;

namespace Consumption_Meter.Data
{
    public class ModuleData : IElementData
    {
        private readonly ISqlDatabaseAccess _databaseAccess;

        public ModuleData(ISqlDatabaseAccess databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }

        public async Task<List<Modul>> GetModuls()
        {
            string sql = "SELECT * FROM moduls";

            return await _databaseAccess.Execute<Modul>(sql);
        }
        public async Task<List<Modul>> GetDefaultModuls()
        {
            string sql = "SELECT * FROM moduls WHERE DefaultType = true";

            return await _databaseAccess.Execute<Modul>(sql);
        }
        public async Task<List<Modul>> GetNonDefaultModuls()
        {
            string sql = "SELECT * FROM moduls WHERE DefaultType = false";

            return await _databaseAccess.Execute<Modul>(sql);
        }

        public async Task<Modul> GetModulById(Modul modul)
        {
            string sql = "SELECT * FROM moduls WHERE Id = @Id";

            return await _databaseAccess.ExecuteSingle<Modul, Modul>(sql, modul);
        }
      

        public async Task InsertModul(Modul modul)
        {
            string sql = "insert into moduls (Id, Name, Description, Icon, CustomResPath, Hidden, RelatedComponentStr, DefaultType) values (@Id, @Name, @Description, @Icon, @CustomResPath, @Hidden, @RelatedComponentStr, @DefaultType)";
            await _databaseAccess.Execute<Modul, Modul>(sql, modul);

        }


        public async Task UpdateModul(Modul modul)
        {
            string sql = "UPDATE moduls SET Name = @Name, Description = @Description, Icon = @Icon, CustomResPath = @CustomResPath, Hidden = @Hidden, RelatedComponentStr = @RelatedComponentStr , DefaultType = @DefaultType WHERE Id = @Id";
            await _databaseAccess.Execute<Modul, Modul>(sql, modul);

        }

        public async Task DeleteModul(Modul modul)
        {
            string sql = "DELETE FROM moduls WHERE Id = @Id";
            await _databaseAccess.Execute<Modul, Modul>(sql, modul);

        }
    }
}
