using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocalAccountsApp.Models
{
    public class Pagination
    {
        public Pagination()
        {
            PageNum = 0;
            PageSize = 0;
            TotalPages = 0;
        }

        public int PageNum { get; set; }

        public int PageSize { get; set; }
        public int TotalPages { get; set; }

        public int TotalItems { get; set; }



        public static IQueryable<ElasticCloudViewModel> PagedResult(IQueryable<ElasticCloudViewModel> query, Pagination pagination)
        {
            if (pagination.PageSize <= 0) pagination.PageSize = 2;

            //Total result count
            int rowsCount = query.Count();

            pagination.TotalItems = rowsCount;
            pagination.TotalPages = rowsCount < 0 ? 1 : ((rowsCount - 1) / pagination.PageSize) + 1;

            //If page number should be > 0 else set to first page
            if (rowsCount <= pagination.PageSize || pagination.PageNum <= 0) pagination.PageNum = 1;

            //Calculate nunber of rows to skip on pagesize
            int excludedRows = (pagination.PageNum - 1) * pagination.PageSize;

            //Skip the required rows for the current page and take the next records of pagesize count
            return query.Skip(excludedRows).Take(pagination.PageSize);
        }
    }

}