using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;


class Programa{

	public static void Main(string[] args){
		
		manejadorUsuarios mU = new manejadorUsuarios();
		
		bool contiprograma = true; 
		string seleccion = "";
		List<Usuario> All = mU.obtenerUsuarios();

        FileStream streamin = new FileStream ("Datos.dat", FileMode.Open);
		BinaryFormatter formaterin = new BinaryFormatter();
		mU = (manejadorUsuarios)(formaterin.Deserialize(streamin));
		streamin.Close();
		
		while(contiprograma)
		{
			
		 Console.Clear();
		 Console.WriteLine("Programa que guarda datos de los Usuarios. (Cantidad de Usuarios "+mU.totalUsuarios()+")");
		 Console.WriteLine();
		 
		 Console.WriteLine("1. Gestionar Usuarios");
		 Console.WriteLine("2. Reportes");
		 Console.WriteLine("3. Salir");
		 Console.WriteLine();
		 
		 Console.Write("Seleccione la opcion deseada: ");
		 seleccion = Console.ReadLine();
		 
		 switch(seleccion)
			{
			 
			 case "1": 
			 
			 bool contiprograma2 = true;
			 
			 while(contiprograma2)
			    {
				 
				  Console.Clear();
		          Console.WriteLine("Gestion de Usuarios");
		          Console.WriteLine();
		          Console.WriteLine("1. Agregar Usuarios");
		          Console.WriteLine("2. Modificar Usuarios");
		          Console.WriteLine("3. Eliminar Usuarios");
		          Console.WriteLine("4. Volver a Menu Principal ");
		          Console.WriteLine();
		          
		          Console.Write("Seleccione la opcion deseada: ");
		          seleccion = Console.ReadLine();
				  
				  switch(seleccion)
				    {
						case "1": 
						
						  bool contiprogramaU = true;

						  while(contiprogramaU)
						  	{

								addUser(mU);
							  

						  		Console.WriteLine();
								string response = Console.ReadLine();
								if(response.ToLower() == "n"){
				          			Console.Clear();
									contiprogramaU = false;
								}
						  		Console.ReadKey();
				          		Console.Clear();

						    }
			          
						break;
						
						case "2": 
						
							if(mU.totalUsuarios() > 0)
						    {
						     	Console.Clear();
			                 	Console.WriteLine("Usuarios agregados");
						     	Console.WriteLine();
						     
								userList(mU);
						      
						    	Console.Write("Ingrese el numero del Usuario que desea modificar: ");
						        int n = 0;
						        int.TryParse(Console.ReadLine(), out n);
								
							    
						    	if(n <= mU.totalUsuarios()){
									
									mU.borrarUsuarios(n-1);
							        Console.WriteLine();
					                Usuario usert = new Usuario();
		                            Console.Clear();
		                            
		                            Console.WriteLine("Introducir nuevos datos de Usuario");
		                            Console.WriteLine();
						            
									addUser(mU);
									
									Console.WriteLine();
									Console.WriteLine("Usuario Modificado");
									Console.ReadKey();
				                    Console.Clear();
			          
						    	  
						    	}else{
						    		Console.WriteLine();
						    		Console.Write("No existe el Usuario numero "+n);
						    		Console.ReadKey();
						    	}
								
						    	
						    }else{
						    	Console.WriteLine();
						    	Console.Write("Necesita agregar almenos un Usuario");
			                    Console.ReadKey();
						    }
						
						break;
						
						case "3": 
						
						if(mU.totalUsuarios() > 0)
						{
						 	Console.Clear();
			             	Console.WriteLine("Usuarios agregados");
						 	Console.WriteLine();
						 	
							userList(mU);
							
							Console.Write("Ingrese el numero del Usuario que desea eliminar: ");
							int n = 0;
							int.TryParse(Console.ReadLine(), out n);
							
							if(n <= mU.totalUsuarios()){
							  mU.borrarUsuarios(n-1);
							  Console.WriteLine();
							  Console.WriteLine("Usuario Eliminado");
							  Console.ReadKey();
							  
							}else{
								Console.WriteLine();
								Console.Write("No existe el Usuario numero "+n);
								Console.ReadKey();
							}
							
						}else{
							Console.WriteLine();
							Console.Write("Necesita agregar almenos un Usuario");
			                Console.ReadKey();
							}

						break;
						
						case "4": 
						
						   Console.WriteLine();
						   
						   saveDat(mU);
						   
			               Console.Clear();
			               contiprograma2 = false;
						
						break;
						
					   default: 
			 
			              	Console.WriteLine();
							Console.WriteLine(seleccion + "No es una opcion de seleccion");
							Console.ReadKey();
						  
		                break;
				    }
				 
			    }
			 
			 break;
			 
			 case"2": 
			 
			 bool contiprograma4 = true;
			 
			 while(contiprograma4)
			 	{
				 
				    Console.Clear();
		            Console.WriteLine("Gestion de Reportes");
		            Console.WriteLine();
		            Console.WriteLine("1. Listado de Usuarios");
					Console.WriteLine("2. Busqueda de Usuarios");
					Console.WriteLine("3. Exportar Usuario");
					Console.WriteLine("4. Volver al Menu Principal");
		            Console.WriteLine();
		            
		            Console.Write("Seleccione la opcion deseada: ");
		            seleccion = Console.ReadLine();
					
					switch(seleccion){
						
						case "1": 
						
						 Console.Clear();
			             Console.WriteLine("Lista de Usuarios");
						 Console.WriteLine();
						 
						 userList(mU);
						 Console.ReadKey();
						
						
						break;

						case "2": 
						
						 Console.Clear();
			             Console.WriteLine("Busqueda de Usuarios");
						 Console.WriteLine();
						
						 Console.Write("Ingrese la cedula del usuario: ");
						 string cedulaUsuario = Console.ReadLine();

			             foreach(Usuario user in All)
						 {

							if(user.cedula == cedulaUsuario){

								Console.Clear();	          
			            		Console.WriteLine("Cedula: "+user.cedula);
								Console.WriteLine("Nombre: "+user.nombre);
								Console.WriteLine("Apellido: "+user.apellido);
								Console.WriteLine("Edad: "+user.edad);
								Console.WriteLine("Genero: "+user.genero);
								Console.WriteLine("Estado Civil: "+user.civil);
								Console.WriteLine("Grado Academico: "+user.academico);
								Console.WriteLine("Ahorros: "+user.ahorros);
								Console.WriteLine("Contraseña: "+user.password);
							}
			          
			             }
							Console.ReadKey();
						
						break;
						
						case "3":

							bool contiprogramareport = true;

							while(contiprogramareport){

								Console.Clear();
		            			Console.WriteLine("Exportar");
		            			Console.WriteLine();
		            			Console.WriteLine("1. Exportar HTML");
								Console.WriteLine("2. Exportar Excel");
								Console.WriteLine("3. Volver al Menu Principal");
		            			Console.WriteLine();

		            			Console.Write("Seleccione la opcion deseada: ");
		            			seleccion = Console.ReadLine();

								switch(seleccion){

									case "1":
										string carpeta = "C:\\HTML";
		                  				if (Directory.Exists(carpeta) == false){
		                  					Directory.CreateDirectory(carpeta);	
		                  				}

						 				Console.Clear();
			             				Console.WriteLine("Exportar Usuarios");

						 				Console.WriteLine();
										All = mU.obtenerUsuarios();
										userList(mU);

										Console.WriteLine();
										
										Console.Write("Ingrese el numero del Usuario que desea Exportar: ");
										int n = 0;
										int.TryParse(Console.ReadLine(), out n);

										n = n - 1;

										if(n <= mU.totalUsuarios()){

						    			    string informacion = "<html>"+
		                    			    "<head>"+
		                    			    "</head>"+
		                    			    "<body style>"+
		                    			    "<table border='1'><tr><th>Cedula</th><td>"+All[n].cedula+
		                    			    "</td></tr><tr><th>Nombre</th><td>"+All[n].nombre+
		                    			    "</td></tr><tr><th>Apellido</th><td>"+All[n].apellido+
		                    			    "</td></tr><tr><th>Edad</th><td>"+All[n].edad+
		                    			    "</td></tr></table></body>";

						  				    File.WriteAllText("c:\\HTML\\"+All[n].cedula+".html", informacion);

											Console.WriteLine();
											Console.WriteLine("Usuario Exportado en la Carpeta HTML del Disco C");
											Console.ReadKey();

						    			}else{
						    			 Console.WriteLine();
						    			 Console.Write("Usuario no Listado");
						    			 Console.ReadKey();
						    			}

									break;

									case "2":

						 				Console.Clear();
			             				Console.WriteLine("Exportar Usuarios");

						 				Console.WriteLine();
										All = mU.obtenerUsuarios();

										userList(mU);

										Console.WriteLine();
										Console.Write("Ingrese el nombre del archivo: ");
										string excel_name = Console.ReadLine();
										Console.Write("Ingrese el numero del Usuario que desea Exportar: ");
										int.TryParse(Console.ReadLine(), out n);

										if(n <= mU.totalUsuarios()){

											Excel(mU, excel_name, n);
											Console.ReadKey();

						    			}else{
						    			 Console.WriteLine();
						    			 Console.Write("Usuario no Listado");
						    			 Console.ReadKey();
						    			}

									break;

									case "3": 
						
										Console.Clear();
										contiprogramareport = false;
						
									break;

								}

							}

						break;
						
						case "4": 
						
							Console.Clear();
							contiprograma4 = false;
						
						break;
						
						
						default: 
			 
			                Console.WriteLine();
							Console.WriteLine(seleccion + "No es una opcion de seleccion");
							Console.ReadKey();
						  
		                break;
						
					}		 
			    }
			 
			 break;
			 
			 case "3": 
				
				Console.Clear();

				Console.WriteLine();

				string excelS = args[0];

				int count =  mU.totalUsuarios();

				if(count > 0){

					Excel(mU, excelS);

				}else{
					string filePath = "c:\\EXCEL\\"+excelS+".csv";

					var csv = new StringBuilder();

					if(!File.Exists(filePath))
					{
						File.WriteAllText(filePath, "Cedula, Nombre, Apellido, Edad, Contraseña" + Environment.NewLine); 
					}	

				}
			 
				Console.WriteLine();
		    	Console.Write("Vuelva pronto");
		    	Console.ReadKey();
		    	contiprograma = false;
			 
			 break;
			 
			 default: 
			 
				Console.WriteLine();
				Console.WriteLine(seleccion + "No es una opcion de seleccion");
				Console.ReadKey();

			 break;

		    }		
		}	
		
    }

