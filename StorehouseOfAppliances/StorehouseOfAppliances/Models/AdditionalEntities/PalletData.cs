using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorehouseOfAppliances.Models.AdditionalEntities
{
    public class PalletData
    {
        public int Id { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }

        public decimal Length { get; set; }

        public decimal? Volume { get; set; }

        public decimal Weigth { get; set; }
    }
}
