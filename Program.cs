using System.ComponentModel.Design;
using cajero_automatico.Models;


class Program
{
    static List<Usuario> listaUsuarios = new List<Usuario>();
    public static void Main(string[] args)
    {
        
        int opcion;
        do
        {
            Console.WriteLine("Hola que tal, bienvenido al cajero automatico de Ormachea Christian");
            Console.WriteLine("Seleccione una de las opciones para consultar el estado de su cuenta: ");
            Console.WriteLine("1. Consultar saldo.");
            Console.WriteLine("2. Realizar depósitos.");
            Console.WriteLine("3. Realizar retiros.");
            Console.WriteLine("4. Ver el historial de transacciones.");
            Console.WriteLine("5. Salir del sistema");
            opcion = int.Parse(Console.ReadLine());
        } while (opcion != 5);

        switch (opcion) {
            case 1:
                Console.WriteLine("Ingrese el nombre del usuario que desea consultarle el saldo.");
                var nombre = Console.ReadLine();
                ConsultarSaldo(nombre);
                break;
            case 2:
                Console.WriteLine("Ingrese el nombre del usuario que desea depositarle un monto. ");
                nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el monto a depositar.");
                var monto = int.Parse(Console.ReadLine());
                DepositarA(nombre, monto);
                break;
            case 3:
                Console.WriteLine("Ingrese el nombre del usuario que desea retirarle un monto determinado.");
                nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el monto a retirar");
                monto = int.Parse(Console.ReadLine());
                RetirarA(nombre, monto);
                break;
            case 4:
                Console.WriteLine("Ingrese el nombre del usuario al que desea verle el historial de transacciones");
                nombre = Console.ReadLine();
                VerTransaccionesDe(nombre);
                break;
            default:
                Console.WriteLine("Error, ingrese una opcion valida");
                break;
        }
    }

    public static void ConsultarSaldo(string nombreDelUsuario)
    {
        Usuario usuarioEncontrado = BuscarUsuario(nombreDelUsuario);

        if (usuarioEncontrado != null)
        {
            Console.WriteLine($"El saldo del usuario {usuarioEncontrado.Nombre} es: {usuarioEncontrado.Saldo}");
        } 
        else
        {
            Console.WriteLine("Error, no se encontro el usuario!");
        }
        
    }


    public static void DepositarA(string nombreDelUsuario, int montoADepositar)
    {
        Usuario usuarioEncontrado = BuscarUsuario(nombreDelUsuario);

        if (usuarioEncontrado != null) {
            usuarioEncontrado.Depositar(montoADepositar);
    
        } else
        {
            Console.WriteLine("Error, no se encontro el usuario");
        }   
    }

    public static void RetirarA(string nombreDelUsuario, int montoARetirar)
    {
        Usuario usuarioEncontrado = BuscarUsuario(nombreDelUsuario);

        if (usuarioEncontrado != null)
        {
            usuarioEncontrado.Retirar(montoARetirar);

        } else
        {
            Console.WriteLine("Erorr, no se encontro el usuario");
        }
    }

    public static void VerTransaccionesDe(string nombreDelUsuario)
    {
        Usuario usuarioEncontrado = BuscarUsuario(nombreDelUsuario);

        if (usuarioEncontrado != null)
        {
            Console.WriteLine($"Las transacciones del usuario {usuarioEncontrado.Nombre} son: {usuarioEncontrado.Transacciones}");
        } else
        {
            Console.WriteLine("Error, no se encontro al usuario");
        }

    }

    public static Usuario BuscarUsuario(string nombreDelUsuario)
    {

        foreach (var usuario in listaUsuarios)
        {
            if (usuario.Nombre == nombreDelUsuario)
            {
                return usuario;
            }
        }
        return null;
    }
    
}
