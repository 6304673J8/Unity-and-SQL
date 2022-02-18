using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.UI;

public class RestaurentiDB : MonoBehaviour
{
    public Text recipeName;

    string initIngredientsTable;
    string initRecipesTable;
    string initRecipesIngredientsTable;

    public List<String> ingredients = new List<string>();
    public List<String> recipes = new List<string>();
    public List<String> recipe_ingredients = new List<string>();

    private string dbName;
    string m_Path;

    private void Awake()
    {
        dbName = "URI=file:" + Application.dataPath + "/database.db"; //Path to database

        #region Queries Tables Creation
        #region "Ingredients Table"
        initIngredientsTable = "CREATE TABLE IF NOT EXISTS ingredients ( ";
        initIngredientsTable += "id_ingredient INTEGER NOT NULL UNIQUE, ";
        initIngredientsTable += "ingredient TEXT, ";
        initIngredientsTable += "image TEXT, ";
        initIngredientsTable += "PRIMARY KEY(id_ingredient AUTOINCREMENT)); ";
        #endregion

        #region "Recipes Table"
        initRecipesTable = "CREATE TABLE IF NOT EXISTS recipes ( ";
        initRecipesTable += "id_recipe INTEGER NOT NULL UNIQUE, ";
        initRecipesTable += "recipes TEXT, ";
        initRecipesTable += "images TEXT, ";
        initRecipesTable += "PRIMARY KEY(id_recipe AUTOINCREMENT)); ";
        #endregion

        #region "Recipes_Ingredients Table"
        initRecipesIngredientsTable = "CREATE TABLE IF NOT EXISTS recipes_ingredients ( ";
        initRecipesIngredientsTable += "id_recipe_ingredient INTEGER NOT NULL UNIQUE, ";
        initRecipesIngredientsTable += "id_recipe INTEGER, ";
        initRecipesIngredientsTable += "id_ingredient INTEGER, ";
        initRecipesIngredientsTable += "PRIMARY KEY(id_recipe_ingredient AUTOINCREMENT), ";
        initRecipesIngredientsTable += "FOREIGN KEY(id_recipe) REFERENCES recipes(id_recipe), ";
        initRecipesIngredientsTable += "FOREIGN KEY(id_ingredient) REFERENCES ingredients(id_ingredient));";
        #endregion
        #endregion
    }

    // Start is called before the first frame update
    void Start()
    {
        //Get the path of the Game data folder
        m_Path = Application.dataPath;

        //Output the Game data path to the console
        Debug.Log("dataPath : " + m_Path);

        dbName = "URI=file:" + Application.dataPath + "/database.db"; //Path to database

        //Run The Method To Create The Tables
        CreateDB();
    }

    public void CreateDB()
    {
        //Create the db connection
        using (var dbConn = new SqliteConnection(dbName))
        {
            Debug.Log(dbName);
            dbConn.Open();

            //Set Up An Object (dbCmd) To Allow DB Control
            using (var dbCmd = dbConn.CreateCommand())
            {
                //Debug.Log(initIngredientsTable);
                //Debug.Log(initRecipesTable);
                //Debug.Log(initRecipesIngredientsTable);

                //Create Tables In Case They Don't Exist
                dbCmd.CommandText = initIngredientsTable;
                dbCmd.ExecuteNonQuery();
                dbCmd.CommandText = initRecipesTable;
                dbCmd.ExecuteNonQuery();
                dbCmd.CommandText = initRecipesIngredientsTable;
                dbCmd.ExecuteNonQuery();

                dbCmd.Dispose();
            }
            dbConn.Close();
        }
    }

    public List<Ingredient> GetIngredients()
    {
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(dbName);
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
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(dbName);
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
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

        return recipes;
    }

    public List<RecipeIngredients> GetRecipeIngredients()
    {
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(dbName);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = "SELECT * FROM recipes_ingredients";

        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        List<RecipeIngredients> recipeIngredients = new List<RecipeIngredients>();

        while (reader.Read())
        {
            recipeIngredients.Add(new RecipeIngredients(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2)));
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

        return recipeIngredients;
    }
}