namespace SHUNetMVC.Infrastructure.EntityFramework.Queries
{
    public class WorkerQuery : BaseCrudQuery
    {
        //public override string SelectPagedQuery => @"
        //    SELECT [EmployeeID]
        //      ,[LastName]
        //      ,[FirstName]
        //      ,[Title]
        //      ,[TitleOfCourtesy]
        //      ,[BirthDate]
        //      ,[HireDate]
        //      ,[Address]
        //      ,[City]
        //      ,[Region]
        //      ,[PostalCode]
        //      ,[Country]
        //      ,[HomePhone]
        //      ,[Extension]
        //      ,[Notes]
        //  FROM [dbo].[Workers]";

        public override string SelectPagedQuery => @"
                SELECT
                    [EmployeeID],
                    [LastName],
                    [FirstName],
                    [Title],
                    [TitleOfCourtesy],
                    [BirthDate],
                    [HireDate],
                    [Address],
                    [City],
                    [Region],
                    [PostalCode],
                    [Country],
                    [HomePhone],
                    [Extension],
                    [Notes],
                    CASE
                        WHEN ABS(CHECKSUM(NEWID())) % 4 = 0 THEN 'Aktif'
                        WHEN ABS(CHECKSUM(NEWID())) % 4 = 1 THEN 'Pensiun'
                        WHEN ABS(CHECKSUM(NEWID())) % 4 = 2 THEN 'Dipecat'
                        WHEN ABS(CHECKSUM(NEWID())) % 4 = 3 THEN 'Percobaan'
                        ELSE 'Resign'
                    END AS [EmployeeStatus]
                FROM
                [dbo].[Workers]";
        

        public override string CountQuery => @"
            select count(1) from [dbo].[Workers]";

        public override string LookupTextQuery => @"
            select d.FirstName 
            from [dbo].[Workers] d
            where d.EmployeeID = {0}";



    }
}
