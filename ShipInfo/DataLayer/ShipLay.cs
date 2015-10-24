using System;
using ShipInfo.Framework;

using System.Data.SqlClient;
using System.Data;


namespace ShipInfo.DataLayer
{  
  
    class ShipLay
    {
        private static DataPath _dp = new DataPath();
        private Ship insertobj = new Ship();
        private Ship updateobj = new Ship();
        private Ship deleteobj = new Ship();
        public void Insert()
        {
            Console.WriteLine("Enter Ship ID :");
            insertobj.shipId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Ship Oil Amount :");
            insertobj.shipoilamount = float.Parse(Console.ReadLine());
            SqlCommand insertCommand = new SqlCommand("insert into ship values(@Id,@oil)");
            SqlParameter idparam=new SqlParameter("@Id",SqlDbType.Int);
            idparam.Value = insertobj.shipId;
            SqlParameter oilparam = new SqlParameter("@oil", SqlDbType.Float);
            oilparam.Value = insertobj.shipoilamount;
            insertCommand.Parameters.Add(idparam);
            insertCommand.Parameters.Add(oilparam);
           _dp.post(insertCommand);
          

        }
         public void Update()
        {
            Console.WriteLine("Enter Ship ID :");
            updateobj.shipId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Ship Oil Amount :");
            updateobj.shipoilamount = float.Parse(Console.ReadLine());
            SqlCommand updateCommand = new SqlCommand("update ship set oil=@oil where id=@Id");
            SqlParameter idparam=new SqlParameter("@Id",SqlDbType.Int);
            idparam.Value = updateobj.shipId;
            SqlParameter oilparam = new SqlParameter("@oil", SqlDbType.Float);
            oilparam.Value = updateobj.shipoilamount;
            updateCommand.Parameters.Add(idparam);
            updateCommand.Parameters.Add(oilparam);
            _dp.post(updateCommand);
            

        }
         public void Delete()
         {
             Console.WriteLine("Enter Ship ID :");
             deleteobj.shipId = int.Parse(Console.ReadLine());
            
             SqlCommand deleteCommand = new SqlCommand("Delete ship  where id=@id");
             SqlParameter idparam = new SqlParameter("@Id", SqlDbType.Int);
             idparam.Value = deleteobj.shipId;
            
            
             deleteCommand.Parameters.Add(idparam);
            
            _dp.post(deleteCommand);
            

         }
        public void Query()
         {
            string query="select * from ship";
           DataTable n= _dp.Query(query);

            for(int i=0;i<n.Columns.Count;i++)
            {

                Console.Write(n.Columns[i].ColumnName);
                Console.Write("\t");

            }
            Console.WriteLine();
            for(int i=0;i<n.Rows.Count;i++)
            {
                for(int j=0;j<n.Columns.Count;j++)
                {
                    Console.Write(n.Rows[i][j]);
                    Console.Write("\t");

                }
                Console.WriteLine();

            }



         }
    }
}
