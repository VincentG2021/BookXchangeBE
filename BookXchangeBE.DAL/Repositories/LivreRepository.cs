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
    public class LivreRepository : RepositoryBase<int, LivreEntity>, ILivreRepository
    {
        public LivreRepository(Connection connection) : base(connection, "Livre", "Id_Livre")
        {

        }


        protected override LivreEntity MapRecordToEntity(IDataRecord record)
        {
            return new LivreEntity()
            {
                IdLivre = (int)record[TableId],
                Titre = (string)record["Titre"],
                Auteur = (string)record["Auteur"],
                Synopsis = (string)record["Synopsis"],
            };
        }

        public override IEnumerable<LivreEntity> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Livre");

            return _Connection.ExecuteReader(cmd, MapRecordToEntity);
        }

        public override LivreEntity GetById(int id)
        {
            Command cmd = new Command("SELECT * FROM Livre WHERE Id_Livre = @Id_Livre");

            cmd.AddParameter("Id_Livre", id);

            return _Connection.ExecuteReader(cmd, MapRecordToEntity).SingleOrDefault();
        }

        public IEnumerable<LivreEntity> GetByCategorie(int id)
        {
            Command cmd = new Command("SELECT C.* FROM Livre C JOIN Categorie G ON C.Id_Categorie = G.Id_Categorie WHERE G.Id_Categorie = @id");

            cmd.AddParameter("Id_Categorie", id);

            return _Connection.ExecuteReader(cmd, MapRecordToEntity);
        }


        public override int Insert(LivreEntity entity)
        {
            Command cmd = new Command("INSERT INTO Livre (Titre, Auteur, Synopsis)" +
                                    " OUTPUT inserted.Id_Livre" +
                                    " VALUES (@Titre, @Auteur, @Synopsis)");
            cmd.AddParameter("Titre", entity.Titre);
            cmd.AddParameter("Auteur", entity.Auteur);
            cmd.AddParameter("Synopsis", entity.Synopsis);

            return (int)_Connection.ExecuteScalar(cmd);
        }
        public override bool Update(int id, LivreEntity entity)
        {
            Command cmd = new Command("UPDATE Livre SET Titre = @Titre, Auteur = @Auteur, Synopsis = @Synopsis WHERE Id_Livre = @Id_Livre");
            cmd.AddParameter("Titre", entity.Titre);
            cmd.AddParameter("Auteur", entity.Auteur);
            cmd.AddParameter("Synopsis", entity.Synopsis);

            cmd.AddParameter("Id_Livre", id);

            return _Connection.ExecuteNonQuery(cmd) == 1;
        }

        public override bool Delete(int id)
        {
            Command cmd = new Command("DELETE FROM Livre WHERE Id_Livre  = @Id_Livre");
            cmd.AddParameter("Id_Livre", id);

            return _Connection.ExecuteNonQuery(cmd) == 1;
        }

    }
}
