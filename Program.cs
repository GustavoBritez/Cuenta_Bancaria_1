using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleAPP
{
    internal class Program
    {
        static void Main(string[] args)
        {

            CuentaBancaria cuenta_1 = new CuentaBancaria();

            cuenta_1.Inicio();
        }
    }
    
    class CuentaBancaria
    {
        private string nombre;
        private string apellidos;
        private string dni;
        private double saldo;
        public CuentaBancaria()
        {
            nombre = "None";
            apellidos = "None";
            dni = "None";
            saldo = 0;
        }

        public void menu()
        {
            int n;
            double deposito;
            do
            {
                Console.WriteLine(" | Bienvenido");
                Console.WriteLine(" | [0] Terminar operacion");
                Console.WriteLine(" | [1] Deposito");
                Console.WriteLine(" | [2] Retiro");
                Console.WriteLine(" | [3] Consulta Saldo");
                n = Convert.ToInt32(Console.ReadLine());
            switch(n)
            {
                case 0:
                          Console.WriteLine("\n Gracias, vuelva pronto");

                     break;
                case 1:
                    Console.WriteLine("\n Ingrese la cantidad de dinero que quiere depositar");
                    deposito = Convert.ToDouble(Console.ReadLine());
                        saldo = deposito + saldo;
                        Console.WriteLine(saldo);
                    break;
                case 2:
                    Console.WriteLine("\n Ingrese la cantidad de dinero que quiere retirar");
                        deposito = Convert.ToDouble(Console.ReadLine());
                        while( deposito > saldo)
                        {
                            Console.WriteLine("\n No puede retirar {0}", deposito);
                            Console.WriteLine("Ingrese un nuevo monto menor a su saldo  = {0}", saldo);
                            deposito = Convert.ToDouble(Console.ReadLine());

                        }
                        saldo = saldo - deposito;
                        Console.WriteLine("\n -> Su nuevo saldo es {0} <-", saldo);
                    break;
                    
                case 3:
                    Console.WriteLine("\n Su saldo es = {0}", saldo);
                    break;
            }

            } while (n != 0) ;


        }


        public void Inicio()
        {
            Console.WriteLine(" | [1] Registrar Cuenta ");
            Console.WriteLine(" | [2] Iniciar Sesion");
            Console.WriteLine(" | [3] Borrar Cuenta");
            Console.WriteLine(" | [4] Cancelar Operacion");
            int n = Convert.ToInt32(Console.ReadLine());

            while(n < 1 || n > 4)
            {
                Console.WriteLine(" | -> OPCION INVALIDA, Elige una OPCION <- ");
                Console.WriteLine(" | [1] Registrar Cuenta ");
                Console.WriteLine(" | [2] Iniciar Sesion");
                ///Console.WriteLine(" | [3] Borrar Cuenta");
                Console.WriteLine(" | [4] Cancelar Operacion");
                n = Convert.ToInt32(Console.ReadLine());
            }

            switch(n)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine(" | Gracias por elegirnos");
                    Console.WriteLine(" | Complete los siguientes campos \n");

                    Console.WriteLine(" |           Registro");
                    Console.WriteLine(" | Ingrese NOMBRE de la cuenta");
                    nombre = Console.ReadLine();
                    Console.WriteLine(" | Ingrese APELLIDO de la cuenta");
                    apellidos = Console.ReadLine();
                    Console.WriteLine(" | Ingrese DNI de la cuenta");
                    dni = Console.ReadLine();
                    saldo = 500;
                    Console.Clear();
                    Console.WriteLine(" Su saldo bono por registrarse es de [ {0} ]", saldo);

                    menu();
                    break;
                case 2:
                    Console.WriteLine(" | Iniciar Sesion");
                    Console.WriteLine(" | Ingrese NOMBRE de la cuenta");
                    string ALT_nombre = Console.ReadLine();
                    Console.WriteLine(" | Ingrese APELLIDO de la cuenta");
                    string ALT_apellido = Console.ReadLine();
                    Console.WriteLine(" | Ingrese DNI de la cuenta ");
                    string ALT_DNI = Console.ReadLine();
                    bool resultado_ver = verificacion(this, ALT_nombre,ALT_apellido,ALT_DNI);
                    if (resultado_ver == true)
                    {
                        Console.Clear();
                        Console.WriteLine(" | Login con exito");
                        menu();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(" | Datos incorrectos");
                        Console.WriteLine(" | Operacion cancelada");
                    }
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine(" | Disponible proximamente");
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine(" | Operacion cancelada");

                    break;
            }
            
        }

        public bool verificacion( CuentaBancaria cuenta, string ALT_nombre, string ALT_apellido, string ALT_DNI)
        {
            bool x;

            if( (cuenta.MOD_apellido != ALT_nombre) || (cuenta.MOD_nombre != ALT_apellido) || (cuenta.MOD_DNI != ALT_DNI) )
            {
                Console.Clear();
                x = false;
                Console.WriteLine(" | Datos incorrectos, verifique la informacion ingresada");
            }
            else
            {
                x = true;
            }
            return x;
        }



        public string MOD_nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string MOD_apellido
        {
            get { return apellidos; }
            set { apellidos = value; }
        }
        public string MOD_DNI
        {
            get { return dni; } 
            set { dni = value; }
        }


    }
 
}
