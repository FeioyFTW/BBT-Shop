﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace BubbleTea
{
    public partial class Search : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater1.DataSource = GetAllDrinks();

            Repeater1.DataBind();
        }

        private DataSet GetAllDrinks()
        {
            string Drinks = ConfigurationManager.ConnectionStrings["BBT"].ConnectionString;
            string keyword = Request.QueryString["Key"].ToString();

            using (SqlConnection conn = new SqlConnection(Drinks))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Drinks WHERE Name LIKE @Keyword");
                SqlDataAdapter sda = new SqlDataAdapter();

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Keyword", keyword);
                cmd.Parameters["@Keyword"].Value = "%" + keyword + "%";

                cmd.Connection = conn;
                sda.SelectCommand = cmd;

                DataSet datadrinks = new DataSet();

                //step 6: pass the retrieved data into the newly created Dataset
                sda.Fill(datadrinks);

                //step 7: return
                return datadrinks;
            }
        }

        private DataSet GetDrinks(string type)
        {
            string keyword = Request.QueryString["Key"].ToString();
            string Drinks = ConfigurationManager.ConnectionStrings["BBT"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(Drinks))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Drinks WHERE Type = @type AND Name LIKE @Keyword");
                SqlDataAdapter sda = new SqlDataAdapter();

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@Keyword", keyword);
                cmd.Parameters["@Keyword"].Value = "%" + keyword + "%";

                cmd.Connection = conn;
                sda.SelectCommand = cmd;

                DataSet datadrinks = new DataSet();

                //step 6: pass the retrieved data into the newly created Dataset
                sda.Fill(datadrinks);

                //step 7: return
                return datadrinks;
            }
        }

        protected void All_Click(object sender, EventArgs e)
        {
            DataSet drinks = GetAllDrinks();

            Repeater1.DataSource = drinks;

            Repeater1.DataBind();
        }


        protected void Milk_Click(object sender, EventArgs e)
        {
            DataSet drinks = GetDrinks("Milk Tea");

            Repeater1.DataSource = drinks;

            Repeater1.DataBind();
        }


        protected void Brew_Click(object sender, EventArgs e)
        {
            DataSet drinks = GetDrinks("Brewed Tea");

            Repeater1.DataSource = drinks;

            Repeater1.DataBind();
        }


        protected void Fruit_Click(object sender, EventArgs e)
        {
            DataSet drinks = GetDrinks("Fruit Tea");

            Repeater1.DataSource = drinks;

            Repeater1.DataBind();
        }

        protected void Latte_Click(object sender, EventArgs e)
        {
            DataSet drinks = GetDrinks("Tea Latte");

            Repeater1.DataSource = drinks;

            Repeater1.DataBind();
        }


        protected void Mousse_Click(object sender, EventArgs e)
        {
            DataSet drinks = GetDrinks("Mousse Tea");

            Repeater1.DataSource = drinks;

            Repeater1.DataBind();
        }


        protected void Honey_Click(object sender, EventArgs e)
        {
            DataSet drinks = GetDrinks("Honey Tea");

            Repeater1.DataSource = drinks;

            Repeater1.DataBind();
        }
    }
}