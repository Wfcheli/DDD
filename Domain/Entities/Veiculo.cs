using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Veiculo : BaseEntity
    {
        public string Nome { get; set; }
        public string Marca { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }

    }
}
