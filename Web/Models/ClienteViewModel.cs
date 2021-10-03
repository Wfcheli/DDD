using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        [DisplayName("Nome:")]
        public string Nome { get; set; }
        [DisplayName("Email:")]
        public string Email { get; set; }
        [DisplayName("Cpf:")]
        public string Cpf { get; set; }
    }
}
