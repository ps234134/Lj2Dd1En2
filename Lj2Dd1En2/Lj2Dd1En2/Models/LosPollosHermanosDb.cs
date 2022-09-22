﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using static Lj2Dd1En2.MainWindow;
using System.Xml.Linq;

namespace Lj2Dd1En2.Models
{
    public class LosPollosHermanosDb
    {
        private string connString = ConfigurationManager.ConnectionStrings["Lj2Dd1En2Conn"].ConnectionString;

    }

    //1 GetMeals leest alle rijen in uit de databasetabel Meals en voegt deze toe aan een ICollection.
    // Als de ICollection bij aanroep null is, volgt er een ArgumentException
    // De waarde van GetMeals:
    // - "ok" als er geen fouten waren.
    // - een foutmelding, als er wel fouten waten (mogelijk zijn niet alle maaltijden ingelezen)
    public string GetMeals(ICollection<Meal> meals)
    {
        if (meals == null)
        {
            throw new ArgumentException("Ongeldig argument bij gebruik van GetMeals");
        }
        string methodResult = "unknown";

        using (MySqlConnection conn = new(connString))
        {
            try
            {
                conn.Open();
                MySqlCommand sql = conn.CreateCommand();
                sql.CommandText = @"SELECT m.mealId, m.name, m.description, m.price FROM meals m";
                MySqlDataReader reader = sql.ExecuteReader();

                while (reader.Read()) {
                    Meal meal = new Meal(){
                         MealId = (int)reader["mealId"],
                         Name = (string)reader["name"],
                         Description = reader["description"] == DBNull.Value ? null
                         : (string)reader["description"],
                         Price = (decimal)reader["price"],
                     };
                    meals.Add(meal);
                }
                methodResult = "ok";

            }
            catch (Exception e)
            {

                Console.Error.WriteLine(nameof(GetMeals));
                Console.Error.WriteLine(e.Message);
                methodResult = e.Message;

            }

        }
        return methodResult;

    }
    
}

    
