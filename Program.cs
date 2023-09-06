using System;
using System.Collections.Generic;
using System.Linq; 

namespace appDIstribuida
{
    // herencia 
    class Persona
    {
        public string Apellido { get; set;  }
        public string Nombre { get; set;  }
        public string NombreCompleto
        {
            get { return Apellido + "," + Nombre; }
        }
        public virtual void Saludar()
        {
            //PascalCasing diferencia con java es camelCase
            Console.WriteLine($"hola! soy una persona...  Me llamo: {NombreCompleto} y esto es un saludo!");
        }
        public Persona(string apellido, string nombre)
        {
            this.Apellido = apellido;
            this.Nombre = nombre; 
        }
        public Persona() { }
     
    }
    class Alumno : Persona
    {
        //atributo
        int legajo;


        // public int Legajo { get; set; }
        /*lo dejo asi, siempre y cuando no lo necesite usar de forma accesor o mutador  */

        //propiedad es el encapsulamiento  del atributo que nos permite escribir a nosotros 
        // codigo accesor y mutador hacia ese codigo 
        //de forma version resumida de get y det
        public int Legajo
        {
            get
            {
                return legajo;
            }
            set
            {
                if (value < 0) Console.WriteLine("no se puede Ingresar un legajo negativo"); 
                    
                legajo = value; 
            }
        } 



      
        public override void Saludar()
        {
            //PascalCasing diferencia con java es camelCase
            Console.WriteLine($"hola! soy un alumno...   Me llamo:  {NombreCompleto}  y mi legajo es {Legajo} y esto es un saludo!");
        }
        public Alumno(string apellido, string nombre , int legajo) : base(apellido, nombre)
        {
            this.Legajo = legajo; 
        }
        public  Alumno() { }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Persona> personas = new List<Persona>
            {
                new Persona("Simpson", "Homero"),
                new Persona("Simpson", "Lisa"),
                new Alumno("Simpson" , "Marge", 46297),
                new Persona("Simpson", "Bart"),
                new Alumno("Gonella", "Maggie" , 447891),
                new Persona()
                {
                    Nombre = "Mrs.",
                    Apellido = "Burns"
                }

            };

            var resultado = from p in personas
                            where p.Apellido.Equals("Simpson")
                            orderby p.Nombre
                            select p;
            foreach (Persona p in resultado)
            {
                p.Saludar(); 
            }
    
            Console.WriteLine("Hello World!");
            //me permite declarar una variable sin indicar el tipo de variable
            var alum = new Alumno();
            alum.Legajo = 46297;
            alum.Nombre = "Bart";
            alum.Apellido = "Simpson"; 
            alum.Saludar();
            Console.WriteLine("Fin-.");
        }
    }
}
