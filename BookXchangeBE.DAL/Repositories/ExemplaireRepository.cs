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

                IdLivre = (int)record["Id_Livre"],
                Titre = (string)record["Titre"],
                Auteur = (string)record["Auteur"],
                Synopsis = (string)record["Synopsis"],

                Isbn = (string)record["ISBN"],
                Parution = (DateTime)record["Parution"],
                Format = (string)record["Format"]

            };
        }

        public override IEnumerable<ExemplaireEntity> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Exemplaire Ex" +
                " JOIN Membre AS M ON Ex.Id_Membre = M.Id_Membre" +
                " JOIN Edition AS Ed ON Ex.Id_Edition = Ed.Id_Edition" +
                " JOIN Livre AS L ON Ed.Id_Livre = L.Id_Livre");

            return _Connection.ExecuteReader(cmd, MapRecordToEntity);
        }

        public override ExemplaireEntity GetById(int id)
        {
            Command cmd = new Command("SELECT * FROM Exemplaire WHERE Id_Exemplaire = @Id_Exemplaire");

            cmd.AddParameter("Id_Exemplaire", id);

            return _Connection.ExecuteReader(cmd, MapRecordToEntity).SingleOrDefault();
        }

        public IEnumerable<ExemplaireEntity> GetByMembre(int id)
        {
            Command cmd = new Command("SELECT M.Id_Membre, Ex.Id_Exemplaire, Ed.Id_Edition, L.Id_Livre, L.Titre, L.Auteur, L.Synopsis, Ed.ISBN, Ed.Parution, Ed.Format" +
                " FROM Exemplaire Ex" +
                " JOIN Membre AS M ON Ex.Id_Membre = M.Id_Membre" +
                " JOIN Edition AS Ed ON Ex.Id_Edition = Ed.Id_Edition" +
                " JOIN Livre AS L ON Ed.Id_Livre = L.Id_Livre" +
                " WHERE M.Id_Membre = @Id_Membre");

            cmd.AddParameter("Id_Membre", id);

            return _Connection.ExecuteReader(cmd, MapRecordToEntity);
        }

        public IEnumerable<ExemplaireEntity> GetByEdition(int id)
        {
            Command cmd = new Command("SELECT M.Id_Membre, Ex.Id_Exemplaire, Ed.Id_Edition, L.Id_Livre, L.Titre, L.Auteur, L.Synopsis, Ed.ISBN, Ed.Parution, Ed.Format" +
                " FROM Exemplaire Ex" +
                " JOIN Membre AS M ON Ex.Id_Membre = M.Id_Membre" +
                " JOIN Edition AS Ed ON Ex.Id_Edition = Ed.Id_Edition" +
                " JOIN Livre AS L ON Ed.Id_Livre = L.Id_Livre" +
                " WHERE Ex.Id_Edition = @Id_Edition");

            cmd.AddParameter("Id_Edition", id);

            return _Connection.ExecuteReader(cmd, MapRecordToEntity);
        }

        public IEnumerable<ExemplaireEntity> GetByLivre(int id)
        {
            Command cmd = new Command("SELECT M.Id_Membre, Ex.Id_Exemplaire, Ed.Id_Edition, L.Id_Livre, L.Titre, L.Auteur, L.Synopsis, Ed.ISBN, Ed.Parution, Ed.Format" +
                " FROM Exemplaire Ex" +
                " JOIN Membre AS M ON Ex.Id_Membre = M.Id_Membre" +
                " JOIN Edition AS Ed ON Ex.Id_Edition = Ed.Id_Edition" +
                " JOIN Livre AS L ON Ed.Id_Livre = L.Id_Livre" +
                " WHERE L.Id_Livre = @Id_Livre");

            cmd.AddParameter("Id_Livre", id);

            return _Connection.ExecuteReader(cmd, MapRecordToEntity);
        }

        public int CreateExemplaire(ExemplaireEntity entity)
        {
            Command cmd = new Command("DECLARE @insert_Livre_log TABLE (opIdLivre INT); " +
                                       " DECLARE @insert_Edition_log TABLE (opIdEdition INT); " +
                                       " DECLARE @insertedIdLivre INT; " +
                                       " DECLARE @insertedIdEdition INT; " +
                                       
                                       " INSERT INTO Livre(Titre, Auteur, Synopsis) " +
                                       " OUTPUT inserted.Id_Livre INTO @insert_Livre_log " +
                                       " VALUES(@Titre, @Auteur, @Synopsis); " +
                                       " SET @insertedIdLivre = (SELECT opIdLivre FROM @insert_Livre_log); " +
                                       
                                       " INSERT INTO Edition(ISBN, Parution, Format, Id_Livre) " +
                                       " OUTPUT inserted.Id_Edition INTO @insert_Edition_log " +
                                       " VALUES(@Isbn, @Parution, @Format, @insertedIdLivre); " +
                                       " SET @insertedIdEdition = (SELECT opIdEdition FROM @insert_Edition_log); " +
                                       
                                       " INSERT INTO Exemplaire(Id_Membre, Id_Edition) " +
                                    " OUTPUT inserted.Id_Exemplaire" +
                                    " VALUES (@Id_Membre, @insertedIdEdition)");
            cmd.AddParameter("Id_Membre", entity.IdMembre);
            cmd.AddParameter("Titre", entity.Titre);
            cmd.AddParameter("Auteur", entity.Auteur);
            cmd.AddParameter("Synopsis", entity.Synopsis);

            cmd.AddParameter("Isbn", entity.Isbn);
            cmd.AddParameter("Parution", entity.Parution);
            cmd.AddParameter("Format", entity.Format);

            cmd.AddParameter("Id_Edition", entity.IdEdition);

            return (int)_Connection.ExecuteScalar(cmd);
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
