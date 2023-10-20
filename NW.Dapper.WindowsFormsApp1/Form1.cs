using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using WindowsFormsApplication1;
using WindowsFormsApplication1.Models;

namespace NW.Dapper.WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetTop();
            dataGridView1.DataSource = GetOrders("alfki");
        }
        public List<TopProductViewModel> GetTop()
        {
            var CN_STR = Properties.Settings.Default.ConString;
            var LST = new List<TopProductViewModel>();
            const string SP = "[Ten Most Expensive Products]";

            using (var CN = new SqlConnection(CN_STR))
            {
                var result = CN.Query<TopProductViewModel>(SP,
                    commandType: CommandType.StoredProcedure);
                LST = result.ToList();
            }
            return LST;
        }
        public List<OrderModel> GetOrders(string CustomerID)
        {
            var CN_STR = Properties.Settings.Default.ConString;
            var LST = new List<OrderModel>();
            var PRMS = new DynamicParameters();
            PRMS.Add("CustomerID", CustomerID);
            const string SP = "CustOrdersOrders";
            using (var CN = new SqlConnection(CN_STR))
            {
                var result = CN.Query<OrderModel>(SP, PRMS,
                    commandType: CommandType.StoredProcedure);
                LST = result.ToList();
            }
            return LST;
        }
    }

    
}
