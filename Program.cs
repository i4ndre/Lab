using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    internal class Program
    {
        static string[] codigos = { "OC - 101", "OC - 102", "OC - 103", "OC - 104", "OC - 105", "OC - 106" };
        static string[] provedores = { "TechCorp1", "LogiExpress", "InsumosGlobal", "TechCorp2", "AlfaSumi", "ServiRedes" };
        static double[] precio_unit = { 150.0, 450.0, 80.0, 1200.0, 25.0, 600.0 };
        static double[] cantidad = { 10, 5, 20, 2, 50, 3 };
        static double[] Montos = new double[codigos.Length];

        static void mostrardatos()
        {
            Console.WriteLine("|======================CONTROL DE ORDENES========================|");
            Console.WriteLine("Código:\t\t|Proveedor:\t\t|Precio_unit\t|Cantidad:");
            
            for (int i = 0 ; i < codigos.Length; i++)
            {
                Console.WriteLine($"{codigos[i]}\t|{provedores[i]}\t\t|{precio_unit[i]}\t\t|{cantidad[i]}");
            }
            Console.WriteLine("|=================================================================|");
        }
        static public void validar_datos(double precio, double cantidad)
        {
            if (precio < 0)
            {
                Console.WriteLine("El precio no puede ser negativo.");
            }
            else             {
                Console.WriteLine("El precio es válido.");
            }
            if (cantidad < 0)
            {
                Console.WriteLine("La cantidad no puede ser negativa.");
            }
            else             {
                Console.WriteLine("La cantidad es válida.");
            }
        }
        static void acumulador_y_contadores()
        {
            double sumaMontos = 0;
            int contador = 0;
            for (int i = 0; i < codigos.Length; i++)
            {
                Montos [i] = precio_unit[i] * cantidad[i];
                sumaMontos += Montos[i];
                if (Montos[i] > 1000)
                {
                    contador++;
                }
            }
            algoritmo_de_ordenamientodirec(sumaMontos, contador);
        }
        static void algoritmo_de_ordenamientodirec(double sumaMontos, int contador)
        {
            for (int i = 0; i < precio_unit.Length - 1; i++)
            {
                for (int j = i + 1; j < precio_unit.Length; j++)
                {
                    if (precio_unit[i] > precio_unit[j])
                    {
                        
                        double tempPrecio = precio_unit[i];
                        precio_unit[i] = precio_unit[j];
                        precio_unit[j] = tempPrecio;
                        
                        string tempCodigo = codigos[i];
                        codigos[i] = codigos[j];
                        codigos[j] = tempCodigo;
                        
                        string tempProveedor = provedores[i];
                        provedores[i] = provedores[j];
                        provedores[j] = tempProveedor;
                        
                        double tempCantidad = cantidad[i];
                        cantidad[i] = cantidad[j];
                        cantidad[j] = tempCantidad;
                    }
                }
            }
        }
        static public void busqueda(string codigoBuscado)
        {
            bool encontrado = false;
            for (int i = 0; i < codigos.Length; i++)
            {
                if (codigos[i] == codigoBuscado)
                {
                    Console.WriteLine($"Código: {codigos[i]}, Proveedor: {provedores[i]}, Precio Unitario: {precio_unit[i]}, Cantidad: {cantidad[i]}");
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("Código no encontrado.");
            }
        }

        static void Main(string[] args)
        {
            validar_datos(precio_unit[0], cantidad[0]);
            mostrardatos();
            acumulador_y_contadores();
            algoritmo_de_ordenamientodirec(0, 0);
            Console.WriteLine("PRUEBA DE BUSQUEDA:");
            Console.WriteLine("|=========================================================================|");
            busqueda( "OC - 104");
            Console.WriteLine("|=========================================================================|");
        }
    }
}
