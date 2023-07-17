using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlingExerciseTest
{
    public class ValidationException : Exception
    {
        public ValidationException(string msg):base(msg) { }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RegisterUser();
                Console.WriteLine("User registration successfull!!!");
            }
            catch(ValidationException ex) 
            {
                Console.WriteLine($"Validation error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadKey();
        }
        public static void RegisterUser()
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your mail: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            string password = Console.ReadLine();

            ValidateName(name);
            ValidateEmail(email);
            ValidatePassword(password);
        }
        public static void ValidateName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ValidationException("Name is required.");
            }
        }
        public static void ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ValidationException("Email is required.");
            }
            if (!email.Contains("@"))
            {
                throw new ValidationException("This is not a valid email format");
            }
        }
        public static void ValidatePassword(string password)
        {
            if(string.IsNullOrWhiteSpace(password))
            {
                throw new ValidationException("Password is required.");
            }
            if(password.Length < 6)
            {
                throw new ValidationException("password should be at least 6 character.");
            }
        }
    }
}
