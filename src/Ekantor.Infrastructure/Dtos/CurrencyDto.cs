using System;
using System.Collections.Generic;

namespace Exchange.Infrastructure.Dtos
{
    public class CurrenciesDto
    {
        public DateTime PublicationDate { get; set; }
        public List<CurrencyItemDto> Items { get; set; }
    }
}