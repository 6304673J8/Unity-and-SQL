using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.UI;

public class testDB1 : MonoBehaviour
{
    public Text recipeName;
    int randomizer;

    public List<String> ingredients = new List<string>();
    public List<String> recipes = new List<string>();
    public List<String> recipe_ingredients = new List<string>();

    string conn;
    private void Awake()
    {
        conn = "URI=file:" + Application.dataPath + "/database.db"; //Path to database.
    }
    // Start is called before the first frame update
    void Start()
    {        
        Debug.Log(conn);
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        
        //string sqlQuery = "SELECT id_prueba, prueba " + "FROM pruebas";
        string  sqlQuery =  "SELECT recipes.recipe, recipes.image, ingredients.ingredient, ingredients.image FROM recipes ";
                sqlQuery += "LEFT JOIN recipes_ingredients ON recipes.id_recipe=recipes_ingredients.id_recipe ";
                sqlQuery += "LEFT JOIN ingredients ON ingredients.id_ingredient=recipes_ingredients.id_ingredient ";
                sqlQuery += "WHERE recipes.id_recipe=" + randomizer;

        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        int counter = 0;
        while (reader.Read())
        {
            if(counter == 0)
            {
                string recipe = reader.GetString(0);
                string recipe_image = reader.GetString(1);
                
                recipeName.text = recipe;
                Debug.Log("RECETA: = " + recipe + " (" + recipe_image + ")");
            }

            counter++;

            string ingredient = reader.GetString(2);
         
            Debug.Log(counter + ".- " + ingredient);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    public List<Ingredient> GetIngredients()
    {
        Debug.Log(conn);
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = "SELECT * FROM ingredients";

        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        List<Ingredient> ingredients = new List<Ingredient>();

        while (reader.Read())
        {
            ingredients.Add(new Ingredient(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

        return ingredients;
    }

    public List<Recipe> GetRecipes()
    {
        Debug.Log(conn);
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = "SELECT * FROM recipes";
        
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        List<Recipe> recipes = new List<Recipe>();

        while (reader.Read())
        {
            recipes.Add(new Recipe(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
        }
        return recipes;
    }
}