﻿using Microsoft.EntityFrameworkCore;
using QRMES.Entities;
using QRMES.Models;

namespace QRMES.Services
{
    public class PagedResult
    {
        public int TotalCount { get; set; }

        public int TotalPages { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public List<Product> Result { get; set; }

        public static async Task<PagedResult> FromAsync(IQueryable<Product> query, PageModel pageDto)
        {
            var pagedResult = new PagedResult();
            var totalCount = await query.CountAsync();
            pagedResult.TotalCount = totalCount;

            pagedResult.Result = await Paginate(query, pageDto).ToListAsync();
            pagedResult.PageNumber = pageDto.PageNumber;
            pagedResult.PageSize = pageDto.PageSize;
            pagedResult.TotalPages = (totalCount / pagedResult.PageSize) + (totalCount % pagedResult.PageSize == 0 ? 0 : 1);

            return pagedResult;
        }

        private static IQueryable<Product> Paginate(IQueryable<Product> query, PageModel pageDto)
        {
            return query.OrderByDescending(x => x.RegistrationDate).Skip((pageDto.PageNumber - 1) * pageDto.PageSize).Take(pageDto.PageSize);
        }
    }
}