	public static void saveDat(manejadorUsuarios mU){

		FileStream streamout = new FileStream("Datos.dat", FileMode.Create);
		BinaryFormatter formaterout = new BinaryFormatter();
		formaterout.Serialize(streamout, mU);	
		streamout.Close();

	}

	public static void addUser(manejadorUsuarios mU){
				
		Console.Clear();
		
		int age = 0, gender = 0, civil = 0, academic = 0;
		Usuario user = new Usuario();
		ConsoleKeyInfo key;
		                  
		Console.WriteLine("Agregar Nuevo Usuario");
		Console.WriteLine();

		Console.Write("Ingrese la Cedula: ");
		do{
			key = Console.ReadKey(true);
   			checkNumbers(user, key);
		}while(key.Key != ConsoleKey.Enter);
		Console.WriteLine();
		
		Console.Write("Ingrese el Nombre: ");
		do{
			key = Console.ReadKey(true);
   			checkLetters(user, key);
		}while(key.Key != ConsoleKey.Enter);
		Console.WriteLine();

		Console.Write("Ingrese el Apellido: ");
		do{
			key = Console.ReadKey(true);
   			checkLetters(user, key, 1);
		}while(key.Key != ConsoleKey.Enter);
		Console.WriteLine();

		Console.Write("Ingrese su Edad: ");
		do{
			key = Console.ReadKey(true);
   			checkNumbers(user, key, 1);
		}while(key.Key != ConsoleKey.Enter);
		Console.WriteLine();

		Console.Write("Ingrese sus ahorros: ");
		do{
			key = Console.ReadKey(true);
   			checkNumbers(user, key, 2);
		}while(key.Key != ConsoleKey.Enter);
		Console.WriteLine();


	
		Console.WriteLine("Ingrese su sexo (H/M): ");
		string read_gender = Console.ReadLine();

		if (read_gender.ToLower() == "h"){

			gender = 1;

		}else{

			gender = 0;
		}

		Console.WriteLine("Ingrese su estdo civil (C/S): ");
		string read_civil = Console.ReadLine();

		if (read_civil.ToLower() == "c"){

			civil = 1;

		}else{

			civil = 0;
		}
							  
		Console.WriteLine("Ingrese su grado academico (I/G/M/D): ");
		string read_grado = Console.ReadLine();

		if (read_grado.ToLower() == "i"){

			academic = 00;

		}else if (read_grado.ToLower() == "g") {

			academic = 01;

		}else if (read_grado.ToLower() == "m") {

			academic = 10;

		}else if (read_grado.ToLower() == "d") {

			academic = 11;
		}

		int.TryParse(user.edad, out age);

		Bitwise(user, age, gender, civil, academic);

		Console.Write("Ingrese su contraseña: ");	
		do{
			key = Console.ReadKey(true);
   			checkPassword(user, key);
		}while(key.Key != ConsoleKey.Enter);
		Console.WriteLine();

		Console.Write("Confirme su contraseña: ");	
		do{
			key = Console.ReadKey(true);
   			checkPassword(user, key, true);
		}while(key.Key != ConsoleKey.Enter);
		Console.WriteLine();
		
		if(user.password == user.confirm_password){

			mU.agregarUsuarios(user);
			saveDat(mU);
			Console.WriteLine("Usuario Agregado, desea Salir o Continuar Agregando? y/n");

		}else{

			Console.WriteLine("Contraseñas no coinciden favor registrar nuevamente");

		}							


	}

