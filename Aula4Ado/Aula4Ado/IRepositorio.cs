namespace Aula4Ado
{
    public interface IRepositorio<T>
    {
        T BuscarPorId(int id);
        void Atualizar(T t);
        void Inserir(T t);
    }
}