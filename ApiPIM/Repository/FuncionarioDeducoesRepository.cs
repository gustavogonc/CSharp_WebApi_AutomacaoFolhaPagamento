﻿using ApiPIM.Models;
using Microsoft.Data.SqlClient;

namespace ApiPIM.Repository
{
    public class FuncionarioDeducoesRepository
    {

        public List<FuncionarioDeducoes> ObterFuncionarioDeducoes()
        {
            string connectionString = @"Data Source=JESSICAOM-NB\MSSQLSERVER01;Initial Catalog=Folha_Pagamento;Integrated Security=True;Encrypt=False";

            List<FuncionarioDeducoes> funcionarioDeducoesList = new List<FuncionarioDeducoes>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"select f.nome_funcionario, f.cpf, f.cargo, f.departamento,
                                a.VR, a.VT, a.salario, a.mes
                                from tb_deducoes a
                                inner join tb_funcionario f on f.id_funcionario = a.id_funcionario";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FuncionarioDeducoes data = new FuncionarioDeducoes
                            {
                                NomeFuncionario = reader.GetString(0),
                                CPF = reader.GetString(1),
                                Cargo = reader.GetString(2),
                                Departamento = reader.GetString(3),
                                VR = reader.GetDecimal(4),
                                VT = reader.GetDecimal(5),
                                Salario = reader.GetDecimal(6),
                                mes = reader.GetInt32(7),
                            };
                            funcionarioDeducoesList.Add(data);
                        }
                    }
                }
            }

            return funcionarioDeducoesList;
        }

      
        public List<Funcionario> ObterFuncionariosBasicos()
        {
            string connectionString = @"Data Source=JESSICAOM-NB\MSSQLSERVER01;Initial Catalog=Folha_Pagamento;Integrated Security=True;Encrypt=False";

            List<Funcionario> funcionarios = new List<Funcionario>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT nome_funcionario, cpf FROM tb_funcionario";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Funcionario funcionario = new Funcionario
                            {
                                NomeFuncionario = reader.GetString(0),
                                CPF = reader.GetString(1)
                            };
                            funcionarios.Add(funcionario);
                        }
                    }
                }
            }

            return funcionarios;
        }

    }
}