	public static void checkPassword(Usuario user, ConsoleKeyInfo key, bool check = false){

		if(key.Key != ConsoleKey.Backspace){

			Console.Write("*");

			if(!check){

				user.password += key.KeyChar;

			}else if (check){

				user.confirm_password += key.KeyChar;

			}

		}else if(key.Key == ConsoleKey.Backspace) {
			
			if(check && user.password.Length > 0){

				user.password = user.password.Substring(0, (user.password.Length - 1));

			}else if (!check && user.confirm_password.Length > 0){

				user.confirm_password = user.confirm_password.Substring(0, (user.confirm_password.Length - 1));

			}
			Console.Write("\b \b");

		}					

	}

	public static void checkNumbers(Usuario user, ConsoleKeyInfo key, int check = 0){


		
		if(key.Key != ConsoleKey.Backspace){

				
			if(Char.IsNumber(key.KeyChar)){

				Console.Write(key.KeyChar);

				if(check == 0){

					user.cedula += key.KeyChar;

				}else if (check == 1){

					user.edad += key.KeyChar;

				}else if (check == 2){

					user.ahorros +=  key.KeyChar;

				}

			}else{
				Console.Write(" ");
				Console.Write("\b");
			}


		}else if(key.Key == ConsoleKey.Backspace) {
			
			if(check == 0 && user.cedula.Length > 0){

				user.cedula = user.cedula.Substring(0, (user.cedula.Length - 1));

			}else if (check == 1 && user.edad.Length > 0){

				user.edad = user.edad.Substring(0, (user.edad.Length - 1));

			}else if (check == 2 && user.ahorros.Length > 0){

				user.ahorros = user.ahorros.Substring(0, (user.ahorros.Length - 1));

			}
			Console.Write("\b \b");

		}
		
	}

