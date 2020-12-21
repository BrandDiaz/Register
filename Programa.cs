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
		List<Usuario> All = null;
		
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

						  while(contiprogramaU){

								Usuario user = new Usuario();
		                  		Console.Clear();
		                  
		                  		Console.WriteLine("Agregar Nuevo Usuario");
		                  		Console.WriteLine();

		                  		Console.Write("Ingrese la Cedula: ");
		                  		user.cedula = Console.ReadLine();
		                  		Console.Write("Ingrese el Nombre: ");
								user.nombre = Console.ReadLine();

								while(!Regex.IsMatch(user.nombre, @"^[a-zA-Z]+$")){

									Console.Write("Ingrese solo letras: ");
									user.nombre = Console.ReadLine();

								}

		                  		Console.Write("Ingrese el Apellido: ");
		                  		user.apellido = Console.ReadLine();

								while(!Regex.IsMatch(user.apellido, @"^[a-zA-Z]+$")){

									Console.Write("Ingrese solo letras: ");
									user.apellido = Console.ReadLine();

								}

						  		Console.Write("Ingrese su Edad: ");
								while(!int.TryParse(Console.ReadLine(), out user.edad)){

									Console.Write("Ingrese solo numeros");

								}

								Console.Write("Ingrese sus ahorros: ");
								while(!double.TryParse(Console.ReadLine(), out user.ahorros)){

									Console.Write("Ingrese solo numeros");

								}

								Console.Write("Ingrese su contraseña: ");
								
								ConsoleKeyInfo key;
								do
								{
									key = Console.ReadKey(true);

									if(Char.IsNumber(key.KeyChar)){

										Console.Write("*");

									}
									user.password += key.KeyChar;


								}while(key.Key != ConsoleKey.Enter);

								int confirm_edad = 0;
								Console.Write("COnfirme su Contraseña: ");

								do
								{
									key = Console.ReadKey(true);

									if(Char.IsNumber(key.KeyChar)){

										Console.Write("*");

									}
									confirm_edad += key.KeyChar;


								}while(key.Key != ConsoleKey.Enter);

								if(user.password != confirm_edad){

									Console.WriteLine("Las contraseñas no coinciden, favor registra nuevamente");

								}else{

									Console.WriteLine("Las contraseñas coinciden, felicidades");

								}
								
		                  		mU.agregarUsuarios(user);

						  		Console.WriteLine();
						 		Console.WriteLine("Usuario Agregado, desea Salir o Continuar Agregando? y/n");
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
			                 	All = mU.obtenerUsuarios(); 
						     	Console.WriteLine();
						     
			                 	int n1 = 1;
			                 	foreach(Usuario users in All)
							 	{
			                
			                
			                     Console.WriteLine(n1+"-"+users.cedula);
						    	 n1++;
			                
			                    }
						    	Console.WriteLine();
						      
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
						            
		                            Console.Write("Ingrese la Cedula: ");
		                            usert.cedula = Console.ReadLine();
		                            Console.Write("Ingrese el Nombre: ");
		                            usert.nombre = Console.ReadLine();
		                            Console.Write("Ingrese el Apellido: ");
		                            usert.apellido = Console.ReadLine();
		                            Console.Write("Ingrese su Edad: ");
		                            int.TryParse(Console.ReadLine(), out usert.edad);
		                            mU.agregarUsuarios(usert);
									
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
			             	All = mU.obtenerUsuarios(); 
						 	Console.WriteLine();
						 	
			             	int n1 = 1;
			             	foreach(Usuario users in All)
							{

			                 Console.WriteLine(n1+"-"+users.cedula);
							 n1++;
			          
			                }
							Console.WriteLine();
							
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
						   
						   FileStream streamout = new FileStream("Datos.dat", FileMode.Create);
						   BinaryFormatter formaterout = new BinaryFormatter();
						   formaterout.Serialize(streamout, mU);
						   streamout.Close();
						   
			               Console.Clear();
			               contiprograma2 = false;
						
						break;
						
					   default: 
			 
			              Console.WriteLine();
		                  Console.WriteLine(seleccion + " No es una opcion de seleccion");
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
			             All = mU.obtenerUsuarios(); 
						 Console.WriteLine();
						 
			             int n1 = 1;
			             foreach(Usuario user in All){
			          
			          
			                 Console.WriteLine(n1+"-"+user.cedula+" - "+ user.nombre);
							 n1++;
			          
			                }
							Console.ReadKey();
						
						
						break;

						case "2": 
						
						 Console.Clear();
			             Console.WriteLine("Busqueda de Usuarios");
			             All = mU.obtenerUsuarios(); 
						 Console.WriteLine();
						
						 Console.Write("Ingrese la cedula del usuario: ");
						 string cedulaUsuario = Console.ReadLine();

			             foreach(Usuario user in All)
						 {

							if(user.cedula == cedulaUsuario ){

								Console.Clear();	          
			            		Console.WriteLine("Cedula: "+user.cedula);
								Console.WriteLine("Nombre: "+user.nombre);
								Console.WriteLine("Apellido: "+user.apellido);
								Console.WriteLine("Edad: "+user.edad);

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
			             				All = mU.obtenerUsuarios();

						 				Console.WriteLine();

			              				n1 = 1;
			             				foreach(Usuario user in All){
										 
										 
			                				Console.WriteLine(n1+"-"+user.cedula);
											n1++;

			                			}
										Console.WriteLine();
										int n = 0;
										Console.Write("Ingrese el numero del Usuario que desea Exportar: ");
										int.TryParse(Console.ReadLine(), out n);

										n = n - 1;

						    			n1 = 1;

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

										string carpetaE = "C:\\EXCEL";
		                  				if (Directory.Exists(carpetaE) == false){
		                  					Directory.CreateDirectory(carpetaE);	
		                  				}

						 				Console.Clear();
			             				Console.WriteLine("Exportar Usuarios");
			             				All = mU.obtenerUsuarios();

						 				Console.WriteLine();

			              				n1 = 1;
			             				foreach(Usuario user in All){
										 
										 
			                				Console.WriteLine(n1+"-"+user.nombre);
											n1++;

			                			}
										Console.WriteLine();
										Console.Write("Ingrese el nombre del archivo: ");
										string excel = Console.ReadLine();
										Console.Write("Ingrese el numero del Usuario que desea Exportar: ");
										int.TryParse(Console.ReadLine(), out n);

										n = n - 1;

						    			n1 = 1;

										if(n <= mU.totalUsuarios()){

											string filePath = "c:\\EXCEL\\"+excel+".csv";

									    	var csv = new StringBuilder();

											if(!File.Exists(filePath))
											{
												File.AppendAllText(filePath, "Cedula, Nombre, Apellido, Edad" + Environment.NewLine); 
											}

									    	var first = All[n].cedula;
									    	var second = All[n].nombre;
											var third = All[n].apellido;
											var fourd = All[n].edad;
									    	var newLine = string.Format("{0},{1},{2},{3}", first, second, third, fourd);
									    	csv.AppendLine(newLine);  

									    	File.AppendAllText(filePath, csv.ToString());
											
											Console.WriteLine();
											Console.WriteLine("Usuario Exportado en la Carpeta EXCEL del Disco C");
											Console.ReadKey();

						    			}else{
						    			 Console.WriteLine();
						    			 Console.Write("Usuario no Listado");
						    			 Console.ReadKey();
						    			}

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
		                  Console.WriteLine(seleccion + " No es una opcion de seleccion");
		                  Console.ReadKey();
						  
		                break;
						
					}		 
			    }
			 
			 break;
			 
			 case "3": 
				
				string carpetaExit = "C:\\EXCEL";
		        if (Directory.Exists(carpetaExit) == false){
		            Directory.CreateDirectory(carpetaExit);	
		        }

				Console.Clear();
			    All = mU.obtenerUsuarios();

				Console.WriteLine();

				string excelS = args[0];

				int count =  mU.totalUsuarios();

				if(count > 0){

					string filePath = "c:\\EXCEL\\"+excelS+".csv";

					var csv = new StringBuilder();

					if(!File.Exists(filePath))
					{
						File.WriteAllText(filePath, "Cedula, Nombre, Apellido, Edad" + Environment.NewLine); 
					}

					
					foreach(Usuario users in All){

						

						var first = users.cedula;
						var second = users.nombre;
						var third = users.apellido;
						var fourd = users.edad;
						var newLine = string.Format("{0},{1},{2},{3}", first, second, third, fourd);
						csv.AppendLine(newLine);  
						
					}

					File.AppendAllText(filePath, csv.ToString());
						

					Console.WriteLine();
					Console.WriteLine("Usuarios Exportados en la Carpeta EXCEL del Disco C");
					Console.ReadKey();

				}else{
					string filePath = "c:\\EXCEL\\"+excelS+".csv";

					var csv = new StringBuilder();

					if(!File.Exists(filePath))
					{
						File.AppendAllText(filePath, "Cedula, Nombre, Apellido, Edad" + Environment.NewLine); 
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
}