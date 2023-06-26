namespace QualaServices.Models;

public partial class Sucursal
{

    private int codigo;
    public int Codigo
    {
        get { return codigo; }
        set { codigo = value; }
    }

    private string descripcion;
    public string Descripcion
    {
        get { return descripcion; }
        set { descripcion = value ?? throw new ArgumentNullException(nameof(value)); }
    }

    private string direccion;
    public string Direccion
    {
        get { return direccion; }
        set { direccion = value ?? throw new ArgumentNullException(nameof(value)); }
    }

    private string identificacion;
    public string Identificacion
    {
        get { return identificacion; }
        set { identificacion = value ?? throw new ArgumentNullException(nameof(value)); }
    }

    private DateTime fecha;
    public DateTime Fecha
    {
        get { return fecha; }
        set
        {
            if (value < DateTime.Today)
            {
                throw new ArgumentException("La fecha no puede ser menor a la fecha actual.");
            }
            fecha = value;
        }
    }

    private int monedaId;
    public int MonedaId
    {
        get { return monedaId; }
        set { monedaId = value; }
    }


}
