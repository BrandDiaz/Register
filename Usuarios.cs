using System;
using System.Collections.Generic;


[Serializable]
public class Usuario{
	
	public string cedula;
	public string nombre;
	public string apellido;
	public int edad;
	public double ahorros;
	public int password;
		
}


[Serializable]
public class manejadorUsuarios{
	
	private List<Usuario> All = new List<Usuario>();
	
	public void agregarUsuarios(Usuario user){
		All.Add(user);
		
	}
	
	public int totalUsuarios(){
		return All.Count;
		
	}
	
	
	public void borrarUsuarios(int n1){
		All.RemoveAt(n1);
		
	}
	
	public List<Usuario> obtenerUsuarios(){
		
		return All;
	}
	
	
}







