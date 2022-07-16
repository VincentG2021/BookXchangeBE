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
    public class EditionRepository : RepositoryBase<int, EditionEntity>, IEditionRepository
    {
        public EditionRepository(Connection connection) : base(connection, "Edition", "Id_Edition")
        {

        }


        protected override EditionEntity MapRecordToEntity(IDataRecord record)
        {
            return new EditionEntity()
            {
                IdEdition = (int)record[TableId],
                Isbn = (string)record["ISBN"],
                Parution = (DateTime)record["Parution"],
                Format = (string)record["Format"],
                IdLivre = (int)record["Id_Livre"]
            };
        }

        public override IEnumerable<EditionEntity> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Edition");

            return _Connection.ExecuteReader(cmd, MapRecordToEntity);
        }

        public override EditionEntity GetById(int id)
        {
            Command cmd = new Command("SELECT * FROM Edition WHERE Id_Edition = @Id_Edition");

            cmd.AddParameter("Id_Edition", id);

            return _Connection.ExecuteReader(cmd, MapRecordToEntity).SingleOrDefault();
        }

        public IEnumerable<EditionEntity> GetByLivre(int id)
        {
            Command cmd = new Command("SELECT E.* FROM Edition E JOIN Livre L ON E.Id_Livre = L.Id_Livre WHERE L.Id_Livre = @id");

            cmd.AddParameter("Id_Livre", id);

            return _Connection.ExecuteReader(cmd, MapRecordToEntity);
        }


        public override int Insert(EditionEntity entity)
        {
            Command cmd = new Command("INSERT INTO Edition (Isbn, Parution, Format, IdLivre)" +
                                    " OUTPUT inserted.Id_Edition" +
                                    " VALUES (@Isbn, @Parution, @Format, @IdLivre)");
            cmd.AddParameter("Isbn", entity.Isbn);
            cmd.AddParameter("Parution", entity.Parution);
            cmd.AddParameter("Format", entity.Format);
            cmd.AddParameter("IdLivre", entity.IdLivre);

            return (int)_Connection.ExecuteScalar(cmd);
        }
        public override bool Update(int id, EditionEntity entity)
        {
            Command cmd = new Command("UPDATE Edition SET Isbn = @Isbn, Parution = @Parution, Format = @Format, IdLivre = @IdLivre WHERE Id_Editon = @Id_Editon");
            cmd.AddParameter("Isbn", entity.Isbn);
            cmd.AddParameter("Parution", entity.Parution);
            cmd.AddParameter("Format", entity.Format);
            cmd.AddParameter("IdLivre", entity.IdLivre);

            cmd.AddParameter("Id_Editon", id);

            return _Connection.ExecuteNonQuery(cmd) == 1;
        }

        public override bool Delete(int id)
        {
            Command cmd = new Command("DELETE FROM Edition WHERE Id_Edition  = @Id_Edition");
            cmd.AddParameter("Id_Edition", id);

            return _Connection.ExecuteNonQuery(cmd) == 1;
        }


    }
}
