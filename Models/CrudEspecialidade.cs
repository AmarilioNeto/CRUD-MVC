using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Academia_DKP.Models;

namespace Academia_DKP.Models
{
    public class CrudEspecialidade
    {
        public string ConexaoBanco = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=dbMedicos;Data Source=DESKTOP-HJGK58T\SQLEXPRESS";

        public SqlConnection conexaoSQL;
        SqlCommand command;

        public void InserirEspecialidade(Especialidade especialidade)
        {
            if (especialidade.numbool == true)
            {

                especialidade.Ativa = 1;

            }
            else
            {
                especialidade.Ativa = 0;
            }

            conexaoSQL = new SqlConnection(ConexaoBanco);
            command = conexaoSQL.CreateCommand();
            command.CommandText = @" insert into tblEspecialidade (decricacaoEspecialidade, Ativa) 
                                  values
                                  ('" + especialidade.descricaoEspecialidade + "',"
                                   + "" + especialidade.Ativa + "" + ")";

            conexaoSQL.Open();

            command.ExecuteNonQuery();
            conexaoSQL.Close();

        }
        public List<Especialidade> ObterEspecialidades()
        {
            List<Especialidade> lstespecialidades = new List<Especialidade>();
            conexaoSQL = new SqlConnection(ConexaoBanco);
            command = conexaoSQL.CreateCommand();
            command.CommandText = @"select * from tblEspecialidade";
            conexaoSQL.Open();

            SqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                Especialidade especialidade = new Especialidade();
                especialidade.idEspecialidade = Convert.ToInt32(dr["idEspecialidade"]);
                especialidade.descricaoEspecialidade = dr["decricacaoEspecialidade"].ToString();
                especialidade.Ativa = Convert.ToInt32(dr["Ativa"]);
                string numstring = "" + especialidade.Ativa;
                if (numstring == "1")
                {
                    especialidade.numbool = true;
                    especialidade.numString = "Sim";

                }
                else
                {
                    especialidade.numbool = false;
                    especialidade.numString = "Não";
                }
                lstespecialidades.Add(especialidade);
            };
            dr.Close();
            conexaoSQL.Close();
            return lstespecialidades;
        }

        public Especialidade DeleteEspecialidade(int id)
        {
            Especialidade especialidade = new Especialidade();
            conexaoSQL = new SqlConnection(ConexaoBanco);
            command = conexaoSQL.CreateCommand();
            command.CommandText = @" delete  from tblEspecialidade where idEspecialidade = " + id;
            conexaoSQL.Open();
            command.ExecuteNonQuery();
            conexaoSQL.Close();

            return especialidade;
        }

        public Especialidade ObterEspecialidadeId(int id)
        {

            conexaoSQL = new SqlConnection(ConexaoBanco);
            command = conexaoSQL.CreateCommand();
            command.CommandText = @"select * from tblEspecialidade where idEspecialidade = " + id;
            conexaoSQL.Open();

            SqlDataReader dr = command.ExecuteReader();

            dr.Read();

            Especialidade especialidade = new Especialidade();
            especialidade.idEspecialidade = Convert.ToInt32(dr["idEspecialidade"]);
            especialidade.descricaoEspecialidade = dr["decricacaoEspecialidade"].ToString();
            especialidade.Ativa = Convert.ToInt32(dr["Ativa"]);
            string numstring = "" + especialidade.Ativa;
            if (numstring == "1")
            {
                especialidade.numbool = true;
                especialidade.numString = "Sim";
            }
            else
            {
                especialidade.numbool = false;
                especialidade.numString = "Não";
            }

            dr.Close();
            conexaoSQL.Close();
            return especialidade;

        }
        public Especialidade UpdateEspecialidade(Especialidade especialidade)
        {
            if(especialidade.numbool == true)
            {
                
                especialidade.Ativa = 1;
            }
            else
            {
                especialidade.Ativa = 0;
            }
                    
            conexaoSQL = new SqlConnection(ConexaoBanco);
            command = conexaoSQL.CreateCommand();
            command.CommandText = @"update tblEspecialidade set 
            decricacaoEspecialidade = '" + especialidade.descricaoEspecialidade + "',"
             + "Ativa =" + especialidade.Ativa + "" + " where idEspecialidade = " + especialidade.idEspecialidade;
            conexaoSQL.Open();
            command.ExecuteNonQuery();
            conexaoSQL.Close();

            return especialidade;
        }
       
    }
}