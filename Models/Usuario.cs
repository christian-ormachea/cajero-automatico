using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cajero_automatico.Models
{
    internal class Usuario
    {
        public string Nombre { get; set; }
        public int Saldo {  get; set; }
        public List<int> Transacciones { get; set; }

        public Usuario(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ArgumentNullException("Error, ingrese nombres validos!");
            }
            Nombre = nombre;
            Saldo = 0;
            Transacciones = new List<int>();
        }

        public void Depositar(int montoADepositar)
        {
            Saldo += montoADepositar;
            Transacciones.Add(montoADepositar);
        }

        public void Retirar(int montoARetirar)
        {
            Saldo -= montoARetirar;
            montoARetirar = -montoARetirar;
            Transacciones.Add(montoARetirar);
        }
    }
}