	public static void checkLetters(Usuario user, ConsoleKeyInfo key, int check = 0){

		if(key.Key != ConsoleKey.Backspace){


			if(!Char.IsNumber(key.KeyChar)){
			
				Console.Write(key.KeyChar);
	
				if(check == 0){
				
					user.nombre += key.KeyChar;
	
				}else if (check == 1){
				
					user.apellido += key.KeyChar;
	
				}
			}


		}else if(key.Key == ConsoleKey.Backspace) {
			
			if(check == 0 && user.nombre.Length > 0){

				user.nombre = user.nombre.Substring(0, (user.nombre.Length - 1));

			}else if (check == 1 && user.apellido.Length > 0){

				user.apellido = user.apellido.Substring(0, (user.apellido.Length - 1));

			}
			Console.Write("\b \b");

		}
									
	}

	public static int userList(manejadorUsuarios mU){

		List<Usuario> All_Users = mU.obtenerUsuarios();

		int n1 = 1;
		foreach(Usuario users in All_Users)
		{
			                               
		 Console.WriteLine(n1+"-"+users.cedula+" - "+ users.nombre);
		 n1++;
			                
	    }
		Console.WriteLine();

		return n1;
	}

	public static void Excel(manejadorUsuarios mU, string path, int n = 0){

		List<Usuario> All_Users = mU.obtenerUsuarios();

    	string carpetaExit = "C:\\EXCEL";
		if (Directory.Exists(carpetaExit) == false){
			Directory.CreateDirectory(carpetaExit);	
		}

    
		string filePath = "c:\\EXCEL\\"+path+".csv";

		var csv = new StringBuilder();

    	if(!File.Exists(filePath))
		{
			File.AppendAllText(filePath, "Cedula, Nombre, Contraseña, Informacion_Empaquetada" + Environment.NewLine); 
		}

		
		if (n > 0){

			n = n - 1;

			var first = All_Users[n].cedula;
			var second = All_Users[n].nombre;
			var five = All_Users[n].password;
			var six = All_Users[n].packed_info;
			var newLine = string.Format("{0},{1},{2},{3}", first, second, five, six);
			csv.AppendLine(newLine);  

		}else{

			foreach(Usuario users in All_Users){

				var first = users.cedula;
				var second = users.nombre;
				var third = users.apellido;
				var fourd = users.edad;
				var five = users.genero;
				var six = users.civil;
				var seven = users.academico;
				var eigth = users.password;
				var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", first, second, third, fourd, five, six, seven, eigth);
				csv.AppendLine(newLine);  
						
			}

		}

		File.AppendAllText(filePath, csv.ToString());
						
		Console.WriteLine();
		Console.WriteLine("Usuarios Exportados en la Carpeta EXCEL del Disco C");
		Console.ReadKey();


	}

	public static void Bitwise(Usuario user, int age, int gender, int civil, int academic){

		int packed_info = (age << 8) | (gender << 7) | (civil << 6) | academic;
		user.packed_info = packed_info;

		Console.WriteLine(packed_info);

		academic = packed_info & 0x2F;  
		gender = (packed_info >> 7) & 1;
		age    = (packed_info >> 8);
		civil = (packed_info >> 6) & 1;

		user.edad = age.ToString();

		if(academic == 00){

			user.academico = "Sin Estudios";

		}else if (academic == 01){

			user.academico = "Graduado";

		}else if (academic == 10){

			user.academico = "Maestria";

		}else if (academic == 11){

			user.academico = "Doctorado";
		}

		if(gender == 1){

			user.genero = "Hombre";

		}else{

			user.genero = "Mujer";
		}

		
		if(civil == 1){

			user.civil = "Casad@";

		}else{

			user.civil = "Solter@";
		}

	}


}