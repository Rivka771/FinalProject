
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class ValunteerDAL
    {
        YedidimDBEntities DB = new YedidimDBEntities();

        public List<AssignedRequests> GetAssignedRequestsByIdVullenter(int Id)
        {
            return DB.AssignedRequests.Where(x => x.VolunteerID == Id).ToList();
        }
        public List<Volunteers> GetVolunteers()
        {
            return DB.Volunteers.ToList();
        }
        //part B ex1
        public int GetAllHoursHasLeft(int idV)
        {
            var idd = new SqlParameter
            {
                ParameterName = "@idV",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = idV,
            };
            var id = DB.Database.SqlQuery<int>("SELECT dbo.GetAllHoursHasLeft(@idV)", idd).FirstOrDefault();
            return id;

        }
        //part B ex2
        public List<GetAvailableVolunteersByService_Result> GetAvailableVolunteersByService(int serviceId)
        {
            var param = new SqlParameter("@ServiceID", serviceId);
            var result = DB.Database.SqlQuery<GetAvailableVolunteersByService_Result>("EXEC GetAvailableVolunteersByService @ServiceID", param).ToList();
            return result;
        }
        //part B ex3
        public (int VolunteerCount, int ApprovedRequestCount) GetVolunteerAndRequestStatsForService(int serviceId)
        {
            var serviceIdParam = new SqlParameter
            {
                ParameterName = "@ServiceID",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = serviceId
            };

            var volunteerCountParam = new SqlParameter
            {
                ParameterName = "@VolunteerCount",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };

            var approvedCountParam = new SqlParameter
            {
                ParameterName = "@ApprovedRequestCount",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };

            DB.Database.SqlQuery<object>("EXEC GetVolunteerAndRequestStatsForService @ServiceID, @VolunteerCount OUTPUT, @ApprovedRequestCount OUTPUT",
                serviceIdParam, volunteerCountParam, approvedCountParam).ToList();

            int volunteerCount = volunteerCountParam.Value != DBNull.Value ? Convert.ToInt32(volunteerCountParam.Value) : 0;
            int approvedCount = approvedCountParam.Value != DBNull.Value ? Convert.ToInt32(approvedCountParam.Value) : 0;

            return (volunteerCount, approvedCount);
        }
        


        //part B ex5

        public int CountExclusiveServices(int idV)
        {
            var idParam = new SqlParameter
            {
                ParameterName = "@idV",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = idV
            };

            var count = DB.Database.SqlQuery<int>("SELECT dbo.CountExclusiveServices(@idV)", idParam).FirstOrDefault();
            return count;
        }
        //part B ex6
        public List<GetAllDetails_Result> GetAllDetails(int idV)
        {
            var idParam = new SqlParameter
            {
                ParameterName = "@idV",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = idV
            };

            var result = DB.Database
                .SqlQuery<GetAllDetails_Result>("EXEC GetAllDetails @idV", idParam)
                .ToList();

            return result;
        }
        //part B ex7
        public (int TotalHoursThisMonth, float AvgHoursLastMonth) GetVolunteerHours(int idV)
        {
            var idParam = new SqlParameter
            {
                ParameterName = "@idV",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = idV
            };

            var totalHoursParam = new SqlParameter
            {
                ParameterName = "@TotalHoursThisMonth",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };

            var avgHoursParam = new SqlParameter
            {
                ParameterName = "@AvgHoursLastMonth",
                SqlDbType = System.Data.SqlDbType.Float,
                Direction = System.Data.ParameterDirection.Output
            };

            DB.Database.SqlQuery<object>(
                "EXEC GetVolunteerHours @idV, @TotalHoursThisMonth OUTPUT, @AvgHoursLastMonth OUTPUT",
                idParam, totalHoursParam, avgHoursParam).ToList();

            int totalHours = totalHoursParam.Value != DBNull.Value ? Convert.ToInt32(totalHoursParam.Value) : 0;
            float avgHours = avgHoursParam.Value != DBNull.Value ? Convert.ToSingle(avgHoursParam.Value) : 0;

            return (totalHours, avgHours);
        }






    }

}
