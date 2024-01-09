using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infraestructure.Commons.Bases.Request
{
    public class BaseFilterRequest :BasePaginationRequest
    {
        public int? NumFilter { get; set; } = null;
        public string? Textfilter { get; set; } = null;
        public int? StateFiler { get; set; } = null;
        public string? StartDate {  get; set; } = null;
        public string? EndDate { get; set;} = null;
        public bool? Download {  get; set; } = false;
    }
}
