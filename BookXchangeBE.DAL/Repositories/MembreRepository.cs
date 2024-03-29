﻿using BookXchangeBE.DAL.Entities;
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
    public class MembreRepository : RepositoryBase<int, MembreEntity>, IMembreRepository
    {
        public MembreRepository(Connection connection) : base(connection, "Membre", "Id_Membre")
        {
        }

        protected override MembreEntity MapRecordToEntity(IDataRecord record)
        {
            return new MembreEntity()
            {
                IdMembre = (int)record[TableId],
                Pseudo = (string)record["Pseudo"],
                Email = (string)record["Email"],
                Prenom = record["Prenom"] is DBNull ? null : record["Prenom"].ToString(),
                Nom = record["Nom"] is DBNull ? null : record["Nom"].ToString(),
                PwdHash = null,
                Role = (int)record["Role"],
                Localisation = record["Localisation"] is DBNull ? null : record["Localisation"].ToString(),
                Image = record["Image"] is DBNull ? null : record["Image"].ToString(),
            };
        }

        public override IEnumerable<MembreEntity> GetAll()
        {
            Command cmd = new Command($"SELECT * FROM Membre");

            return _Connection.ExecuteReader(cmd, MapRecordToEntity);
        }

        public override int Insert(MembreEntity entity)
        {
            Command cmd = new Command($"INSERT INTO {TableName} (Pseudo, Email, Prenom, Nom, Pwd_Hash, Role)" +
                $" OUTPUT inserted.{TableId}" +
                $" VALUES (@Pseudo, @Email, @Prenom, @Nom, @Pwd_Hash, @Role)");

            cmd.AddParameter("Pseudo", entity.Pseudo);
            cmd.AddParameter("Email", entity.Email);
            cmd.AddParameter("Prenom", entity.Prenom);
            cmd.AddParameter("Nom", entity.Nom);
            cmd.AddParameter("Pwd_Hash", entity.PwdHash);
            cmd.AddParameter("Role", entity.Role);

            return (int)_Connection.ExecuteScalar(cmd);
        }

        public override bool Update(int id, MembreEntity entity)
        {
            // TODO Implementer la mise a jour du Member
            throw new NotImplementedException();
        }

        public string? GetPasswordHash(string pseudo)
        {
            Command cmd = new Command($"SELECT Pwd_Hash FROM {TableName} WHERE Pseudo = @Pseudo");
            cmd.AddParameter("Pseudo", pseudo);

            return _Connection.ExecuteScalar(cmd)?.ToString();
        }

        public bool CheckMemberExists(string pseudo, string email)
        {
            Command cmd = new Command($"SELECT COUNT(*) FROM {TableName} WHERE Pseudo = @Pseudo OR Email = @email");
            cmd.AddParameter("Pseudo", pseudo);
            cmd.AddParameter("Email", email);

            return ((int)_Connection.ExecuteScalar(cmd)) == 1;
        }

        public override MembreEntity GetById(int id)
        {
            Command cmd = new Command($"SELECT Id_Membre, Pseudo, Email, Prenom, Nom, Role, Localisation, Image FROM Membre WHERE Id_Membre = @Id_Membre");
            cmd.AddParameter("Id_Membre", id);

            return _Connection.ExecuteReader(cmd, MapRecordToEntity).SingleOrDefault();
        }

        public virtual MembreEntity GetByPseudo(string pseudo)
        {
            Command cmd = new Command($"SELECT * FROM {TableName} WHERE Pseudo = @Pseudo");
            cmd.AddParameter("Pseudo", pseudo);

            return _Connection.ExecuteReader(cmd, MapRecordToEntity).SingleOrDefault();
        }

        public virtual MembreEntity GetConnectedMember(string pseudo)
        {
            Command cmd = new Command($"SELECT * FROM {TableName} WHERE Pseudo = @Pseudo");
            cmd.AddParameter("Pseudo", pseudo);

            return _Connection.ExecuteReader(cmd, MapRecordToEntity).SingleOrDefault();
        }

        public bool UpdateImage(int id, string image)
        {
            Command cmd = new Command($" UPDATE Membre SET Image = @Image" +
               $" OUTPUT inserted.Image" +
               $" WHERE Id_Membre = @Id_Membre;"
               );

            cmd.AddParameter("Image", image);
            cmd.AddParameter("Id_Membre", id);

            return _Connection.ExecuteNonQuery(cmd) == 1;
        }
    }
}
