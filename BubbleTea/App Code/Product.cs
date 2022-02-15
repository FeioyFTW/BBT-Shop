using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{
    //system.Configuration.ConnectionStringSettings _connStr;
    string _connStr = ConfigurationManager.ConnectionStrings["BBT"].ConnectionString;
    private string _prodID = null;
    private string _prodName = string.Empty;
    private decimal _unitPrice = 0;
    private string _prodImage = "";


    public Product(string prodID, string prodName,
                   decimal unitPrice, string prodImage)
    {
        _prodID = prodID;
        _prodName = prodName;
        _unitPrice = unitPrice;
        _prodImage = prodImage;
    }

    //get/set the attributes of the Product object.
    //note the attribute name (e.g. Product_ID) is same as the actual database field name.
    //this is for ease of referencing.
    public string Product_ID
    {
        get { return _prodID; }
        set { _prodID = value; }
    }
    public string Product_Name
    {
        get { return _prodName; }
        set { _prodName = value; }
    }
    public decimal Unit_Price
    {
        get { return _unitPrice; }
        set { _unitPrice = value; }
    }
    public string Product_Image
    {
        get { return _prodImage; }
        set { _prodImage = value; }
    }
    //below as the Class methods for some DB operations. 
    public Product getProduct(string prodID)
    {
        Product prodDetail = null;

        string prod_Name, Prod_Image;
        decimal unit_Price;

        string queryStr = "SELECT * FROM Drinks WHERE ID = @ProdID";

        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@ProdID", prodID);

        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            prod_Name = dr["Name"].ToString();
            Prod_Image = dr["ImgLink"].ToString();
            unit_Price = decimal.Parse(dr["Price"].ToString());

            prodDetail = new Product(prodID, prod_Name, unit_Price, Prod_Image);
        }
        else
        {
            prodDetail = null;
        }

        conn.Close();
        dr.Close();
        dr.Dispose();

        return prodDetail;
    }

    public int UserDelete(string ID)
    {
        string queryStr = "DELETE FROM Account WHERE ID=@ID";
        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@ID", ID);
        conn.Open();
        int nofRow = 0;
        nofRow = cmd.ExecuteNonQuery();
        conn.Close();
        return nofRow;
    }

    public int ProductInsert()
    {
        int result = 0;
        string queryStr = "INSERT INTO Drinks(ID, Name, Price, ImgLink)" + "values (@Product_ID, @Product_Name, @Unit_Price, @Product_Image)";

        SqlConnection conn = new SqlConnection(_connStr);
        SqlCommand cmd = new SqlCommand(queryStr, conn);
        cmd.Parameters.AddWithValue("@Product_ID", this.Product_ID);
        cmd.Parameters.AddWithValue("@Product_Name", this.Product_Name);
        cmd.Parameters.AddWithValue("@Unit_Price", this.Unit_Price);
        cmd.Parameters.AddWithValue("@Product_Image", this.Product_Image);

        conn.Open();
        result += cmd.ExecuteNonQuery();
        conn.Close();

        return result;
    }//end Insert
}
