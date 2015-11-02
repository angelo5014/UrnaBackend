using System.Data;

namespace Aula4Ado
{
    public interface IRepositorio<T>
    {
        T BuscarPorId(int id);
        int Atualizar(T t);
        int Inserir(T t);
        T Parse(IDataReader reader);
    }
}