﻿using POS.Domain.Entities;

namespace POS.Infraestructure.Commons.Bases.Response
{
    public class BaseEntityResponse<T>
    {
        public int? TotalRecord { get; set; }
        public List<T>? Items { get; set; }

    }
}
