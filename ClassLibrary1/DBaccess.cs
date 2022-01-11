using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public static class DBaccess
    {
        private const string connectString = @"Server=localhost; Database= Birds; Integrated Security=True";
        static public List<CountRow> GetCountData()
        {
            List<CountRow> DataList = new List<CountRow>();
            SqlDataReader birdReader;  //datareader
            SqlCommand selectCommand = new SqlCommand
            {
                Connection = new SqlConnection(connectString),
                CommandText =
                        "Select * from BirdCount order by BirdID"
            };
            selectCommand.Connection.Open();

            birdReader = selectCommand.ExecuteReader();  //execute sql against the database

            //use data reader to retrieve rows one at a time
            while (birdReader.Read())
            {
                CountRow tempRow = new CountRow();
                tempRow.BirderID = (int)birdReader["BirderID"];
                tempRow.BirdID = birdReader["BirdID"].ToString();
                tempRow.RegionID = birdReader["RegionID"].ToString();
                tempRow.Count = (int)birdReader["Counted"];
                tempRow.CountDate = (DateTime)birdReader["CountDate"];
                DataList.Add(tempRow);
            }

            birdReader.Close();  //close the data reader
            return DataList;
        }

        public static string AddBird(string pNewBird)  // adds one new type of bird to the Bird table
        {
            string returnString = "failed to add new bird";
            try
            {
                SqlCommand insertCommand = new SqlCommand
                {
                    Connection = new SqlConnection(connectString),
                    CommandText = "INSERT INTO Bird (Name) VALUES( @Name) "
                };
                // define the 1 Parameter since we cannot trust the textbox data
                _ = insertCommand.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar);
                insertCommand.Parameters["@Name"].Value = pNewBird;

                insertCommand.Connection.Open();
                _ = insertCommand.ExecuteNonQuery();
                insertCommand.Connection.Close();
                returnString = "success, " + pNewBird + " added.";  // if we got this far, must have been successful.
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error loading the from Birds DB: " + ex);
            }
           
            return returnString;
            
        }

        public static void AddCount(CountRow addCountRow)  // add a row of data to the BirdCount table
        {
            try
            {
                SqlCommand insertCommand = new SqlCommand
                {
                    Connection = new SqlConnection(connectString),
                    CommandText =
                    "INSERT INTO BirdCount (BirderID, BirdID, RegionID, Counted, CountDate ) " +
                     " VALUES( " + addCountRow.BirderID + "," + addCountRow.BirdID + "," + addCountRow.RegionID + " ,  @Counted, @CountDate) "
                };
                // define the 2 Parameters since we cannot trust the textbox data
                _ = insertCommand.Parameters.Add("@Counted", System.Data.SqlDbType.Int);
                insertCommand.Parameters["@Counted"].Value = addCountRow.Count;

                _ = insertCommand.Parameters.Add("@CountDate", System.Data.SqlDbType.Date);
                insertCommand.Parameters["@CountDate"].Value = addCountRow.CountDate;

                insertCommand.Connection.Open();
                _ = insertCommand.ExecuteNonQuery();
                insertCommand.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error loading the from Birds DB: " + ex);
            }

        }

        // this code gets the Region names and IDs for the ListBox.  You will need two more methods like this for the other 2 new ListBoxes that you add.
        public static List<Regions> GetRegions()  // create a list of Region objects, one for each row of data in the Regions table
        {
            SqlConnection connection = new SqlConnection(connectString);
            SqlCommand commRegion = new SqlCommand("SELECT RegionID, RegionName FROM Region", connection);
            List<Regions> RegionList = new List<Regions>();
            try
            {
                connection.Open();
                SqlDataReader reader = commRegion.ExecuteReader();
                while (reader.Read())
                {
                    Regions tempRegion = new Regions
                    {
                        RegionID = reader["RegionID"].ToString(),
                        RegionName = reader["RegionName"].ToString()
                    };
                    RegionList.Add(tempRegion);   // add the new object to the List
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error loading the from Birds DB: " + ex);
            }
            finally
            {
                connection.Close();
            }
            return RegionList;
        }

        public static List<Birds> GetBird()  // create a list of Region objects, one for each row of data in the Regions table
        {
            SqlConnection connection = new SqlConnection(connectString);
            SqlCommand commBird = new SqlCommand("SELECT BirdID, Name FROM Bird", connection);
            List<Birds> BirdList = new List<Birds>();
            try
            {
                connection.Open();
                SqlDataReader reader = commBird.ExecuteReader();
                while (reader.Read())
                {
                    Birds tempBird = new Birds
                    {
                        BirdID = reader["BirdID"].ToString(),
                        Name = reader["Name"].ToString()
                    };
                    BirdList.Add(tempBird);   // add the new object to the List
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error loading the from Birds DB: " + ex);
            }
            finally
            {
                connection.Close();
            }
            return BirdList;
        }

        public static List<Birders> GetBirder()  // create a list of Region objects, one for each row of data in the Regions table
        {
            SqlConnection connection = new SqlConnection(connectString);
            SqlCommand commBirder = new SqlCommand("SELECT BirderID, LastName FROM Birder", connection);
            List<Birders> BirderList = new List<Birders>();
            try
            {
                connection.Open();
                SqlDataReader reader = commBirder.ExecuteReader();
                while (reader.Read())
                {
                    Birders tempBirder = new Birders
                    {
                        BirderID = reader["BirderID"].ToString(),
                        LastName = reader["LastName"].ToString()
                    };
                    BirderList.Add(tempBirder);   // add the new object to the List
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error loading the from Birds DB: " + ex);
            }
            finally
            {
                connection.Close();
            }
            return BirderList;
        }
    } // end of DBaccess class


    // classes needed to transport SQL row data in the form of a C# object

    public class CountRow
    {
        public string RegionID { get; set; }
        public string BirdID { get; set; }
        public int BirderID { get; set; }
        public int Count { get; set; }
        public DateTime CountDate { get; set; }
    }

    public class Regions
    {
        public string RegionID { get; set; }
        public string RegionName { get; set; }
    }
    public class Birds
    {
        public string BirdID { get; set; }
        public string Name { get; set; }
    }
    public class Birders
    {
        public string BirderID { get; set; }
        public string LastName { get; set; }
    }
}