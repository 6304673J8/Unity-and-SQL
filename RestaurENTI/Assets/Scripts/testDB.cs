using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mono.Data.Sqlite;
using System.Data;
using System;


public class testDB : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string conn = "URI=file:" + Application.dataPath + "/database.db"; //Path to database.

        Debug.Log(conn);
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        //string sqlQuery = "SELECT id_prueba, prueba " + "FROM pruebas";
        string  sqlQuery =  "SELECT recipes.recipe, recipes.image, ingredients.ingredient, ingredients.image FROM recipes ";
                sqlQuery += "LEFT JOIN recipes_ingredients ON recipes.id_recipe=recipes_ingredients.id_recipe ";
                sqlQuery += "LEFT JOIN ingredients ON ingredients.id_ingredient=recipes_ingredients.id_ingredient ";
                sqlQuery += "WHERE recipes.id_recipe=3";

        //To Test in DB Browser for SQLite
        Debug.Log(sqlQuery);

        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        int counter = 0;
        while (reader.Read())
        {
            if(counter == 0)
            {
                string recipe = reader.GetString(0);
                string recipe_image = reader.GetString(1);

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

    // Update is called once per frame
    void Update()
    {

    }
}