using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldDemoProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(args.Length);
            // Console.Read();
            //var teilnehmer = args[0];

            try
            {
                Console.WriteLine($"Holla, if ya' hear me! {args[1]}");
                Console.WriteLine("Super, kein Fehler.");
            }
            //catch(IndexOutOfRangeException ioore) //when(ioore.Message.Contains("Index"))
            //{
            //    Console.WriteLine(ioore.Message);
            //    Console.WriteLine("Mist, doch Fehler.");
            //}
            //catch (Exception ex)
            //{
            //    //Console.WriteLine(ex.Message);
            //    throw;
            //}
            catch   (Exception)
            {
                throw new DemoException();
            }
            finally
            {
                Console.WriteLine("ich mag finally");
            }
            Console.Read(); 
        }
    }

    public class DemoException:Exception
    {
        public DemoException()
        {

        }

        public DemoException(string message)
        {

        }
    }

}
