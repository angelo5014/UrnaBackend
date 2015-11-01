namespace Aula4Ado
{
    public interface IRepositorio<T>
    {
        T BuscarPorId(int id);
        int Atualizar(T t);
        void Inserir(T t);
    }
}