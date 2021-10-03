using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Servicos : BaseEntity
    {
        public string Descricao { get; set; }
        public double Valor { get; set; }



    }
}
