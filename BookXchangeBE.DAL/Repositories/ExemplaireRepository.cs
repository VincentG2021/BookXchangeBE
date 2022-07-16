using BookXchangeBE.DAL.Entities;
using BookXchangeBE.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Connections;

namespace BookXchangeBE.DAL.Repositories
{
    public class ExemplaireRepository : RepositoryBase<int, ExemplaireEntity>, IExemplaireRepository
    {
        public ExemplaireRepository(Connection connection) : base(connection, "Exemplaire", "Id_Exemplaire")
        {

        }


        protected override ExemplaireEntity MapRecordToEntity(IDataRecord record)
        {
            return new ExemplaireEntity()
            {
                IdExemplaire = (int)record[TableId],
                IdMembre = (int)record["Id_Membre"],
                IdEdition = (int)record["Id_Edition"],
            };
        }

        public override IEnumerable<ExemplaireEntity> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Exemplaire");

            return _Connection.ExecuteReader(cmd, MapRecordToEntity);
        }

        public override ExemplaireEntity GetById(int id)
        {
            Command cmd = new Command("SELECT * FROM Exemplaire WHERE Id_Exemplaire = @Id_Exemplaire");

            cmd.AddParameter("Id_Exemplaire", id);

            return _Connection.ExecuteReader(cmd, MapRecordToEntity).SingleOrDefault();
        }


        public override int Insert(ExemplaireEntity entity)
        {
            Command cmd = new Command("INSERT INTO Exemplaire (Id_Membre, Id_Edition)" +
                                    " OUTPUT inserted.Id_Exemplaire" +
                                    " VALUES (@IdMembre, @IdEdition)");
            cmd.AddParameter("Id_Membre", entity.IdMembre);
            cmd.AddParameter("Id_Edition", entity.IdEdition);

            return (int)_Connection.ExecuteScalar(cmd);
        }
        public override bool Update(int id, ExemplaireEntity entity)
        {
            Command cmd = new Command("UPDATE Exemplaire SET Id_Membre = @IdMembre, Id_Edition = @IdEdition WHERE Id_Exemplaire = @Id_Exemplaire");
            cmd.AddParameter("Id_Membre", entity.IdMembre);
            cmd.AddParameter("Id_Edition", entity.IdEdition);

            cmd.AddParameter("Id_Exemplaire", id);

            return _Connection.ExecuteNonQuery(cmd) == 1;
        }

        public override bool Delete(int id)
        {
            Command cmd = new Command("DELETE FROM Exemplaire WHERE Id_Exemplaire  = @Id_Exemplaire");
            cmd.AddParameter("Id_Exemplaire", id);

            return _Connection.ExecuteNonQuery(cmd) == 1;
        }

    }
}
