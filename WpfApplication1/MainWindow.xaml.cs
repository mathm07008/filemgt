using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MysqlCon c = new MysqlCon();
            MySqlConnection con = c.getConnection();
            con.Open();

            string c1 = @"SELECT 
                Code, HomeTeamName as HomeTeam, AwayTeamName as AwayTeam, TypeName as Type, RunnerType as Runner, BackPrice, StartsTime
                FROM vOdds
                WHERE StartsTime > now() AND StartsTime< (now() + INTERVAL 3 Day) AND Bookmaker = 1
                ORDER BY StartsTime ASC;";

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(c1, con);
            System.Data.DataTable DT = new System.Data.DataTable();
            mySqlDataAdapter.Fill(DT);
            dataGrid1.ItemsSource = DT.DefaultView;
        }
        
    }
}
