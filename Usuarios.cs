using System;
using System.Collections.Generic;


[Serializable]
public class Usuario{
	
	private string ID;
	private string name;
	private string lastname;
	private string age;
	private string savings;
	private string pass;
	private string confirm_pass;
	private string academic;
	private string gender;
	private string civil_state;
	private int pack;

	public string cedula{

		get{ return ID;}
		set{ ID = value;}

	}
	public string nombre{

		get{ return name;}
		set{ name = value;}

	}
	public string apellido{

		get{ return lastname;}
		set{ lastname = value;}

	}
	public string edad{

		get{ return age;}
		set{ age = value;}

	}
	public string ahorros{

		get{ return savings;}
		set{ savings = value;}

	}
	public string password{

		get{ return pass;}
		set{ pass = value;}

	}
	public string confirm_password{

		get{ return confirm_pass;}
		set{ confirm_pass = value;}

	}
	public string academico{

		get{ return academic;}
		set{ academic = value;}

	}
	public string genero{

		get{ return gender;}
		set{ gender = value;}

	}
	public string civil{

		get{ return civil_state;}
		set{ civil_state = value;}

	}
	public int packed_info{

		get{ return pack;}
		set{ pack = value;}

	}
	
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







