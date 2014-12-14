using System.Data.Entity;
using System.Threading.Tasks;
using LocalAccountsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace LocalAccountsApp.Services
{
    public class E2CInstanceService
    {
        private ApplicationDbContext db;
        private Pagination pagination;
        private ElasticCloudDataModel elasticCloudDataModel;

        public E2CInstanceService(ApplicationDbContext db)
        {
            this.db = db;
            this.pagination = new Pagination();
            this.elasticCloudDataModel = new ElasticCloudDataModel();
        }

        public async Task<ElasticCloudDataModel> GetAllActiveEc2Instances(int pageNum, int pageSize)
        {
            int rowsCount;
            var query = db.Ec2Instances.Where(a => a.IsActive).OrderBy(a => a.Id);
            Task<ElasticCloudDataModel> pageData = GetPagedResults(pageNum, pageSize, query);
            return await pageData;
        }

        private async Task<ElasticCloudDataModel> GetPagedResults(int pageNum, int pageSize, IOrderedQueryable<ElasticCloudViewModel> query)
        {
            pagination.PageNum = pageNum;
            pagination.PageSize = pageSize;
            var pageData = Pagination.PagedResult(query, pagination);
            elasticCloudDataModel.ElasticCloudViewModel = await pageData.ToListAsync();
            elasticCloudDataModel.Pagination = pagination;
            return elasticCloudDataModel;
        }

        //private static IQueryable<ElasticCloudViewModel> PagedResult(IQueryable<ElasticCloudViewModel> query, int pageNum, int pageSize, out int rowsCount)
        //{
        //    if (pageSize <= 0) pageSize = 2;

        //    //Total result count
        //    rowsCount = query.Count();

        //    //If page number should be > 0 else set to first page
        //    if (rowsCount <= pageSize || pageNum <= 0) pageNum = 1;

        //    //Calculate nunber of rows to skip on pagesize
        //    int excludedRows = (pageNum - 1) * pageSize;

        //    //Skip the required rows for the current page and take the next records of pagesize count
        //    return query.Skip(excludedRows).Take(pageSize);
        //}
    }
}