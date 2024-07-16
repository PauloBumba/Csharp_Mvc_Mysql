using System ;
using Crud.Data;


class Program 
{
    static void Main()
    {
        var dataset = new Dataset();
        dataset.OpenConnecting();
        dataset.CloseConnecting();

    }
}
