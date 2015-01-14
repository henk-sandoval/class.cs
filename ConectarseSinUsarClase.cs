//PRIMERO SE DEBE AGREGAR LA RUTA DE LA BASE DE DATOS EN EL WEB.CONFIG
/*
<connectionStrings>

<add name="BD" connectionString="Data Source=127.0.0.1;Initial Catalog=v2_bs;User ID=sa;Password=123456" providerName="System.Data.SqlClient"/>

</connectionStrings>
*/

//LUEGO EN UN ASPX SE AGREGA EL SIGUIENTE CODIGO
	
      	String cadenaCon;
 	      ConnectionStringSettings Conex;
        Conex = ConfigurationManager.ConnectionStrings["BD"];
        cadenaCon = Conex.ConnectionString;
        cn = new SqlConnection(cadenaCon);
