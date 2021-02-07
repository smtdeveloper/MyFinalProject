using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class ProduckDetailDto : IDto
    {
        public int ProduckId { get; set; }
        public string ProduckName { get; set; }

        public string CategoryName { get; set; }
        public short UnitsInStock { get; set; }

       
    }
}
