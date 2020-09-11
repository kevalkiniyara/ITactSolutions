using Abp.Data;
using Abp.EntityFrameworkCore;
using ITactDemo.EntityFrameworkCore.Repositories;
using ITactDemo.StudentModules;
using ITactDemo.StudentModules.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ITactDemo.EntityFrameworkCore.StudentModules
{
    public class StudentModuleRepository : ITactDemoRepositoryBase<StudentModule>, IStudentModuleRepository
    {
        
        private readonly IActiveTransactionProvider _transactionProvider;

        public StudentModuleRepository(IDbContextProvider<ITactDemoDbContext> dbContextProvider ,IActiveTransactionProvider transactionProvider)
            : base(dbContextProvider)
        {
            
            _transactionProvider = transactionProvider;
        }
        
        public async Task CreateStudentModule(StudentModule input)
        {
            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@StudentName",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Value = input.StudentName
                        },
                        new SqlParameter() {
                            ParameterName = "@Standard",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = input.Standard
                        },
                        new SqlParameter() {
                            ParameterName = "@Gender",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Value = input.Gender
                        },
                        new SqlParameter() {
                            ParameterName = "@CountryId",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Value = input.CountryId
                        },
                        new SqlParameter() {
                            ParameterName = "@StateId",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Value = input.StateId
                        },new SqlParameter() {
                            ParameterName = "@CityId",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Value = input.CityId
                        }
            };
           
            var command = CreateCommand("SP_Insert_Student", CommandType.StoredProcedure,
                param);
        }
        private DbCommand CreateCommand(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            EnsureConnectionOpen();
            var command = Context.Database.GetDbConnection().CreateCommand();

            command.CommandText = commandText;
            command.CommandType = commandType;
            command.Transaction = GetActiveTransaction();

            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }

            return command;
        }

        private void EnsureConnectionOpen()
        {
            var connection = Context.Database.GetDbConnection();

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

        private DbTransaction GetActiveTransaction()
        {
            return (DbTransaction)_transactionProvider.GetActiveTransaction(new ActiveTransactionProviderArgs
            {
                {"ContextType", typeof(ITactDemoDbContext) },
                {"MultiTenancySide", MultiTenancySide }
            });
        }
    }
}
