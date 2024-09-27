using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace de1
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategoryData();
            }
        }

        private void BindCategoryData()
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["QLKhoaHocDatabase"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string query = @"SELECT c.CatID, c.CatName, COUNT(co.ID) AS CourseCount
                             FROM Category c
                             LEFT JOIN Course co ON c.CatID = co.CatID
                             GROUP BY c.CatID, c.CatName";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    var categories = new List<object>();

                    while (reader.Read())
                    {
                        categories.Add(new
                        {
                            CatID = reader["CatID"],
                            CatName = reader["CatName"],
                            CourseCount = reader["CourseCount"]
                        });
                    }

                    // Kiểm tra số lượng danh mục
                    if (categories.Count > 0)
                    {
                        dlCategories.DataSource = categories;
                        dlCategories.DataBind();
                    }
                    else
                    {
                        // Ghi nhận không có danh mục
                        Response.Write("<script>alert('No categories found.');</script>");
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }
        protected void dlCategories_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
